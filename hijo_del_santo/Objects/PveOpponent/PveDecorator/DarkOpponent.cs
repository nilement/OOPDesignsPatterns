using Objects.PveOpponent.Opponents;

namespace Objects.PveDecorator
{
    public class DarkOpponent : Opponent
    {
        private Opponent _opponent { get; set; }
        public DarkOpponent(Opponent opponent)
        {
            _opponent = opponent;
            _opponent.Strength *= 2;
        }

        public override void Attack()
        {
            _opponent.Attack();
        }

    }
}
