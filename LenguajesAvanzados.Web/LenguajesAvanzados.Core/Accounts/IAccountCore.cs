using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Accounts
{
    public interface IAccountCore
    {
        void Create(Account input);
        void Update(Account input);
        void Delete(int id);
        Account Get(int id);
        Account GetById(int id);
        List<Account> GetAll();
    }
}
