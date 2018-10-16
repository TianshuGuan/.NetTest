using Contoso.Model.Models;

namespace Contoso.Data.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ContosoDbContext context) : base(context)
        {
        }
    }

    public interface IRoleRepository : IRepository<Role>
    {
    }
}