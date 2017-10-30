using SantaMarta.Data.Models.Sales;
using SantaMarta.DataAccess.SaleAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.SalesBussines
{
    public class SalesB : ISalesB
    {
        private SaleAccess saleAccess = new SaleAccess();

        public int Create(Sales input)
        {
            return saleAccess.Create(input);
        }

        public int Delete(Int64 id)
        {
            return saleAccess.Delete(id);
        }

        public List<Sales> GetAll()
        {
            return saleAccess.GetAll();
        }

        public List<Sales> GetById(Int64 id)
        {
            return saleAccess.GetById(id);
        }

        public int Update(Sales input)
        {
            return saleAccess.Update(input);
        }
    }
}

