using System;
using System.Linq;
using Objects.Events;
using Objects.PveOpponent.Opponents;

namespace Objects
{

    [Serializable]
    public class CombatRoom
    {
        public readonly Guid RoomId;
        private Character _first, _second;
        public Opponent PveOpponent;
        public Guid FirstGuid, SecondGuid;
        private int _firstHealth, _secondHealth;
        private SessionStore _sessionStore;
        private bool _isFirstsTurn = true;
        private IEventConnection _userEvents;
        private Action<Opponent, int, bool> _finishFightDatabaseCall;

        public CombatRoom(Action<Opponent, int, bool> finishFightDatabaseCall)
        {
            _userEvents = EventHttpAdapter.GetHttpAdapter();
            RoomId = Guid.NewGuid();
            _sessionStore = SessionStore.GetSessionStore();
            _finishFightDatabaseCall = finishFightDatabaseCall;
        }

        public CombatRoom(Opponent opponent, Action<Opponent, int, bool> finishFightDatabaseCall)
        {
            PveOpponent = opponent;
            _secondHealth = opponent.Strength * 25;
            _userEvents = EventHttpAdapter.GetHttpAdapter();
            RoomId = Guid.NewGuid();
            _sessionStore = SessionStore.GetSessionStore();
            _finishFightDatabaseCall = finishFightDatabaseCall;
        }

        // Netestuoju nieko, px man, aš mldc.
        public int PlayerTurn(ActionType type)
        {
            if (type == ActionType.Attack)
            {
                var weaponPower = (_isFirstsTurn ? _first : _second).Items?.FirstOrDefault(x => x.IsEquipped && x.Category == ItemCategory.Weapon)?.Power ?? 0;
                var value = DamageDealt((_isFirstsTurn ? _first : _second).Agility, (_isFirstsTurn ? _first : _second).Intelligence, weaponPower);
                if (_isFirstsTurn)
                {
                    _secondHealth -= value;
                }
                else
                {
                    _firstHealth -= value;
                }

                Console.WriteLine($"{_firstHealth} - {_secondHealth}");
                return BunchOfConditionalStatements(_isFirstsTurn ? _secondHealth : _firstHealth);
            }

            return -Int32.MaxValue; // Also known as Matthew's intelligence 
        }

        public Guid AddPlayer(Guid sessionGuid)
        {
            if (_first == null)
            {
                _first = _sessionStore.GetCharacter(sessionGuid);
                var itemHealth = _first.Items?.Where(x => x.IsEquipped && x.Category != ItemCategory.Weapon)
                    .Sum(x => x.Power) ?? 0;
                _firstHealth = _first.Strength * 25 + itemHealth;
                FirstGuid = sessionGuid;
                return RoomId;
            }

            _second = _sessionStore.GetCharacter(sessionGuid);
            _secondHealth = _second.Strength * 25;
            SecondGuid = sessionGuid;
            _sessionStore = null;
            return RoomId;
        }

        public bool IsWaitingForPlayer()
        {
            return _second == null;
        }

        private int BunchOfConditionalStatements(int health)
        {
            return health > 0 ? FightStep(health) : EndOfFight();
        }


        public Character GetMe(Guid sessionId)
        {
            return sessionId == FirstGuid ? _first : _second;
        }

        public int GetMyHealth(Guid sessionId)
        {
            return sessionId == FirstGuid ? _firstHealth : _secondHealth;
        }

        public int GetMyOpponentHealth(Guid sessionId)
        {
            return sessionId != FirstGuid ? _firstHealth : _secondHealth;
        }

        public bool IsMyTurn(Guid sessionId)
        {
            return sessionId == FirstGuid ? _isFirstsTurn : !_isFirstsTurn;
        }

        public string GetOpponentName(Guid sessionId)
        {
            return sessionId == FirstGuid ? _second.Name : _first.Name;
        }

        private void OpponentAttack()
        {
            _firstHealth -= DamageDealt(PveOpponent.Agility, PveOpponent.Strength);
            if (_firstHealth < 0)
            {
                var combatEventLoser = new CombatOverEvent { IsWinner = false };
                _userEvents.NotifyClient(FirstGuid, combatEventLoser);
                _finishFightDatabaseCall(PveOpponent, _first.Id, false);
                return;
            }

            var combatEvent = new CombatEvent(false, ActionType.Attack, _firstHealth);
            _userEvents.NotifyClient(FirstGuid, combatEvent);
        }

        private int FightStep(int health)
        {
            if (PveOpponent != null)
            {
                OpponentAttack();
                return _secondHealth;
            }

            var combatEvent = new CombatEvent(_isFirstsTurn, ActionType.Attack, health);
            _userEvents.NotifyClient(_isFirstsTurn ? SecondGuid : FirstGuid, combatEvent);
            _isFirstsTurn = !_isFirstsTurn;
            return _isFirstsTurn ? _firstHealth : _secondHealth;
        }

        private int EndOfFight()
        {
            if (PveOpponent != null)
            {
                var pveCombatEventWinner = new CombatOverEvent(true, PveOpponent.Gold, PveOpponent.Experience);
                _userEvents.NotifyClient(FirstGuid, pveCombatEventWinner);
                _finishFightDatabaseCall(PveOpponent, _first.Id, true);
            }
            else
            {
                var combatEventWinner = new CombatOverEvent(_isFirstsTurn, _isFirstsTurn ? _second.Gold : _first.Gold,
                    _isFirstsTurn ? _second.Experience : _first.Experience);
                var combatEventLoser = new CombatOverEvent { IsWinner = !_isFirstsTurn };
                _userEvents.NotifyClient(_isFirstsTurn ? FirstGuid : SecondGuid, _isFirstsTurn ? combatEventWinner : combatEventLoser);
                _userEvents.NotifyClient(_isFirstsTurn ? SecondGuid : FirstGuid, !_isFirstsTurn ? combatEventWinner : combatEventLoser);
            }


            return 0;
        }
        private int DamageDealt(int agility, int intellect, int weaponDamage = 0)
        {
            return Common.Random.Next(0, agility) * (int) Math.Sqrt(Common.Random.Next(0, intellect)) + weaponDamage;
        }
    }
}
