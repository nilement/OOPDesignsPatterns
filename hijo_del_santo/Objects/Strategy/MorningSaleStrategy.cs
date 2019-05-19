namespace Objects.Strategy
{
    public class MorningSaleStrategy : ISaleStrategy
    {
        public int GetPrice(int price)
        {
            return price;
        }
    }
}
