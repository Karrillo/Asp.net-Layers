using LenguajesAvanzados.Core.Accounts;
using LenguajesAvanzados.Core.AssetsLiabilities;
using LenguajesAvanzados.Core.Categories;
using LenguajesAvanzados.Core.Clients;
using LenguajesAvanzados.Core.Invoices;
using LenguajesAvanzados.Core.Persons;
using LenguajesAvanzados.Core.Products;
using LenguajesAvanzados.Core.Providers;
using LenguajesAvanzados.Core.Purchases;
using LenguajesAvanzados.Core.Sales;
using LenguajesAvanzados.Core.SubCategories;
using LenguajesAvanzados.Core.Users;
using System.Data.Entity;

namespace LenguajesAvanzados.Repository.EntityFramework
{
    public class DBContext : DbContext
    {
        public virtual IDbSet<Person> Persons { get; set; }
        public virtual IDbSet<Client> Clients { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Provider> Providers { get; set; }
        public virtual IDbSet<Product> Products { get; set; }
        public virtual IDbSet<Sale> Sales { get; set; }
        public virtual IDbSet<Purchase> Purchases { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<SubCategory> SubCategories { get; set; }
        public virtual IDbSet<Invoice> Invoices { get; set; }
        public virtual IDbSet<Account> Accounts { get; set; }
        public virtual IDbSet<AssetLiability> AssetsLiabilities { get; set; }



        public DBContext()
            : base("Default") 
        {
        }
    }
}
