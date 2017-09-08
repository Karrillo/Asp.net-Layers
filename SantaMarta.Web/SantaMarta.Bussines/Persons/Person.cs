using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Persons
{
    public class PersonCore : IPersonCore
    {
        private readonly IPersonRepository _personRepo;
        public PersonCore(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }
        public Person GetById(int id)
        {
            return _personRepo.GetById(id);
        }

        public List<Person> GetAll()
        {
            return _personRepo.GetAll();
        }

        public void Create(Person input)
        {
            _personRepo.Create(input);
        }

        public void Update(Person input)
        {
            _personRepo.Update(input);
        }

        public void Delete(int id)
        {
            _personRepo.Delete(id);
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
