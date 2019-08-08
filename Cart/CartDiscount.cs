using System.Collections.Generic;

namespace CartApp
{
    public class CartDiscount : IDiscount
    {
        //private Cart _cart;
        private double _discount;
        
       
        public void Set(double discount)
        {
            this._discount = discount;
        }
        
        public double CalculateDiscount(Cart cart)
        {

            double discountedPrice = 0,totalPrice=0;
            var cartItemList = cart.GetCartItemList();
            foreach (var item in cartItemList)
            {
                totalPrice += item.TotalPrice;
            }
            discountedPrice = totalPrice - totalPrice * _discount / 100;
            return discountedPrice;

        }
    }
}
