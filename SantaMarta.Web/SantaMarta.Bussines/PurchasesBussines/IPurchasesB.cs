using SantaMarta.Data.Models.Purchases;
using System.Collections.Generic;

namespace SantaMarta.Bussines.PurchasesBussines
{
    public interface IPurchasesB
    {
        bool Create(Purchases input);
        bool Update(Purchases input);
        bool Delete(int id);
        Purchases GetById(int id);
        List<Purchases> GetAll();
    }
}
