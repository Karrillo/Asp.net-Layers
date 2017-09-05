using LenguajesAvanzados.Core.ConfigInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LenguajesAvanzados.Core.Users
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Type { get; set; }
        public bool State { get; set; }
    }
}