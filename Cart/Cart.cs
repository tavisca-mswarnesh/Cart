using System.Collections.Generic;

namespace CartApp
{
    public class Cart 
    {
        List<CartItem> cartItemList = new List<CartItem>();
        PriceCalculator priceCalculator = new PriceCalculator();
        IDiscount discountCoupon;
        public Cart(IDiscount discountCoupon)
        {
            this.discountCoupon = discountCoupon;
        }

        public void AddItemToCart(CartItem cartItem)
        {
            CartItem _cartItem = cartItemList.Find(item => item.Item == cartItem.Item);
            
            if (_cartItem==null)
            {
                cartItem.TotalPrice = priceCalculator.GetTotalProductPrice(cartItem.Item, cartItem.Quantity);
                cartItemList.Add(cartItem);
            }
            else
            {
                _cartItem.TotalPrice = priceCalculator.GetTotalProductPrice(cartItem.Item, cartItem.Quantity);
                
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
            

            return discountCoupon.CalculateDiscount(this);
            
        }
    }
}
