using Microsoft.EntityFrameworkCore;
using Shoes.Domain.BrandAggregate;
using Shoes.Domain.CategoryAgggregate;
using Shoes.Domain.ColorAggregate;
using Shoes.Domain.PersonAgggregate;
using Shoes.Domain.ProductAggregate;
using Shoes.Domain.SizeAggregate;

namespace Shoes.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Size>().ToTable("Size");
            modelBuilder.Entity<Color>().ToTable("Color");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductVariant>().ToTable("ProductVariant");

            modelBuilder.Entity<Product>()
                .HasKey(c => new { c.Category_id, c.Brand_id, c.Person_id });  // Enforcing Unique key 

            modelBuilder.Entity<ProductVariant>()
                    .HasKey(c => new { c.Product_id, c.Color_id, c.Size_id });  // Enforcing Unique key  on Product Variant

        }

    }
}