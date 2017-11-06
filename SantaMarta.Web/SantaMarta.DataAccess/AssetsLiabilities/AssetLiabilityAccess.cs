using System.Collections.Generic;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.DataAccess.Entity;
using System;
using System.Linq;
using SantaMarta.Data.Store_Procedures;

namespace SantaMarta.DataAccess.AssetLiabilityAccess
{
    public class AssetsLiabilityAccess
    {
        private ContextDb db;

        public AssetsLiabilityAccess()
        {
            db = new ContextDb();
        }

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

        public int CreateCredit(AssetsLiabilities assetsLiabilities)
        {
            return db.Insert_AssetLiability_Credit(assetsLiabilities);
        }

        public int Delete(int id)
        {
            return db.Delete_AssetLiability(id);
        }

        public Decimal? TotalSum(string dateStart, string dateEnd, bool type)
        {
            Decimal? total = db.Date_Sum_AssetLiability(dateStart, dateEnd, type);
            if (total == null)
            {
                total = 0;
            }
            return total;
        }

        public List<AssetsLiabilities> GetAllDate(String dateStart, String dateEnd)
        {
            return db.Date_AssetLiability(dateStart, dateEnd);
        }

        public List<AssetsLiabilities> GetByIdInvoinces(Int64 id)
        {
            return db.View_Invoice_AssetLiability(id);
        }
    }
}
