using LenguajesAvanzados.Core.ConfigInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LenguajesAvanzados.Core.Persons
{
    public class Person : Entity
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