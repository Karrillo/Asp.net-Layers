using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;
using SantaMarta.Data.Models.Sales;


namespace SantaMarta.DataAccess.SaleAccess
{
    public class SaleAccess
    {
        ContextDb db = new ContextDb();

        public List<Sales> GetAll()
        {
            return null;
        }

        public Sales GetById(int id)
        {
            return null;
        }

        public bool Update(Sales user)
        {
            return true;
        }

        public int Create(Sales sales)
        {
            return db.Insert_Sale(sales);
        }

        public int Delete(int id)
        {
            return db.Delete_Sale(id);
        }
    }
}
