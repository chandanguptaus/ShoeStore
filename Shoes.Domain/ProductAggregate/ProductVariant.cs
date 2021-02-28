using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shoes.Domain.ColorAggregate;
using Shoes.Domain.SizeAggregate;
namespace Shoes.Domain.ProductAggregate
{
    public class ProductVariant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductVariant_Id { get; set; }
        public int Quantity { get; set; }
        public double RetailPrice { get; set; }
        public float Discount { get; set; }
        public int Product_id { get; set; }
        public byte Size_id { get; set; }
        public byte Color_id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
    }
}