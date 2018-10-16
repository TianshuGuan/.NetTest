using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Model;

namespace Contoso.Data.Repositories
{
   public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ContosoDbContext context) : base(context)
        {
        }
    }

    public interface IInstructorRepository : IRepository<Instructor>
    {
        
    }
}
