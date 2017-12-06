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

        //Get All AssetsLiabilities
        public List<AssetsLiabilities> GetAll()
        {
            List<AssetsLiabilities> assetsLiabilities = new List<AssetsLiabilities>();
            try
            {
                assetsLiabilities = db.All_AssetsLiabilities().ToList();
                return assetsLiabilities;
            }
            catch (Exception)
            {
                return assetsLiabilities;
            }
        }

        //Get AssetsLiabilities
        public AssetsLiabilities GetById(Int64 id)
        {
            AssetsLiabilities assetsLiabilities = new AssetsLiabilities();
            try
            {
                return db.View_AssetLiability(id);

            }
            catch (Exception)
            {
                return assetsLiabilities;
            }
        }

        //Update AssetsLiabilities
        public int Update(AssetsLiabilities assetsLiabilities)
        {
            return 0;
        }

        //Create AssetsLiabilities
        public int Create(AssetsLiabilities assetsLiabilities)
        {
            try
            {
                db.Insert_AssetLiability(assetsLiabilities);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Create AssetsLiabilities on invoices
        public int CreateCredit(AssetsLiabilities assetsLiabilities)
        {
            try
            {
                Check_Payment payment = db.Check_Payment(assetsLiabilities.IdInvoice ?? default(int), assetsLiabilities.Type);

                Decimal debt = (payment.Total ?? 0) - (payment.Rode ?? 0);

                if (assetsLiabilities.Rode <= debt)
                {
                    db.Insert_AssetLiability_Credit(assetsLiabilities);
                    return 200;

                }
                else
                {
                    return 400;
                }
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Delete AssetsLiabilities
        public int Delete(int id)
        {
            try
            {
                db.Delete_AssetLiability(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Get Total AssetsLiabilities
        public Decimal? TotalSum(string dateStart, string dateEnd, bool type)
        {
            try
            {
                Decimal? total = db.Date_Sum_AssetLiability(dateStart, dateEnd, type);
                if (total == null)
                {
                    total = 0;
                }
                return total;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Get All AssetsLiabilities by Date
        public List<AssetsLiabilities> GetAllDate(String dateStart, String dateEnd)
        {
            List<AssetsLiabilities> assetsLiabilities = new List<AssetsLiabilities>();

            try
            {
                assetsLiabilities = db.Date_AssetLiability(dateStart, dateEnd);
                return assetsLiabilities;
            }
            catch (Exception)
            {
                return assetsLiabilities;
            }
        }

        //Get AssetsLiabilities
        public List<AssetsLiabilities> GetByIdInvoinces(Int64 id)
        {
            List<AssetsLiabilities> assetsLiabilities = new List<AssetsLiabilities>();
            try
            {
                assetsLiabilities = db.View_Invoice_AssetLiability(id);
                return assetsLiabilities;
            }
            catch (Exception)
            {
                return assetsLiabilities;
            }
        }
    }
}
