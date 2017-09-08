using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Persons
{
    public interface IPersonCore
    {
        void Create(Person input);
        void Update(Person input);
        void Delete(int id);
        Person Get(int id);
        Person GetById(int id);
        List<Person> GetAll();
    }
}
