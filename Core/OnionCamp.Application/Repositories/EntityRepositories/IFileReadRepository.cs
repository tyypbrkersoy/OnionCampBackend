using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = OnionCamp.Domain.Entities.File;

namespace OnionCamp.Application.Repositories.EntityRepositories
{
    public interface IFileReadRepository : IReadRepository<File>
    {
    }
}
