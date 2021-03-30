using System;
using System.Collections.Generic;

namespace SilpoBonusCore
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

        public void UseOffer(AnyGoodsOffer offer)
        {
            if(offer is FactorByCategoryOffer)
            {
                FactorByCategoryOffer fbOffer = (FactorByCategoryOffer) offer;
                int points = check.GetCostByCategory(fbOffer.category);
                check.AddPoints(points * (fbOffer.factor - 1));
            }
            else
            {
                if(offer.totalCost <= check.GetTotalCost())
                {
                    check.AddPoints(offer.points);
                }
            }
        }
    }
}