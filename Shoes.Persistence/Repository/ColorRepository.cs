using Shoes.Domain.ColorAggregate;

namespace Shoes.Persistence.Repository
{
    public class ColorRepository : GenericRepository<Color> , IColorRepository
    {
        public ColorRepository(DataContext context) : base(context)
        {
            
        }
        
    }
}