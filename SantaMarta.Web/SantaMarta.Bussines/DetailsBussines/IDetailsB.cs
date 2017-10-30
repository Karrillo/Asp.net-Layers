using SantaMarta.Data.Models.Details;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.DetailsBussines
{
    public interface IDetailsB
    {
        Int64 Create(Int64 id);
        int Update(Details input);
        int Delete(Int64 id);
        Details GetById(Int64 id);
        List<Details> GetAll();
    }
}
