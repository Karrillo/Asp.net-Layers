using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;
using SantaMarta.Data.Models.Products;
using System.Linq;
using System;
using SantaMarta.Data.Store_Procedures;

namespace SantaMarta.DataAccess.ProductAccess
{
    public class ProductAccess
    {
        private ContextDb db;

        public ProductAccess()
        {
            db = new ContextDb();
        }

        //Get All Products Own
        public List<Products> GetAll()
        {
            List<Products> products = new List<Products>();
            try
            {
                products = db.List_Products_SM().ToList();
                return products;
            }
            catch (Exception)
            {
                return products;
            }
        }

        //Get All Products Own Deleted
        public List<List_Products_Deleted> GetAllDelete()
        {
            List<List_Products_Deleted> products = new List<List_Products_Deleted>();
            try
            {
                products = db.List_Products_Deleted().ToList();
                return products;
            }
            catch (Exception)
            {
                return products;
            }
        }

        //Get Products Own
        public Products GetById(Int64 id)
        {
            Products products = new Products();
            try
            {
                return db.View_Product(id);
            }
            catch (Exception)
            {
                return products;
            }
        }

        //Update Products Own
        public int Update(Products products, Int64 id)
        {
            try
            {
                String code = db.Check_CodeProduct(products.Code);

                if (code == null || code == GetById(id).Code)
                {
                    db.Update_Product(products, id);
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

        //Create Products Own
        public int Create(Products products)
        {
            try
            {
                if (db.Check_CodeProduct(products.Code) == null)
                {
                    db.Insert_Product_SM(products);
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

        //Delete Products Own
        public int Delete(int id)
        {
            try
            {
                db.Delete_Product(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Restore Products Own
        public int Restore(int id)
        {
            try
            {
                db.Restore_Product(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
