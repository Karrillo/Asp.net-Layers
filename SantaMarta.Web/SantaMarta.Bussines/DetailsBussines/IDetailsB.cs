using SantaMarta.Data.Models.Details;
using System.Collections.Generic;

namespace SantaMarta.Bussines.DetailsBussines
{
    public interface IDetailsB
    {
        bool Create(Details input);
        bool Update(Details input);
        bool Delete(int id);
        Details GetById(int id);
        List<Details> GetAll();
    }
}
