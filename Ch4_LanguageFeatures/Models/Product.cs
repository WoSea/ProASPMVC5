using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch4_LanguageFeatures.Models
{
    public class Product
    {
        private string name;
        private int productID;
        private string description;
        private decimal price;
        private string category;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string Name
        {
            get { return ProductID+ name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
}