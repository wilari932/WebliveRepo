using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Product
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Isavalible { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
