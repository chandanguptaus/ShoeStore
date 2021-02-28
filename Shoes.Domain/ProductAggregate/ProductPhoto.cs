using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoes.Domain.ProductAggregate
{
  public class ProductPhoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Photo_id { get; set; }
        [Required]
        public String Source { get; set; }
        [Required]
        public String Alt { get; set; }
        public int Product_id { get; set; }

        public virtual Product Product { get; set; }
    }
}