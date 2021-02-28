using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoes.Domain.OrderAggregate
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_id { get; set; }
        public DateTime Time { get; set; }
        [Required]
        public String UserId { get; set; }
        public string User { get; set; }
        public ICollection<OrderDetails> Ordered { get; set; }

    }
}