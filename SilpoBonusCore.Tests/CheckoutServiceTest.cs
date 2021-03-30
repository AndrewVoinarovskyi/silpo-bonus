using System;
using Xunit;

namespace SilpoBonusCore.Tests
{
    public class CheckoutServiceTest
    {

        private Product milk_7;
        private Product bread_3;

        private CheckoutService checkoutService;

        public CheckoutServiceTest()
        {
            checkoutService  = new CheckoutService();
            checkoutService.OpenCheck();
            
            milk_7 = new Product(7, "Milk", Category.MILK);
            bread_3 = new Product(3, "Bread", Category.BREAD);
        }

        [Fact]
        void closeCheck__withOneProduct()
        {
            checkoutService.AddProduct(milk_7);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(7, check.GetTotalCost());
        }

        [Fact]
        void closeCheck__withTwoProduct()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);
            Check check = checkoutService.CloseCheck();

            Assert.Equal(10, check.GetTotalCost());
        }

        [Fact]
        void AddProduct__WWhenCheckIsClosed__OpensNewCheck()
        {
            checkoutService.AddProduct(milk_7);
            Check milkCheck = checkoutService.CloseCheck();
            Assert.Equal(7, milkCheck.GetTotalCost());

            checkoutService.AddProduct(bread_3);
            Check breadCheck = checkoutService.CloseCheck();
            Assert.Equal(3, breadCheck.GetTotalCost());
        }

        [Fact]
        void CloseCheck__CalcTotalPoints()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);
            Check check = checkoutService.CloseCheck();
            
            Assert.Equal(10, check.GetTotalPoints());
        }

        [Fact]
        void UseOffer__AddOfferPoints()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);
            
            checkoutService.UseOffer(new AnyGoodsOffer(6, 2));
            
            Check check = checkoutService.CloseCheck();
            
            Assert.Equal(12, check.GetTotalPoints());

        }

        [Fact]
        void UseOffer__WhenCostLessThanRequired__DoNothing()
        {
            checkoutService.AddProduct(bread_3);
            

            checkoutService.UseOffer(new AnyGoodsOffer(6, 2));
            
            Check check = checkoutService.CloseCheck();
            
            Assert.Equal(3, check.GetTotalPoints());

        }

        [Fact]
        void useOffer__FactorByCategory()
        {
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(milk_7);
            checkoutService.AddProduct(bread_3);
            
            checkoutService.UseOffer(new FactorByCategoryOffer(Category.MILK, 2));
            
            Check check = checkoutService.CloseCheck();
            
            Assert.Equal(31, check.GetTotalPoints());

        }
    }
}