using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Persons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IRepository _repository;
        private const string PersonNoExists = "Person does not exist!";

        public PersonRepository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(Person input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<Person>(id);
        }

        public Person GetById(int id)
        {
            var person = _repository.GetById<Person>(id);

            if (person == null)
            {
                throw new Exception(PersonNoExists);
            }

            return person;
        }

        public List<Person> GetAll()
        {
            var person = _repository.GetAll<Person>().ToList();

            return person;
        }

        public void Update(Person input)
        {
            var person = _repository.GetById<Person>(input.Id);
            if (person == null)
            {
                throw new Exception(PersonNoExists);
            }
            _repository.Update(input);
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

