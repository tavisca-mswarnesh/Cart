using System.Collections.Generic;

namespace CartApp
{
    public class ProductDiscount : IDiscount
    {
        public Dictionary<Product, double> productDiscount = new Dictionary<Product, double>();
        
        public double discount = 0;
        public bool IsProductHasDiscount(Product product)
        {
            if (productDiscount.ContainsKey(product))
            {
                return true;
            }
            return false;
        }
        
        
        public void Set(Product product, double discount)
        {
            productDiscount[product] = discount;
        }

        public double CalculateDiscount(Cart cart)
        {
            var cartItemList = cart.GetCartItemList();

            double discountedPrice = 0, totalDiscountPrice = 0;
            foreach (var item in cartItemList)
            {
                if (IsProductHasDiscount(item.Item))
                {
                    discountedPrice = productDiscount[item.Item];
                    totalDiscountPrice += (item.TotalPrice - item.TotalPrice * discountedPrice / 100);
                }
                else
                {
                    totalDiscountPrice += item.TotalPrice;
                }
            }
            return totalDiscountPrice;

        }
    }
}
