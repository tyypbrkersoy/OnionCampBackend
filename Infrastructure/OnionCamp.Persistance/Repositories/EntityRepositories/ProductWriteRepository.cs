using OnionCamp.Application.Repositories.EntityRepositories;
using OnionCamp.Domain.Entities;
using OnionCamp.Persistance.Contexts;

namespace OnionCamp.Persistance.Repositories.EntityRepositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(OnionCampDbContext context) : base(context)
        {
        }
    }


}
