using OnionCamp.Application.Repositories.EntityRepositories;
using OnionCamp.Domain.Entities;
using OnionCamp.Persistance.Contexts;

namespace OnionCamp.Persistance.Repositories.EntityRepositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(OnionCampDbContext context) : base(context)
        {
        }
    }


}
