using File = OnionCamp.Domain.Entities.File;

namespace OnionCamp.Application.Repositories.EntityRepositories
{
    public interface IFileWriteRepository : IWriteRepository<File>
    {
    }
}
