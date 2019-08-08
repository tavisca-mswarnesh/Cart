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
            //DiscountConfiguration discountConfiguration = new DiscountConfiguration();
            //discountConfiguration.SetDiscountForCart(0);
            CartDiscount cartDiscount = new CartDiscount();
            Cart cart = new Cart(cartDiscount);
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
            //DiscountConfiguration discountConfiguration = new DiscountConfiguration();
            //discountConfiguration.SetDiscountForCart(0);
            CartDiscount cartDiscount = new CartDiscount();
            cartDiscount.Set(0);
            Cart cart = new Cart(cartDiscount);
            cartItem.Item = mobile;
            cartItem.Quantity = 10;
            cart.AddItemToCart(cartItem);
            Assert.Equal(1000, cart.GetTotalPrice());
        }

        [Fact]
        public void DiscountedPriceTest()
        {
            Mobile mobile = new Mobile();
            CartItem cartItem = new CartItem();
            //DiscountConfiguration discountConfiguration = new DiscountConfiguration();
            //discountConfiguration.SetDiscountForCart(10);
            CartDiscount cartDiscount = new CartDiscount();
            cartDiscount.Set(10);
            Cart cart = new Cart(cartDiscount);
            cartItem.Item = mobile;
            cartItem.Quantity = 10;
            cart.AddItemToCart(cartItem);
            Assert.Equal(900, cart.GetTotalPrice());
        }

        [Fact]
        public void EnumTest()
        {
            Product product = new Mobile();
            Assert.Equal(Category.Electronics, product.category);
        }

        [Fact]
        public void CategoryDiscountTest()
        {
            Mobile mobile = new Mobile();
            Cheese cheese = new Cheese();
            CartItem cartItem = new CartItem();
            //DiscountConfiguration discountConfiguration = new DiscountConfiguration();
            //discountConfiguration.SetDiscountForCategory(Category.Electronics, 5);
            //discountConfiguration.SetDiscountForCategory(Category.Electronics, 10);
            CategoryDiscount categoryDiscount = new CategoryDiscount();
            categoryDiscount.Set(Category.Electronics, 5);
            categoryDiscount.Set(Category.Dairy, 50);
            cartItem.Item = mobile;
            cartItem.Quantity = 10;

            var cartItem1 = new CartItem();
            cartItem1.Item = cheese;
            cartItem1.Quantity = 10;


            Cart cart = new Cart(categoryDiscount);
            cart.AddItemToCart(cartItem);
            cart.AddItemToCart(cartItem1);
            Assert.Equal(1000, cart.GetTotalPrice());
        }

        [Fact]
        public void CompositeDiscountTest()
        {
            Mobile mobile = new Mobile();
            Cheese cheese = new Cheese();
            CartItem cartItem = new CartItem();
            //DiscountConfiguration discountConfiguration = new DiscountConfiguration();
            //discountConfiguration.SetDiscountForCategory(Category.Electronics, 5);
            //discountConfiguration.SetDiscountForCategory(Category.Electronics, 10);
            ProductDiscount productDiscount = new ProductDiscount();
            
            cartItem.Item = mobile;
            cartItem.Quantity = 10;

            var cartItem1 = new CartItem();
            cartItem1.Item = cheese;
            cartItem1.Quantity = 10;

            productDiscount.Set(mobile,5);
            productDiscount.Set(cheese, 50);
            Cart cart = new Cart(productDiscount);
            cart.AddItemToCart(cartItem);
            cart.AddItemToCart(cartItem1);
            Assert.Equal(1000, cart.GetTotalPrice());
        }
    }
}
