using SantaMarta.Data.Models.Accounts;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Models.Categories;
using SantaMarta.Data.Models.Clients;
using SantaMarta.Data.Models.Details;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Models.Providers;
using SantaMarta.Data.Models.Purchases;
using SantaMarta.Data.Models.Sales;
using SantaMarta.Data.Models.SubCategories;
using SantaMarta.Data.Models.Users;
using System.Data.Entity;
using System.Linq;

namespace SantaMarta.DataAccess.Entity
{
    class ContextDb : DbContext
    {
        public ContextDb() : base(nameOrConnectionString: "PostgreSQL") {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Providers> Providers { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<SubCategories> SubCategories { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<AssetsLiabilities> AssetsLiabilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual Users Check_Users(string nickname, string password)
        {
            var nicknameParameter = nickname != null ?
                new Npgsql.NpgsqlParameter("nickname", nickname) :
                new Npgsql.NpgsqlParameter("nickname", typeof(string));

            var passwordParameter = password != null ?
                new Npgsql.NpgsqlParameter("password", password) :
                new Npgsql.NpgsqlParameter("password", typeof(string));

            return this.Database.SqlQuery<Users>("select * from check_User (@nickname, @password)", nicknameParameter, passwordParameter).FirstOrDefault();
        }

    }
}
