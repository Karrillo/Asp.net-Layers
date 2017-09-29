using SantaMarta.Data.Models.Details;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.DetailsBussines
{
    public interface IDetailsB
    {
        int Create(Int64 id);
        bool Update(Details input);
        bool Delete(int id);
        Details GetById(int id);
        List<Details> GetAll();
    }
}
