using OnionCamp.Application.Repositories.EntityRepositories;
using OnionCamp.Domain.Entities;
using OnionCamp.Persistance.Contexts;

namespace OnionCamp.Persistance.Repositories.EntityRepositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(OnionCampDbContext context) : base(context)
        {
        }
    }


}
