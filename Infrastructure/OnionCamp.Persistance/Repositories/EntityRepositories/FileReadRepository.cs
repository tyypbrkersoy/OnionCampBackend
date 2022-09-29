using OnionCamp.Application.Repositories;
using OnionCamp.Application.Repositories.EntityRepositories;
using OnionCamp.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCamp.Persistance.Repositories.EntityRepositories
{
    public class FileReadRepository : ReadRepository<OnionCamp.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(OnionCampDbContext context) : base(context)
        {
        }
    }
}
