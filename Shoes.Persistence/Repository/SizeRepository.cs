using System.Collections.Generic;
using Shoes.Domain.SizeAggregate;

namespace Shoes.Persistence.Repository
{
    public class SizeRepository : GenericRepository<Size> , ISizeRepository
    {
        public SizeRepository(DataContext context) : base(context)
        {
            
        }


    }
}