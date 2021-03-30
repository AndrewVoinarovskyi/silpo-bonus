using System;
using System.Collections.Generic;

namespace SilpoBonusCore
{
    public class Check
    {
        List<Product> products = new List<Product>();
        int totalCost;
        int points = 0;

        public int GetTotalCost()
        {
            totalCost = 0;
            
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

        public int GetTotalPoints()
        {
            return GetTotalCost() + points;
        }

        internal void AddPoints(int points)
        {
            this.points += points;
        }

        public int GetCostByCategory(Category category)
        {
            int cost = 0;
            foreach (var product in products)
            {
                if(product.category == category)
                {
                    cost += product.price;
                }
            }
            return cost;
        }
    }
}