using OnionCamp.Application.Repositories.EntityRepositories;
using OnionCamp.Domain.Entities;
using OnionCamp.Persistance.Contexts;

namespace OnionCamp.Persistance.Repositories.EntityRepositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(OnionCampDbContext context) : base(context)
        {
        }
    }


}
