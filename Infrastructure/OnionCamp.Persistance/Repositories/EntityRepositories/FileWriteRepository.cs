using OnionCamp.Application.Repositories.EntityRepositories;
using OnionCamp.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = OnionCamp.Domain.Entities.File;

namespace OnionCamp.Persistance.Repositories.EntityRepositories
{
    public class FileWriteRepository : WriteRepository<File>, IFileWriteRepository
    {
        public FileWriteRepository(OnionCampDbContext context) : base(context)
        {
        }
    }
}
