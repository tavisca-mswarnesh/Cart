using System.Collections.Generic;

namespace CartApp
{
    public class Cart :Discount
    {
        List<CartItem> cartItemList = new List<CartItem>();
        PriceCalculator priceCalculator = new PriceCalculator();
        

        public void AddItemToCart(CartItem cartItem)
        {
            cartItem.TotalPrice = priceCalculator.GetTotalProductPrice(cartItem.Item, cartItem.Quantity);
            cartItemList.Add(cartItem);
            
        }
        public List<CartItem> GetCartItemList()
        {
            return cartItemList;
        }

        public override double GetDiscountedPrice(double discountPercent)
        {
            double totalPrice = GetTotalPrice();
            double discountedPrice = totalPrice - totalPrice * discountPercent / 100;
            return discountedPrice;
        }

        public double GetTotalPrice()
        {
            double totalPrice=0;
            foreach (CartItem item in cartItemList)
                totalPrice += item.TotalPrice;
            return totalPrice;
        }
    }
}
