using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch6_EssentialTools.Models
{
    public class ShoppingCart
    {
        /* private LinqValueCalculator calc;
         public ShoppingCart(LinqValueCalculator calcParam)
         {
             calc = calcParam;
         }*/
        private IValueCalculator calc;
        public ShoppingCart(IValueCalculator calcParam)
        {
            calc = calcParam;
        }
        public IEnumerable<Product> Products { get; set; }
        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}