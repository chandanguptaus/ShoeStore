using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shoes.Domain.ProductAggregate;

namespace Shoes.Domain.PersonAgggregate
{
    public class Person
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Person_id { get; set; }

        [StringLength(5)]
        [Required]
        public string Code {get;set;}

        [StringLength(20)]
        public string Name {get;set;}
        public bool IsActive {get;set;}
        public string ModifiedBy {get;set;}
        public DateTime? ModifiedOn {get;set;}

        public virtual ICollection<ProductVariant> Products { get; set; }
    }
}