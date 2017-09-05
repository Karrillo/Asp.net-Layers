using LenguajesAvanzados.Mapper.Dtos.ConfigInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Mapper.Dtos.Clients
{
    public class ClientDto : Entity
    {
        public bool State { get; set; }
        public int? IdPerson { get; set; }
    }
}
