using System.Collections.Generic;

namespace CartApp
{
    public class DiscountConfiguration
    {
        public double discount=0;
        public Dictionary<Category, double> categoryDiscount = new Dictionary<Category, double>();
        public void SetDiscountForCart(double discount)
        {
            this.discount = discount;
        }
        public double GetDiscountForCart()
        {
            return discount;
        }
        public void SetDiscountForCategory(Category category, double discount)
        {
            categoryDiscount[category] = discount;
        }
        public double GetDiscountForCategory(Category category)
        {
            if (categoryDiscount.ContainsKey(category))
            {
                return categoryDiscount[category];
            }
            return 0;
        }
    }
}
