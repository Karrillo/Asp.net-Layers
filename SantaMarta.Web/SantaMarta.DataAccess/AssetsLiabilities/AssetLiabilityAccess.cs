using System.Collections.Generic;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.DataAccess.Entity;
using System;
using System.Linq;

namespace SantaMarta.DataAccess.AssetLiabilityAccess
{
    public class AssetsLiabilityAccess
    {
        ContextDb db = new ContextDb();

        public List<AssetsLiabilities> GetAll()
        {
            List<AssetsLiabilities> assetsLiabilities = db.All_AssetsLiabilities().ToList();
            return assetsLiabilities;
        }

        public AssetsLiabilities GetById(int id)
        {
            return db.View_AssetLiability(id);
        }

        public int Update(AssetsLiabilities assetsLiabilities)
        {
            return 0;
        }

        public int Create(AssetsLiabilities assetsLiabilities)
        {
            return db.Insert_AssetLiability(assetsLiabilities);
        }

        public int Delete(int id)
        {
            return db.Delete_AssetLiability(id);
        }
        public decimal TotalSum(string dateStart, string dateEnd, bool type)
        {
            return db.Date_Sum_AssetLiability(dateStart, dateEnd, type);
        }
        public List<AssetsLiabilities> GetAllDate(String dateStart, String dateEnd)
        {
            return db.Date_AssetLiability(dateStart, dateEnd);
        }
    }
}
