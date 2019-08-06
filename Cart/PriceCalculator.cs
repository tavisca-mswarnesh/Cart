namespace CartApp
{
    public class PriceCalculator
    {
        public double GetTotalProductPrice(Product product,int quantity)
        {
            return (product.Price * quantity);
        }
    }
}
