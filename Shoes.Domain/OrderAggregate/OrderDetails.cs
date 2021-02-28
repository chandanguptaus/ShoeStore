using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shoes.Domain.ProductAggregate;

namespace Shoes.Domain.OrderAggregate
{
    public class OrderDetails
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Ordered_id { get; set; }
        public long ProductVariant_Id { get; set; }
        public int Order_Id { get; set; }
        public int Amount { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public Order Order { get; set; }
    }
}