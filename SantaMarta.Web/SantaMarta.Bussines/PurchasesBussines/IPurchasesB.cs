using SantaMarta.Data.Models.Purchases;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.PurchasesBussines
{
    public interface IPurchasesB
    {
        int Create(Purchases input);
        int Update(Purchases input);
        int Delete(Int64 id);
        List<Purchases> GetById(Int64 id);
        List<Purchases> GetAll();
    }
}
