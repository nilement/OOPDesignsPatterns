namespace Objects.Strategy
{
    public class NightSaleStrategy : ISaleStrategy
    {
        public int GetPrice(int price)
        {
            return (int) (price * 0.8);
        }
    }
}
