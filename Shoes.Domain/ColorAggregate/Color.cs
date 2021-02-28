using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shoes.Domain.ProductAggregate;

namespace Shoes.Domain.ColorAggregate
{
    public class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Color_id { get; set; }

        [StringLength(10)]
        [Required]
        public string Code { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<ProductVariant> Products { get; set; }
    }
}