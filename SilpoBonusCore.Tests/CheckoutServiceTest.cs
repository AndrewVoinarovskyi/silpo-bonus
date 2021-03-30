using System;
using Xunit;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {
        [Fact]
        void closeCheck__withOneProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();

            checkoutService.AddProduct(new Product(7, "Milk"));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(7, check.GetTotalCost());
        }

        [Fact]
        void closeCheck__withTwoProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.OpenCheck();

            checkoutService.AddProduct(new Product(7, "Milk"));
            checkoutService.AddProduct(new Product(3, "Bread"));
            Check check = checkoutService.CloseCheck();

            Assert.Equal(10, check.GetTotalCost());
        }
    }

    
}