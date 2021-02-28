using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shoes.Domain.BrandAggregate;
using Shoes.Domain.CategoryAgggregate;
using Shoes.Domain.PersonAgggregate;

namespace Shoes.Domain.ProductAggregate
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Product_id { get; set; }
        public byte Category_id { get; set; }
        public byte Brand_id { get; set; }
        public byte Person_id { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Person Person { get; set; }
        public bool IsActive {get;set;}
        public string ModifiedBy {get;set;}
        public DateTime? ModifiedOn {get;set;}
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }

    }
}