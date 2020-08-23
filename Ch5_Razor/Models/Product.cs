﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch5_Razor.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
}