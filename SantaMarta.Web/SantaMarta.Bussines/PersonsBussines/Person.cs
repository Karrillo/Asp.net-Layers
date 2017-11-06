using SantaMarta.Data.Models.Persons;
using SantaMarta.DataAccess.PersonAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.PersonsBussines
{
    public class PersonsB : IPersonsB
    {
        private PersonAccess personAccess = new PersonAccess();

        public bool Create(Persons input)
        {
            return personAccess.Create(input);
        }

        public String CheckIdentification(string identification)
        {
            return personAccess.CheckIdentification(identification);
        }

        public String CheckCode(string code)
        {
            return personAccess.CheckCode(code);
        }

        public bool Delete(int id)
        {
            return personAccess.Delete(id);
        }

        public List<Persons> GetAll()
        {
            return personAccess.GetAll();
        }

        public Persons GetById(int id)
        {
            return personAccess.GetById(id);
        }

        public bool Update(Persons input)
        {
            return personAccess.Update(input);
        }
    }
}
