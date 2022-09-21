using OnionCamp.Application.Repositories.EntityRepositories;
using OnionCamp.Domain.Entities;
using OnionCamp.Persistance.Contexts;

namespace OnionCamp.Persistance.Repositories.EntityRepositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(OnionCampDbContext context) : base(context)
        {
        }
    }


}
