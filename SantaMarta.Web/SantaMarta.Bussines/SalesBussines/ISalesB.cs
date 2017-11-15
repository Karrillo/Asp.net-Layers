using System.Collections.Generic;
using SantaMarta.Data.Models.Sales;
using System;
using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Store_Procedures;

namespace SantaMarta.Bussines.SalesBussines
{
    public interface ISalesB
    {
        int Create(Sales input);
        int Update(Sales input);
        int Delete(Int64 id);
        List<Views_Invoinces_Products> GetById(Int64 id);
        List<Sales> GetAll();
    }
}
