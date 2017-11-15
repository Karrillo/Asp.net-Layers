using SantaMarta.Data.Models.Persons;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.PersonsBussines
{
    public interface IPersonsB
    {
        bool Create(Persons input);
        bool Update(Persons input);
        bool Delete(int id);
        Persons GetById(int id);
        List<Persons> GetAll();
    }
}
