using LenguajesAvanzados.Core.ConfigInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LenguajesAvanzados.Core.Categories
{
    public class Category : Entity
    {
        public string Type { get; set; }
    }
}