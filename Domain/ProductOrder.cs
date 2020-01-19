using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class ProductOrder
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; set; }
        public Order   Order  { get; set; }
    }
}
