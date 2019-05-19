using System;
using Objects.PveOpponent.PveDecorator;

namespace Objects.PveOpponent.Opponents
{
    public static class OpponentFactory
    {

        public static Opponent CreateOpponent(OpponentCategory? opponentCategory = null, bool withDecorator = true)
        {
            Opponent opponent;
            switch (opponentCategory ?? (OpponentCategory)Common.Random.Next(Enum.GetNames(typeof(OpponentCategory)).Length))
            {
                case OpponentCategory.Knight:
                    opponent = new Knight();
                    break;
                case OpponentCategory.Knight2:
                    opponent = new Knight2();
                    break;
                case OpponentCategory.Knight3:
                    opponent = new Knight3();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return withDecorator ? ApplyDecorator(opponent) : opponent;
        }

        public static Opponent RestoreOpponent(Guid id, string name, int strength, int agility, int intelligence, int level, int gold, OpponentCategory category,
            int experience, bool withDecorator = true)
        {
            Opponent opponent;
            switch (category)
            {
                case OpponentCategory.Knight:
                    opponent = new Knight(id, name, strength, agility, intelligence, level, gold, category);
                    break;
                case OpponentCategory.Knight2:
                    opponent = new Knight2(id, name, strength, agility, intelligence, level, gold, category);
                    break;
                case OpponentCategory.Knight3:
                    opponent = new Knight3(id, name, strength, agility, intelligence, level, gold, category);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return withDecorator ? ApplyDecorator(opponent, opponent.SummonerCount) : opponent;
        }

        public static Opponent RestoreOpponent(Opponent opponent, bool withDecorator = true)
        {
            return RestoreOpponent(opponent.Id, opponent.Name, opponent.Strength, opponent.Agility, opponent.Intelligence, opponent.Level,
                opponent.Gold, opponent.Category, opponent.Experience);
        }

        private static Opponent ApplyDecorator(Opponent opponent)
        {
            var opponentToReturn = opponent;
            var decoratorThreshold = 0.1;
            while (true)
            {
                if (Common.Random.NextDouble() >= decoratorThreshold)
                {
                    break;
                }
                opponentToReturn = new SummonnerOpponent(opponentToReturn);
            }

            return opponentToReturn;
        }

        private static Opponent ApplyDecorator(Opponent opponent, int count)
        {
            var opponentToReturn = opponent;
            for (int i = 0; i < count; i++)
            {
                opponentToReturn = new SummonnerOpponent(opponentToReturn);
            }

            return opponentToReturn;
        }
    }
}
