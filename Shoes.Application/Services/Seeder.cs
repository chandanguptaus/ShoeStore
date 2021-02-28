using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shoes.Application.Services.Contract;
using Shoes.Domain.BrandAggregate;
using Shoes.Domain.CategoryAgggregate;
using Shoes.Domain.ColorAggregate;
using Shoes.Domain.PersonAgggregate;
using Shoes.Domain.ProductAggregate;
using Shoes.Domain.SizeAggregate;
using Shoes.Persistence;

namespace Shoes.Application.Services
{
    public class Seeder
    {
        private IEnumerable<Brand> _brands;
        private IEnumerable<Category> _categories;
        private IEnumerable<Color> _colors;
        private IEnumerable<Size> _sizes;
        private IEnumerable<Person> _persons;
        private IEnumerable<Product> _products;
        private IEnumerable<ProductVariant> _productVariants;

        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        private readonly IPersonService _personService;
        private readonly IProductService _productService;
        private readonly IProductVariantService _productVariantService;
        private DataContext _context;
        public Seeder(IServiceFactory servicefactory, DataContext context)
        {
            _brandService = servicefactory.GetServiceInstance<IBrandService>();
            _categoryService = servicefactory.GetServiceInstance<ICategoryService>();
            _sizeService = servicefactory.GetServiceInstance<ISizeService>();
            _colorService = servicefactory.GetServiceInstance<IColorService>();
            _personService = servicefactory.GetServiceInstance<IPersonService>();

            _productService = servicefactory.GetServiceInstance<IProductService>();
            _productVariantService = servicefactory.GetServiceInstance<IProductVariantService>();
            _context = context;
        }

        // Populate the Initial Data in SQLLITE TABLES.
        public async Task SeedData()
        {
            await SeedBrands();  // Shoe BRANDS
            await SeedShoeCategories();  // Shoe Categories 
            await SeedColors();  // Shoe COlors
            await SeePerson();  // Men, Women, Kids
            await SeedSize();  // Shoe Sizes.
            await _context.SaveChangesAsync();  // Svae changes to database

            // Update 
            _brands = await _brandService.GetAll();
            _categories = await _categoryService.GetAll();
            _colors = await _colorService.GetAll();
            _sizes = await _sizeService.GetAll();
            _persons = await _personService.GetAll();

            await SeedProducts();  // Create Products
            await _context.SaveChangesAsync();

            _products = await _productService.GetAll();

            await SeedProductVariantColorAndSizes();  // Create Product Variants
        }


