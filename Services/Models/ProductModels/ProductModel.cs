using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models.ProductModels
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
