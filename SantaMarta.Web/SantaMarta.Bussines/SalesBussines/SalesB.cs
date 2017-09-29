using SantaMarta.Data.Models.Sales;
using SantaMarta.DataAccess.SaleAccess;
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

        public int Delete(int id)
        {
            return saleAccess.Delete(id);
        }

        public List<Sales> GetAll()
        {
            return saleAccess.GetAll();
        }

        public Sales GetById(int id)
        {
            return saleAccess.GetById(id);
        }

        public bool Update(Sales input)
        {
            return saleAccess.Update(input);
        }
    }
}

