using ContosoDATA.DAL;
using ContosoModels.Models;

namespace ContosoData.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ContosoDBContext context) : base(context)
        {
        }
    }

    public interface IRoleRepository : IRepository<Role>
    {
    }
}