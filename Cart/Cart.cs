using System.Collections.Generic;

namespace CartApp
{
    public class Cart 
    {
        List<CartItem> cartItemList = new List<CartItem>();
        PriceCalculator priceCalculator = new PriceCalculator();
        DiscountConfiguration discountConfiguration;
        public Cart( DiscountConfiguration discountConfiguration)
        {
            this.discountConfiguration = discountConfiguration;
        }

        public void AddItemToCart(CartItem cartItem)
        {
            CartItem _cartItem = cartItemList.Find(item => item.Item == cartItem.Item);
            double discount = discountConfiguration.GetDiscountForCategory(cartItem.Item.category);
            if (_cartItem==null)
            {
                cartItem.TotalPrice = priceCalculator.GetTotalProductPrice(cartItem.Item, cartItem.Quantity);
                cartItem.TotalPrice = cartItem.TotalPrice - (cartItem.TotalPrice * discount / 100);
                cartItemList.Add(cartItem);
            }
            else
            {
                _cartItem.TotalPrice = priceCalculator.GetTotalProductPrice(cartItem.Item, cartItem.Quantity);
                _cartItem.TotalPrice = _cartItem.TotalPrice - (_cartItem.TotalPrice * discount / 100);
            }
            
            
        }
        public void RemoveItemFromCart(CartItem cartItem)
        {
            CartItem _cartItem = cartItemList.Find(item => item.Item == cartItem.Item);
            if(_cartItem!=null)
            {
                cartItemList.Remove(cartItem);
            }
        }
        public List<CartItem> GetCartItemList()
        {
            return cartItemList;
        }

        

        public double GetTotalPrice()
        {
            double totalPrice=0;
            foreach (CartItem item in cartItemList)
                totalPrice += item.TotalPrice;
            double discount = discountConfiguration.GetDiscountForCart();
            totalPrice = totalPrice - (totalPrice * discount / 100);
            return totalPrice;
        }
    }
}