        #region  Brands
        // Seed Brands
        private async Task SeedBrands()
        {
            _brands = await _brandService.GetAll();
            if (_brands.Any()) return;

            _brands = new List<Brand>
            {
                new Brand {
                    Name = "Aldo",
                    Description = "Aldo Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                new Brand {
                    Name = "Nike",
                    Description = "Nike Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                               new Brand {
                    Name = "Rebook",
                    Description = "Rebook Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                }
             };
            await _brandService.AddRange(_brands); // Add Brands
        }
        #endregion
        // Seed Categories
        private async Task SeedShoeCategories()
        {
            _categories = await _categoryService.GetAll();
            if (_categories.Any()) return;

            _categories = new List<Category>
            {
                new Category {
                    Name = "Sport",
                    Description = "Sports Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                new Category {
                    Name = "Sneaker",
                    Description = "Sneaker Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                  new Category {
                    Name = "Formal",
                    Description = "Formal Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                 new Category {
                    Name = "Training",
                    Description = "Training Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                 new Category {
                    Name = "Walking",
                    Description = "Walking Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                 new Category {
                    Name = "Gym",
                    Description = "Gym Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                 new Category {
                    Name = "Casuals",
                    Description = "Casuals Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                 new Category {
                    Name = "DressWear",
                    Description = "DressWear Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                 new Category {
                    Name = "Sandals",
                    Description = "Sandals Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                 new Category {
                    Name = "Slippers",
                    Description = "Slippers Shoes",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                }
             };
            await _categoryService.AddRange(_categories); // Add Brands
        }
        private async Task SeedColors()
        {
            _colors = await _colorService.GetAll();
            if (_colors.Any()) return;

            _colors = new List<Color>
            {
                new Color {
                    Code = "Red",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                new Color {
                    Code = "Black",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                  new Color {
                    Code = "White",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
            };
            await _colorService.AddRange(_colors); // Add Brands
        }

        private async Task SeedSize()
        {
            _sizes = await _sizeService.GetAll();
            if (_sizes.Any()) return;
            _sizes = new List<Size>
            {
                new Size {
                    Number = 7.5F,
                    Description = "US 5.5",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
               new Size {
                    Number = 8.0F,
                    Description = "US 8.0",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                 new Size {
                     Number = 8.5F,
                    Description = "US 8.5",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
            };
            await _sizeService.AddRange(_sizes); // Add Brands
        }
        private async Task SeePerson()
        {
            _persons = await _personService.GetAll();
            if (_persons.Any()) return;
            _persons = new List<Person>
            {
                new Person {
                    Code = "M",
                    Name = "Men",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                new Person {
                    Code = "F",
                    Name = "Women",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
                 new Person {
                    Code = "K",
                    Name = "Kids",
                    IsActive = true,
                    ModifiedBy = "Seed",
                    ModifiedOn = DateTime.Now
                },
            };
            await _personService.AddRange(_persons); // Add Brands
        }
        private async Task SeedProducts()
        {
            _products = await _productService.GetAll();
            if (_products.Any()) return;

            var catid1 = _categories.FirstOrDefault(s => s.Name == "Training").Category_id;
            var brandid1 = _brands.FirstOrDefault(s => s.Name == "Nike").Brand_id;
            var personid1 = _persons.FirstOrDefault(s => s.Code == "M").Person_id;


            var catid2 = _categories.FirstOrDefault(s => s.Name == "Training").Category_id;
            var brandid2 = _brands.FirstOrDefault(s => s.Name == "Nike").Brand_id;
            var personid2 = _persons.FirstOrDefault(s => s.Code == "F").Person_id;


            var catid3 = _categories.FirstOrDefault(s => s.Name == "Walking").Category_id;
            var brandid3 = _brands.FirstOrDefault(s => s.Name == "Rebook").Brand_id;
            var personid3 = _persons.FirstOrDefault(s => s.Code == "M").Person_id;


            var catid4 = _categories.FirstOrDefault(s => s.Name == "Walking").Category_id;
            var brandid4 = _brands.FirstOrDefault(s => s.Name == "Rebook").Brand_id;
            var personid4 = _persons.FirstOrDefault(s => s.Code == "F").Person_id;


            _products = new List<Product>
              {
                    new Product{
                            Product_id = 1,
                            Category_id = catid1,
                            Brand_id = brandid1,
                            Person_id = personid1,
                            IsActive = true,
                            ModifiedBy = "Seed",
                            ModifiedOn = DateTime.Now
                     },
                      new Product{
                            Product_id = 2,
                            Category_id = catid2,
                            Brand_id = brandid2,
                            Person_id = personid2,
                            IsActive = true,
                            ModifiedBy = "Seed",
                            ModifiedOn = DateTime.Now
                     },
                        new Product{
                            Product_id = 3,
                            Category_id = catid3,
                            Brand_id = brandid3,
                            Person_id = personid3,
                            IsActive = true,
                            ModifiedBy = "Seed",
                            ModifiedOn = DateTime.Now
                     },
                      new Product{
                            Product_id = 4,
                            Category_id = catid4,
                            Brand_id = brandid4,
                            Person_id = personid4,
                            IsActive = true,
                            ModifiedBy = "Seed",
                            ModifiedOn = DateTime.Now
                     },
                };
            await _productService.AddRange(_products); // Add Brands

        }
        private async Task SeedProductVariantColorAndSizes()
        {
            _productVariants = await _productVariantService.GetAll();
            if (_productVariants.Any()) return;

            var productid = _products.Where(s => s.Brand.Name == "Nike" && s.Person.Code == "M" && s.Category.Name == "Training")
                           .FirstOrDefault().Product_id;
            var colorid = _colors.FirstOrDefault(s => s.Code == "Red").Color_id;
            var sizeid = _sizes.FirstOrDefault(s => s.Number == 7.5).Size_id;

            var productid1 = _products.Where(s => s.Brand.Name == "Nike" && s.Person.Code == "M" && s.Category.Name == "Training")
              .FirstOrDefault().Product_id;
            var colorid1 = _colors.FirstOrDefault(s => s.Code == "Red").Color_id;
            var sizeid1 = _sizes.FirstOrDefault(s => s.Number == 8.5).Size_id;

            var productid2 = _products.Where(s => s.Brand.Name == "Rebook" && s.Person.Code == "F" && s.Category.Name == "Walking")
                      .FirstOrDefault().Product_id;
            var colorid2 = _colors.FirstOrDefault(s => s.Code == "White").Color_id;
            var sizeid2 = _sizes.FirstOrDefault(s => s.Number == 8.0).Size_id;


            var productid3 = _products.Where(s => s.Brand.Name == "Rebook" && s.Person.Code == "M" && s.Category.Name == "Walking")
                      .FirstOrDefault().Product_id;
            var colorid3 = _colors.FirstOrDefault(s => s.Code == "White").Color_id;
            var sizeid3 = _sizes.FirstOrDefault(s => s.Number == 8.5).Size_id;

            _productVariants = new List<ProductVariant>
            {

                    new ProductVariant{
                            ProductVariant_Id = 1,
                            Product_id =   productid,
                            Color_id = colorid,
                            Size_id =  sizeid,
                            Quantity = 25,
                            RetailPrice = 85.5F,
                            Discount = 10.00F,
                     },
                      new ProductVariant{
                            ProductVariant_Id = 2,
                             Product_id =  productid1,
                            Color_id = colorid1,
                            Size_id = sizeid1,
                            Quantity = 25,
                            RetailPrice = 90F,
                            Discount = 5.0F,

                     },
                         new ProductVariant{
                               ProductVariant_Id = 3,
                             Product_id =  productid2,
                            Color_id = colorid2,
                            Size_id = sizeid2,
                             Quantity = 50,
                            RetailPrice = 100F,
                            Discount = 15.0F,
                     },
                         new ProductVariant{
                               ProductVariant_Id = 4,
                             Product_id =  productid3,
                            Color_id = colorid3,
                            Size_id = sizeid3,
                              Quantity = 45,
                            RetailPrice = 150F,
                            Discount = 25.0F,
                     },
                };
            await _productVariantService.AddRange(_productVariants); // Add Brands

        }

    }
}