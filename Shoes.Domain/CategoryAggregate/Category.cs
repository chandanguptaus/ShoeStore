using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shoes.Domain.ProductAggregate;


namespace Shoes.Domain.CategoryAgggregate
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Category_id {get;set;}

        [StringLength(20)]
        public string Name {get;set;}

        [StringLength(100)]
        public string Description {get;set;}
        public bool IsActive {get;set;}
        public string ModifiedBy {get;set;}
        public DateTime? ModifiedOn {get;set;}

        public virtual ICollection<ProductVariant> Products { get; set; }

    }
}