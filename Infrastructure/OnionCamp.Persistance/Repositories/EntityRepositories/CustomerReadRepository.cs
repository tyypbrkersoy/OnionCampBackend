using OnionCamp.Application.Repositories.EntityRepositories;
using OnionCamp.Domain.Entities;
using OnionCamp.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCamp.Persistance.Repositories.EntityRepositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(OnionCampDbContext context) : base(context)
        {
        }
    }

}
