
using Shoes.Application.Services.Contract;
using Shoes.Application.Services.Implementation;
using Shoes.Domain.BrandAggregate;
using Shoes.Domain.CategoryAgggregate;
using Shoes.Domain.ColorAggregate;
using Shoes.Domain.PersonAgggregate;
using Shoes.Domain.ProductAggregate;
using Shoes.Domain.SizeAggregate;
using Shoes.Persistence;
using Shoes.Persistence.Repository;
using Unity;
using Unity.Injection;

namespace Shoes.Application.Services
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IUnityContainer container = new UnityContainer();
        private readonly DataContext _context;
        public ServiceFactory(DataContext context)
        {
            _context = context;  // Set database Context.
            // Register Services.
            this.container.RegisterType<IBrandService, BrandService>();
            this.container.RegisterType<ICategoryService, CategoryService>();
            this.container.RegisterType<ISizeService, SizeService>();
            this.container.RegisterType<IColorService, ColorService>();
            this.container.RegisterType<IPersonService, PersonService>();
            // Product Service
            this.container.RegisterType<IProductService, ProductService>();
            this.container.RegisterType<IProductVariantService, ProductVariantService>();


            // Register Service Repositories depedencies to container.
            this.container.RegisterType<IBrandRepository, BrandRepository>(new InjectionConstructor(_context));
            this.container.RegisterType<ISizeRepository, SizeRepository>(new InjectionConstructor(_context));
            this.container.RegisterType<IPersonRepository, PersonRepository>(new InjectionConstructor(_context));
            this.container.RegisterType<IColorRepository, ColorRepository>(new InjectionConstructor(_context));
            this.container.RegisterType<ICategoryRepository, CategoryRepository>(new InjectionConstructor(_context));

            // Product and Product Variation Repository
            this.container.RegisterType<IProductRepository, ProductRepository>(new InjectionConstructor(_context));
            this.container.RegisterType<IProductVariantRepository, ProductVariantRepository>(new InjectionConstructor(_context));
        }
        public T GetServiceInstance<T>()
        {
            return (T)this.container.Resolve(typeof(T));
        }
    }
}