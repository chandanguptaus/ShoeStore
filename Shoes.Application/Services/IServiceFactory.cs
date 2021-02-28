namespace Shoes.Application.Services
{
    public interface IServiceFactory
    {
           T GetServiceInstance<T>();
    }
}