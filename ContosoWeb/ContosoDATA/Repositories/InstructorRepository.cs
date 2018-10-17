using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoDATA.DAL;
using ContosoModels.Models;

namespace ContosoData.Repositories
{
   public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ContosoDBContext context) : base(context)
        {
        }
    }

    public interface IInstructorRepository : IRepository<Instructor>
    {
        
    }
}
