using System.Collections.Generic;

namespace CartApp
{
    public class CategoryDiscount : IDiscount
    {
        
        public Dictionary<Category, double> categoryDiscount = new Dictionary<Category, double>();
        public bool IsCategoryHasDiscount(Category category)
        {
            if(categoryDiscount.ContainsKey(category))
            {
                return true;
            }
            return false;
        }
        
        public double discount = 0;
        public void Set(Category category, double discount)
        {
            categoryDiscount[category] = discount;
        }

        public double CalculateDiscount(Cart cart)
        {
            var cartItemList = cart.GetCartItemList();

            double discountedPrice=0,totalDiscountPrice=0;
            foreach (var item in cartItemList)
            {
                if (IsCategoryHasDiscount(item.Item.category))
                {
                    discountedPrice = categoryDiscount[item.Item.category];
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
