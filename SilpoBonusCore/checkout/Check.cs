using System;
using System.Collections.Generic;

namespace SilpoBonusCore.Tests
{
    public class Check
    {
        List<Product> products = new List<Product>();
        int totalCost;

        public object GetTotalCost()
        {
            foreach (Product product in this.products)
            {
                totalCost += product.price;
            }
            return totalCost;
        }

        internal void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}