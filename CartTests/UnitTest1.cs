using CartApp;
using System;
using System.Collections.Generic;
using Xunit;

namespace CartTests
{
    public class UnitTest1
    {
        [Fact]
        public void ProductPriceTest()
        {
            Mobile mobile = new Mobile();
            PriceCalculator priceCalculator = new PriceCalculator();
            double expectedPrice = 1000;
            double actualPrice = priceCalculator.GetTotalProductPrice(mobile, 10);
            Assert.Equal(expectedPrice, actualPrice);
        }

        [Fact]
        public void AddProductTest()
        {
            Mobile mobile = new Mobile();
            CartItem cartItem = new CartItem();
            Cart cart = new Cart();
            cartItem.Item = mobile;
            cartItem.Quantity = 10;
            cart.AddItemToCart(cartItem);
            List<CartItem> cartItemList = new List<CartItem>();
            cartItem.TotalPrice = 1000;
            cartItemList.Add(cartItem);
            Assert.Equal(cartItemList, cart.GetCartItemList());
        }

        [Fact]
        public void TotalPriceTest()
        {
            Mobile mobile = new Mobile();
            CartItem cartItem = new CartItem();
            Cart cart = new Cart();
            cartItem.Item = mobile;
            cartItem.Quantity = 10;
            cart.AddItemToCart(cartItem);
            Assert.Equal(1000,cart.GetTotalPrice());
        }

        [Fact]
        public void DiscountedPriceTest()
        {
            Mobile mobile = new Mobile();
            CartItem cartItem = new CartItem();
            Cart cart = new Cart();
            cartItem.Item = mobile;
            cartItem.Quantity = 10;
            cart.AddItemToCart(cartItem);
            Assert.Equal(900, cart.GetDiscountedPrice(10));
        }
    }
}
