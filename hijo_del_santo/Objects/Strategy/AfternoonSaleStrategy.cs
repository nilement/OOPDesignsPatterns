namespace Objects.Strategy
{
    public class AfternoonSaleStrategy : ISaleStrategy
    {
        public int GetPrice(int price)
        {
            return (int)(price * 1.6);
        }
    }
}
