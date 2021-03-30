using System;
using System.Collections.Generic;

namespace SilpoBonusCore.Tests
{
    public class CheckoutService
    {

        Check check;
        Check closedCheck;
        

        public void OpenCheck()
        {
            check = new Check(); 
        }

        public void AddProduct(Product product)
        {
            if(check == null)
            {
                OpenCheck();
            }
            check.AddProduct(product);
        }

        public Check CloseCheck()
        {
            closedCheck = check;
            check = null;
            return closedCheck;
        }
    }
}