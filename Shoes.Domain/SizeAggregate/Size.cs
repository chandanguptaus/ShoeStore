using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shoes.Domain.ProductAggregate;

namespace Shoes.Domain.SizeAggregate
{
    public class Size
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Size_id { get; set; }
        
        [Required]
        public float Number { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ICollection<ProductVariant> Products { get; set; }
    }
}