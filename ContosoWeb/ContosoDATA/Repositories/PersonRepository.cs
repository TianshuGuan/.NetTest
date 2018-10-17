using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoDATA.DAL;
using ContosoModels.Models;

namespace ContosoData.Repositories
{
   public class PersonRepository:GenericRepository<Person>,IPersonRepository
    {
        public PersonRepository(ContosoDBContext context) : base(context)
        {
        }
    }

    public interface IPersonRepository:IRepository<Person>
    {
        
    }
}
