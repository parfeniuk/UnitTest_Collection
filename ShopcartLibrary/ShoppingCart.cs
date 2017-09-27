﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopcartLibrary
{
    public class ShoppingCart
    {
        private LinqValueCalculator calc;

        public ShoppingCart(LinqValueCalculator calcParam)
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
