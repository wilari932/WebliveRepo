using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Custumer
    {
        public Custumer()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelefonNummer { get; set; }
        public string Adress { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
