using System;
using System.Collections.Generic;

namespace SilpoBonusCore.Tests
{
    public class CheckoutService
    {

        Check check;
        

        public void OpenCheck()
        {
            check = new Check();
            check.products = new List<Product>();
            check.totalCost = 0;
        }

        public void AddProduct(Product product)
        {
            check.products.Add(product);
        }

        public Check CloseCheck()
        {
            foreach (Product product in check.products)
            {
                check.totalCost += product.price;
            }
            return check;
        }
    }
}