using ContosoData.Repositories;
using ContosoModels.Models;
using System;
using System.Collections.Generic;

namespace ContosoService.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
           
        }

        public Person GetPersonByUserName(string username)
        {
            var person = _personRepository.Get(p => p.Email == username);
            return person;
        }

        public Person GetValidPerson(string username, string password)
        {
            var person = _personRepository.Get(p => p.Email == username && p.PassWord == password);
            return person;
        }

        public void AddPerson(Person person, List<string> role)
        {
            _personRepository.Add(person);
            _personRepository.SaveChanges();
        }

        public IEnumerable<Person> GetPeopleByRole(int roleId)
        {
            return _personRepository.FindByInclude(r => r.Id == roleId, p => p.Roles);
        }
    }

    public interface IPersonService
    {
        Person GetPersonByUserName(string username);
        Person GetValidPerson(string username, string password);
        void AddPerson(Person person, List<string> roles);
        IEnumerable<Person> GetPeopleByRole(int roleId);
    }
}