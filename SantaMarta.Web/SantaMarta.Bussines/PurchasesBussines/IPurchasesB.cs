using SantaMarta.Data.Models.Purchases;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.PurchasesBussines
{
    public interface IPurchasesB
    {
        int Create(Purchases input);
        int Update(Purchases input);
        int Delete(Int64 id);
        List<Views_Invoinces_Products> GetById(Int64 id);
        List<Purchases> GetAll();
    }
}
