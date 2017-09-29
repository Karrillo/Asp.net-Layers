using System.Collections.Generic;
using SantaMarta.Data.Models.Sales;

namespace SantaMarta.Bussines.SalesBussines
{
    public interface ISalesB
    {
        int Create(Sales input);
        bool Update(Sales input);
        int Delete(int id);
        Sales GetById(int id);
        List<Sales> GetAll();
    }
}
