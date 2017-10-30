using System.Collections.Generic;
using SantaMarta.Data.Models.Sales;
using System;

namespace SantaMarta.Bussines.SalesBussines
{
    public interface ISalesB
    {
        int Create(Sales input);
        int Update(Sales input);
        int Delete(Int64 id);
        List<Sales> GetById(Int64 id);
        List<Sales> GetAll();
    }
}
