using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public Custumer Custumer { get; set; }
       
    }
}
