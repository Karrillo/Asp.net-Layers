using LenguajesAvanzados.Mapper.Dtos.ConfigInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Mapper.Dtos.Persons
{
    public class PersonDto : Entity
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public string identification { get; set; }
    }
}
