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
        }

        public void AddProduct(Product product)
        {
            check.AddProduct(product);
        }

        public Check CloseCheck()
        {
            return check;
        }
    }
}