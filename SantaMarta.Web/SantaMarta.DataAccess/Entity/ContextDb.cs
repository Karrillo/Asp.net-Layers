using SantaMarta.Data.Models.Accounts;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Models.Categories;
using SantaMarta.Data.Models.Clients;
using SantaMarta.Data.Models.Details;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.Data.Models.Mails;
using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Models.Providers;
using SantaMarta.Data.Models.Purchases;
using SantaMarta.Data.Models.Sales;
using SantaMarta.Data.Models.SubCategories;
using SantaMarta.Data.Models.Users;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SantaMarta.DataAccess.Entity
{
    class ContextDb : DbContext
    {
        public ContextDb() : base(nameOrConnectionString: "PostgreSQL")
        {
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
        //public DbSet<Mails> Mails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        //clients
        #region Clients
        public virtual List<Int64> ClientsAll()
        {
            return this.Database.SqlQuery<Int64>("select * from ClientsAll ()").ToList();
        }
        public virtual String Check_Identification(string identification)
        {
            var identificationParameter = identification != null ?
                new Npgsql.NpgsqlParameter("identification", identification) :
                new Npgsql.NpgsqlParameter("identification", typeof(string));

            return this.Database.SqlQuery<String>("select * from Check_Identification (@identification)", identificationParameter).FirstOrDefault();
        }
        public virtual String Check_CodePersons(string code)
        {
            var codeParameter = code != null ?
                new Npgsql.NpgsqlParameter("code", code) :
                new Npgsql.NpgsqlParameter("code", typeof(string));

            return this.Database.SqlQuery<String>("select * from Check_CodePersons (@code)", codeParameter).FirstOrDefault();
        }
        public virtual int Insert_Client(Persons person)
        {
            var NameParameter = person.Name != null ?
                new Npgsql.NpgsqlParameter("Name", person.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var FirstNameParameter = person.FirstName != null ?
                new Npgsql.NpgsqlParameter("FirstName", person.FirstName) :
                new Npgsql.NpgsqlParameter("FirstName", typeof(string));

            var SecondNameParameter = person.SecondName != null ?
                new Npgsql.NpgsqlParameter("SecondName", person.SecondName) :
                new Npgsql.NpgsqlParameter("SecondName", typeof(string));

            var EmailParameter =
                new Npgsql.NpgsqlParameter("Email", person.Email);

            var PhoneParameter =
                new Npgsql.NpgsqlParameter("Phone", person.Phone);

            var CellPhoneParameter =
                new Npgsql.NpgsqlParameter("CellPhone", person.CellPhone);

            var AddressParameter =
                new Npgsql.NpgsqlParameter("Address", person.Address);

            var identificationParameter =
                new Npgsql.NpgsqlParameter("identification", person.Identification);

            var NameCompanyParameter = person.NameCompany != null ?
                new Npgsql.NpgsqlParameter("NameCompany", person.NameCompany) :
                new Npgsql.NpgsqlParameter("NameCompany", typeof(string));

            var CodeParameter = person.Code != null ?
               new Npgsql.NpgsqlParameter("Code", person.Code) :
               new Npgsql.NpgsqlParameter("Code", typeof(string));

            return this.Database.ExecuteSqlCommand("select * from Insert_Client (@Code, @Name, @FirstName, @SecondName, @Phone, " +
                "@CellPhone, @Email, @Address, @Identification, @NameCompany)", CodeParameter, NameParameter, FirstNameParameter,
                SecondNameParameter, EmailParameter, PhoneParameter, CellPhoneParameter, AddressParameter, identificationParameter,
                NameCompanyParameter);
        }
        public virtual int update_Client(Persons person, Int64 IdPerson)
        {
            var NameParameter = person.Name != null ?
                new Npgsql.NpgsqlParameter("Name", person.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var FirstNameParameter = person.FirstName != null ?
                new Npgsql.NpgsqlParameter("FirstName", person.FirstName) :
                new Npgsql.NpgsqlParameter("FirstName", typeof(string));

            var SecondNameParameter = person.SecondName != null ?
                new Npgsql.NpgsqlParameter("SecondName", person.SecondName) :
                new Npgsql.NpgsqlParameter("SecondName", typeof(string));

            var EmailParameter =
                new Npgsql.NpgsqlParameter("Email", person.Email);

            var PhoneParameter =
                new Npgsql.NpgsqlParameter("Phone", person.Phone);

            var CellPhoneParameter =
                new Npgsql.NpgsqlParameter("CellPhone", person.CellPhone);

            var AddressParameter =
                new Npgsql.NpgsqlParameter("Address", person.Address);

            var identificationParameter =
                new Npgsql.NpgsqlParameter("identification", person.Identification);

            var NameCompanyParameter = person.NameCompany != null ?
                new Npgsql.NpgsqlParameter("NameCompany", person.NameCompany) :
                new Npgsql.NpgsqlParameter("NameCompany", typeof(string));

            var CodeParameter = person.Code != null ?
              new Npgsql.NpgsqlParameter("Code", person.Code) :
              new Npgsql.NpgsqlParameter("Code", typeof(string));

            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.ExecuteSqlCommand("select * from update_Client (@Code, @Name, @FirstName, @SecondName, @Phone, " +
                "@CellPhone, @Email, @Address, @Identification, @NameCompany, @IDPerson)", CodeParameter, NameParameter, FirstNameParameter,
                SecondNameParameter, EmailParameter, PhoneParameter, CellPhoneParameter, AddressParameter, identificationParameter,
                NameCompanyParameter, IdPersonParameter);
        }
        public virtual int Insert_Client_Provider(Int64 IdClient)
        {
            var IdClientParameter =
                new Npgsql.NpgsqlParameter("IdClient", IdClient);

            return this.Database.ExecuteSqlCommand("select * from Insert_Client_Provider (@IdClient)", IdClientParameter);
        }
        public virtual int Delete_Client(Int64 IdPerson)
        {
            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.ExecuteSqlCommand("select * from Delete_Client (@IdPerson)", IdPersonParameter);
        }
        public virtual int Restore_Client(Int64 IdPerson)
        {
            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.ExecuteSqlCommand("select * from Restore_Client (@IdPerson)", IdPersonParameter);
        }
        public virtual All_Clients View_Client(Int64 IdPerson)
        {
            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.SqlQuery<All_Clients>("select * from View_Client (@IdPerson)", IdPersonParameter).FirstOrDefault();
        }
        public virtual List<All_Clients> All_Clients_Active()
        {
            return this.Database.SqlQuery<All_Clients>("select * from All_Clients_Active ()").ToList();
        }
        public virtual List<All_Clients> All_Clients_Deleted()
        {
            return this.Database.SqlQuery<All_Clients>("select * from All_Clients_Deleted ()").ToList();
        }
        public virtual List<All_Clients> Seach_Client_Word(String name)
        {
            var nameParameter =
                new Npgsql.NpgsqlParameter("Name", name);

            return this.Database.SqlQuery<All_Clients>("select * from Seach_Client_Word (@Name)", nameParameter).ToList();
        }
        #endregion
        //porviders
        #region Providers
        public virtual List<Int64> ProvidersAll()
        {
            return this.Database.SqlQuery<Int64>("select * from ProvidersAll ()").ToList();
        }
        public virtual int Insert_Provider(Persons person)
        {
            var NameParameter = person.Name != null ?
                new Npgsql.NpgsqlParameter("Name", person.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var FirstNameParameter = person.FirstName != null ?
                new Npgsql.NpgsqlParameter("FirstName", person.FirstName) :
                new Npgsql.NpgsqlParameter("FirstName", typeof(string));

            var SecondNameParameter = person.SecondName != null ?
                new Npgsql.NpgsqlParameter("SecondName", person.SecondName) :
                new Npgsql.NpgsqlParameter("SecondName", typeof(string));

            var EmailParameter =
                new Npgsql.NpgsqlParameter("Email", person.Email);

            var PhoneParameter =
                new Npgsql.NpgsqlParameter("Phone", person.Phone);

            var CellPhoneParameter =
                new Npgsql.NpgsqlParameter("CellPhone", person.CellPhone);

            var AddressParameter =
                new Npgsql.NpgsqlParameter("Address", person.Address);

            var identificationParameter =
                new Npgsql.NpgsqlParameter("identification", person.Identification);

            var NameCompanyParameter = person.NameCompany != null ?
                new Npgsql.NpgsqlParameter("NameCompany", person.NameCompany) :
                new Npgsql.NpgsqlParameter("NameCompany", typeof(string));

            var CodeParameter = person.Code != null ?
              new Npgsql.NpgsqlParameter("Code", person.Code) :
              new Npgsql.NpgsqlParameter("Code", typeof(string));

            return this.Database.ExecuteSqlCommand("select * from Insert_Provider (@Code, @Name, @FirstName, @SecondName, @Phone, " +
                "@CellPhone, @Email, @Address, @Identification, @NameCompany)", CodeParameter, NameParameter, FirstNameParameter,
                SecondNameParameter, EmailParameter, PhoneParameter, CellPhoneParameter, AddressParameter, identificationParameter,
                NameCompanyParameter);
        }
        public virtual int Update_Provider(Persons person, Int64 IdPerson)
        {
            var NameParameter = person.Name != null ?
                new Npgsql.NpgsqlParameter("Name", person.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var FirstNameParameter = person.FirstName != null ?
                new Npgsql.NpgsqlParameter("FirstName", person.FirstName) :
                new Npgsql.NpgsqlParameter("FirstName", typeof(string));

            var SecondNameParameter = person.SecondName != null ?
                new Npgsql.NpgsqlParameter("SecondName", person.SecondName) :
                new Npgsql.NpgsqlParameter("SecondName", typeof(string));

            var EmailParameter =
                new Npgsql.NpgsqlParameter("Email", person.Email);

            var PhoneParameter =
                new Npgsql.NpgsqlParameter("Phone", person.Phone);

            var CellPhoneParameter =
                new Npgsql.NpgsqlParameter("CellPhone", person.CellPhone);

            var AddressParameter =
                new Npgsql.NpgsqlParameter("Address", person.Address);

            var identificationParameter =
                new Npgsql.NpgsqlParameter("identification", person.Identification);

            var NameCompanyParameter = person.NameCompany != null ?
                new Npgsql.NpgsqlParameter("NameCompany", person.NameCompany) :
                new Npgsql.NpgsqlParameter("NameCompany", typeof(string));

            var CodeParameter = person.Code != null ?
              new Npgsql.NpgsqlParameter("Code", person.Code) :
              new Npgsql.NpgsqlParameter("Code", typeof(string));

            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.ExecuteSqlCommand("select * from Update_Provider (@Code, @Name, @FirstName, @SecondName, @Phone, " +
                "@CellPhone, @Email, @Address, @Identification, @NameCompany, @IDPerson)", CodeParameter, NameParameter, FirstNameParameter,
                SecondNameParameter, EmailParameter, PhoneParameter, CellPhoneParameter, AddressParameter, identificationParameter,
                NameCompanyParameter, IdPersonParameter);
        }
        public virtual int Insert_Provider_Client(Int64 IdProvider)
        {
            var IdProviderParameter =
                new Npgsql.NpgsqlParameter("IdProvider", IdProvider);

            return this.Database.ExecuteSqlCommand("select * from Insert_Provider_Client (@IdProvider)", IdProviderParameter);
        }
        public virtual int Delete_Provider(Int64 IdPerson)
        {
            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.ExecuteSqlCommand("select * from Delete_Provider (@IdPerson)", IdPersonParameter);
        }
        public virtual int Restore_Provider(Int64 IdPerson)
        {
            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.ExecuteSqlCommand("select * from Restore_Provider (@IdPerson)", IdPersonParameter);
        }
        public virtual All_Providers View_Provider(Int64 IdPerson)
        {
            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.SqlQuery<All_Providers>("select * from View_Provider (@IdPerson)", IdPersonParameter).FirstOrDefault();
        }
        public virtual List<All_Providers> All_Providers_Active()
        {
            return this.Database.SqlQuery<All_Providers>("select * from All_Providers_Active ()").ToList();
        }
        public virtual List<All_Providers> All_Providers_Deleted()
        {
            return this.Database.SqlQuery<All_Providers>("select * from All_Providers_Deleted ()").ToList();
        }
        #endregion
        //products
        #region Products
        public virtual String Check_CodeProduct(string code)
        {
            var codeParameter = code != null ?
                new Npgsql.NpgsqlParameter("code", code) :
                new Npgsql.NpgsqlParameter("code", typeof(string));

            return this.Database.SqlQuery<String>("select * from Check_CodeProduct (@code)", codeParameter).FirstOrDefault();
        }
        public virtual int Insert_Product(Products product)
        {
            var NameParameter = product.Name != null ?
                new Npgsql.NpgsqlParameter("Name", product.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var CodeParameter = product.Code != null ?
                new Npgsql.NpgsqlParameter("Code", product.Code) :
                new Npgsql.NpgsqlParameter("Code", typeof(string));

            var DescriptionParameter =
                new Npgsql.NpgsqlParameter("Description", product.Description);

            var PriceParameter =
                new Npgsql.NpgsqlParameter("Price", product.Price);

            var TaxParameter =
                new Npgsql.NpgsqlParameter("Tax", product.Tax);

            var IdProviderParameter =
                new Npgsql.NpgsqlParameter("IdProvider", product.IdProvider);

            return this.Database.ExecuteSqlCommand("select * from Insert_Product (@Description, @Price, @Tax, @Code, @Name, @IdProvider)", DescriptionParameter, PriceParameter,
                TaxParameter, CodeParameter, NameParameter, IdProviderParameter);
        }
        public virtual int Insert_Product_SM(Products product)
        {
            var NameParameter = product.Name != null ?
                new Npgsql.NpgsqlParameter("Name", product.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var CodeParameter = product.Code != null ?
                new Npgsql.NpgsqlParameter("Code", product.Code) :
                new Npgsql.NpgsqlParameter("Code", typeof(string));

            var StateParameter =
                new Npgsql.NpgsqlParameter("State", product.State);

            var DescriptionParameter =
                new Npgsql.NpgsqlParameter("Description", product.Description);

            var PriceParameter =
                new Npgsql.NpgsqlParameter("Price", product.Price);

            var TaxParameter =
                new Npgsql.NpgsqlParameter("Tax", product.Tax);

            return this.Database.ExecuteSqlCommand("select * from Insert_Product_SM (@Description, @Price, @Code, @Name, @Tax)", DescriptionParameter, PriceParameter,
                CodeParameter, NameParameter, TaxParameter);
        }
        public virtual int Update_Product(Products product, Int64 IDProduct)
        {
            var NameParameter = product.Name != null ?
                new Npgsql.NpgsqlParameter("Name", product.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var CodeParameter = product.Code != null ?
                new Npgsql.NpgsqlParameter("Code", product.Code) :
                new Npgsql.NpgsqlParameter("Code", typeof(string));

            var StateParameter =
                new Npgsql.NpgsqlParameter("State", product.State);

            var DescriptionParameter =
                new Npgsql.NpgsqlParameter("Description", product.Description);

            var PriceParameter =
                new Npgsql.NpgsqlParameter("Price", product.Price);

            var TaxParameter =
                new Npgsql.NpgsqlParameter("Tax", product.Tax);

            var IDProductParameter =
                new Npgsql.NpgsqlParameter("IDProduct", IDProduct);

            return this.Database.ExecuteSqlCommand("select * from Update_Product (@Description, @Price, @Tax, @Code, @Name, @IDProduct)", DescriptionParameter, PriceParameter, TaxParameter,
                CodeParameter, NameParameter, IDProductParameter);
        }
        public virtual int Delete_Product(Int64 IDAccount)
        {
            var IDAccountParameter =
                new Npgsql.NpgsqlParameter("IDAccount", IDAccount);

            return this.Database.ExecuteSqlCommand("select * from Delete_Product (@IDAccount)", IDAccountParameter);
        }
        public virtual int Restore_Product(Int64 IdProduct)
        {
            var IdProductParameter =
                new Npgsql.NpgsqlParameter("IdProduct", IdProduct);

            return this.Database.ExecuteSqlCommand("select * from Restore_Product (@IdProduct)", IdProductParameter);
        }
        public virtual Products View_Product(Int64 IDAccount)
        {
            var IDAccountParameter =
                new Npgsql.NpgsqlParameter("IDAccount", IDAccount);

            return this.Database.SqlQuery<Products>("select * from View_Product (@IDAccount)", IDAccountParameter).FirstOrDefault();
        }
        public virtual List<Products> Provider_Products(Int64 IdProvider)
        {
            var IdProviderParameter =
                new Npgsql.NpgsqlParameter("IdProvider", IdProvider);

            return this.Database.SqlQuery<Products>("select * from Provider_Products (@IdProvider)", IdProviderParameter).ToList();
        }
        public virtual List<List_Providers> List_Providers()
        {
            return this.Database.SqlQuery<List_Providers>("select * from List_Providers ()").ToList();
        }
        public virtual List<Products> List_Products_SM()
        {
            return this.Database.SqlQuery<Products>("select * from List_Products_SM ()").ToList();
        }
        public virtual List<List_Products_Deleted> List_Products_Deleted()
        {
            return this.Database.SqlQuery<List_Products_Deleted>("select * from List_Products_Deleted ()").ToList();
        }
        #endregion
        //users
        #region Users
        public virtual int Insert_User(Users user)
        {
            var nicknameParameter = user.Nickname != null ?
                new Npgsql.NpgsqlParameter("nickname", user.Nickname) :
                new Npgsql.NpgsqlParameter("nickname", typeof(string));

            var passwordParameter = user.Password != null ?
                new Npgsql.NpgsqlParameter("password", user.Password) :
                new Npgsql.NpgsqlParameter("password", typeof(string));

            var typeParameter =
                new Npgsql.NpgsqlParameter("type", user.Type);

            var StateParameter =
                new Npgsql.NpgsqlParameter("State", user.State);


            return this.Database.ExecuteSqlCommand("select * from Insert_User (@nickname, @password, @type)", nicknameParameter, passwordParameter, typeParameter);
        }
        public virtual int Update_User(Users users)
        {
            var nicknameParameter = users.Nickname != null ?
                new Npgsql.NpgsqlParameter("nickname", users.Nickname) :
                new Npgsql.NpgsqlParameter("nickname", typeof(string));

            var passwordParameter = users.Password != null ?
                new Npgsql.NpgsqlParameter("password", users.Password) :
                new Npgsql.NpgsqlParameter("password", typeof(string));

            var typeParameter =
                new Npgsql.NpgsqlParameter("type", users.Type);

            var stateParameter =
                new Npgsql.NpgsqlParameter("state", users.State);

            var IDUserParameter =
                new Npgsql.NpgsqlParameter("IDUser", users.IDUser);

            return this.Database.ExecuteSqlCommand("select * from Update_User (@nickname, @password, @type, @IDUser)", nicknameParameter, passwordParameter, typeParameter, IDUserParameter);
        }
        public virtual int Delete_User(Int64 IDUser)
        {
            var IDUserParameter =
                new Npgsql.NpgsqlParameter("IDUser", IDUser);

            return this.Database.ExecuteSqlCommand("select * from Delete_User (@IDUser)", IDUserParameter);
        }
        public virtual int Restore_User(Int64 IDUser)
        {
            var IDUserParameter =
                new Npgsql.NpgsqlParameter("IDUser", IDUser);

            return this.Database.ExecuteSqlCommand("select * from Restore_User (@IDUser)", IDUserParameter);
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
        public virtual List<Users> List_Users()
        {
            return this.Database.SqlQuery<Users>("select * from List_Users ()").ToList();
        }
        public virtual List<Users> List_Users_Deleted()
        {
            return this.Database.SqlQuery<Users>("select * from List_Users_Deleted ()").ToList();
        }
        public virtual Users View_Users(Int64 IDUser)
        {
            var IDUserParameter =
               new Npgsql.NpgsqlParameter("IDUser", IDUser);

            return this.Database.SqlQuery<Users>("select * from View_Users (@IDUser)", IDUserParameter).FirstOrDefault();
        }
        public virtual String Check_Nickname(string nickname)
        {
            var nicknameParameter = nickname != null ?
                new Npgsql.NpgsqlParameter("nickname", nickname) :
                new Npgsql.NpgsqlParameter("nickname", typeof(string));

            return this.Database.SqlQuery<String>("select * from Check_Nickname (@nickname)", nicknameParameter).FirstOrDefault();
        }

        #endregion
        //accounts
        #region Accounts
        public virtual Boolean? Check_Account(Int64 IdAccount)
        {
            var IdAccountParameter =
                new Npgsql.NpgsqlParameter("IdAccount", IdAccount);

            return this.Database.SqlQuery<Nullable<Boolean>>("select * from Check_Account (@IdAccount)", IdAccountParameter).FirstOrDefault();
        }
        public virtual String Check_NameAccount(string name)
        {
            var nameParameter = name != null ?
                new Npgsql.NpgsqlParameter("name", name) :
                new Npgsql.NpgsqlParameter("name", typeof(string));

            return this.Database.SqlQuery<String>("select * from Check_NameAccount (@name)", nameParameter).FirstOrDefault();
        }
        public virtual int Insert_Account(Accounts accounts)
        {
            var nameParameter = accounts.Name != null ?
                new Npgsql.NpgsqlParameter("name", accounts.Name) :
                new Npgsql.NpgsqlParameter("name", typeof(string));

            return this.Database.ExecuteSqlCommand("select * from Insert_Account (@name)", nameParameter);
        }
        public virtual int Update_Account(Accounts account)
        {
            var nameParameter = account.Name != null ?
                new Npgsql.NpgsqlParameter("name", account.Name) :
                new Npgsql.NpgsqlParameter("name", typeof(string));

            var IDAccountParameter =
                new Npgsql.NpgsqlParameter("IDAccount", account.IDAccount);

            return this.Database.ExecuteSqlCommand("select * from Update_Account (@name, @IDAccount)", nameParameter, IDAccountParameter);
        }
        public virtual int Delete_Account(Int64 IDAccount)
        {
            var IDAccountParameter =
                new Npgsql.NpgsqlParameter("IDAccount", IDAccount);

            return this.Database.ExecuteSqlCommand("select * from Delete_Account (@IDAccount)", IDAccountParameter);
        }
        public virtual int Restore_Account(Int64 IDAccount)
        {
            var IDAccountParameter =
                new Npgsql.NpgsqlParameter("IDAccount", IDAccount);

            return this.Database.ExecuteSqlCommand("select * from Restore_Account (@IDAccount)", IDAccountParameter);
        }
        public virtual List<Accounts> List_Accounts()
        {
            return this.Database.SqlQuery<Accounts>("select * from List_Accounts ()").ToList();
        }
        public virtual List<Accounts> List_Accounts_Deleted()
        {
            return this.Database.SqlQuery<Accounts>("select * from List_Accounts_Deleted ()").ToList();
        }
        public virtual Accounts View_Accounts(Int64 IDAccount)
        {
            var IDAccountParameter =
               new Npgsql.NpgsqlParameter("IDAccount", IDAccount);

            return this.Database.SqlQuery<Accounts>("select * from View_Account (@IDAccount)", IDAccountParameter).FirstOrDefault();
        }
        #endregion
        //categories
        #region Categories
        public virtual Boolean? Check_Category(Int64 IdCategory)
        {
            var IdCategoryParameter =
                new Npgsql.NpgsqlParameter("IdCategory", IdCategory);

            return this.Database.SqlQuery<Nullable<Boolean>>("select * from Check_Category (@IdCategory)", IdCategoryParameter).FirstOrDefault();
        }
        public virtual String Check_NameCategory(string name)
        {
            var nameParameter = name != null ?
                new Npgsql.NpgsqlParameter("name", name) :
                new Npgsql.NpgsqlParameter("name", typeof(string));

            return this.Database.SqlQuery<String>("select * from Check_NameCategory (@name)", nameParameter).FirstOrDefault();
        }
        public virtual int Insert_Category(Categories categories)
        {
            var nameParameter = categories.Name != null ?
                new Npgsql.NpgsqlParameter("name", categories.Name) :
                new Npgsql.NpgsqlParameter("name", typeof(string));

            return this.Database.ExecuteSqlCommand("select * from Insert_Category (@name)", nameParameter);
        }
        public virtual int Update_Category(Categories categories)
        {
            var nameParameter = categories.Name != null ?
                new Npgsql.NpgsqlParameter("name", categories.Name) :
                new Npgsql.NpgsqlParameter("name", typeof(string));

            var IDCategoryParameter =
                new Npgsql.NpgsqlParameter("IDCategory", categories.IDCategory);

            return this.Database.ExecuteSqlCommand("select * from Update_Category (@name, @IDCategory)", nameParameter, IDCategoryParameter);
        }
        public virtual int Delete_Category(Int64 IDCategory)
        {
            var IDCategoryParameter =
                new Npgsql.NpgsqlParameter("IDCategory", IDCategory);

            return this.Database.ExecuteSqlCommand("select * from Delete_Category (@IDCategory)", IDCategoryParameter);
        }
        public virtual int Restore_Category(Int64 IDCategory)
        {
            var IDCategoryParameter =
                new Npgsql.NpgsqlParameter("IDCategory", IDCategory);

            return this.Database.ExecuteSqlCommand("select * from Restore_Category (@IDCategory)", IDCategoryParameter);
        }
        public virtual List<Categories> View_Categories()
        {
            return this.Database.SqlQuery<Categories>("select * from View_Categories ()").ToList();
        }
        public virtual List<Categories> View_Categories_Deleted()
        {
            return this.Database.SqlQuery<Categories>("select * from View_Categories_Deleted ()").ToList();
        }
        public virtual Categories View_Category(Int64 IDCategory)
        {
            var IDCategoryParameter =
               new Npgsql.NpgsqlParameter("IDCategory", IDCategory);

            return this.Database.SqlQuery<Categories>("select * from View_Category (@IDCategory)", IDCategoryParameter).FirstOrDefault();
        }
        #endregion
        //subcategories
        #region SubCategories
        public virtual Boolean? Check_SubCategory(Int64 IdSubCategory)
        {
            var IdSubCategoryParameter =
                new Npgsql.NpgsqlParameter("IdSubCategory", IdSubCategory);

            return this.Database.SqlQuery<Nullable<Boolean>>("select * from Check_SubCategory (@IdSubCategory)", IdSubCategoryParameter).FirstOrDefault();
        }
        public virtual int Insert_SubCategory(SubCategories subcategories)
        {
            var NameParameter = subcategories.Name != null ?
                new Npgsql.NpgsqlParameter("Name", subcategories.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var IDCategoryParameter =
                new Npgsql.NpgsqlParameter("IDCategory", subcategories.IdCategory);

            return this.Database.ExecuteSqlCommand("select * from Insert_SubCategory (@Name, @IDCategory)", NameParameter, IDCategoryParameter);
        }
        public virtual int Update_SubCategory(SubCategories subcategories)
        {
            var nameParameter = subcategories.Name != null ?
                new Npgsql.NpgsqlParameter("name", subcategories.Name) :
                new Npgsql.NpgsqlParameter("name", typeof(string));

            var IDSubCategoryParameter =
                new Npgsql.NpgsqlParameter("IDSubCategory", subcategories.IDSubCategory);

            return this.Database.ExecuteSqlCommand("select * from Update_SubCategory (@name, @IDSubCategory)", IDSubCategoryParameter, nameParameter);
        }
        public virtual int Delete_SubCategory(Int64 IDSubCategory)
        {
            var IDSubCategoryParameter =
                new Npgsql.NpgsqlParameter("IDSubCategory", IDSubCategory);

            return this.Database.ExecuteSqlCommand("select * from Delete_SubCategory (@IDSubCategory)", IDSubCategoryParameter);
        }
        public virtual int Restore_SubCategory(Int64 IDSubCategory)
        {
            var IDSubCategoryParameter =
                new Npgsql.NpgsqlParameter("IDSubCategory", IDSubCategory);

            return this.Database.ExecuteSqlCommand("select * from Restore_SubCategory (@IDSubCategory)", IDSubCategoryParameter);
        }
        public virtual List<SubCategories> View_SubCategory()
        {
            return this.Database.SqlQuery<SubCategories>("select * from View_SubCategory ()").ToList();
        }
        public virtual List<View_SubCategories_Deleted> View_SubCategories_Deleted()
        {
            return this.Database.SqlQuery<View_SubCategories_Deleted>("select * from View_SubCategories_Deleted ()").ToList();
        }
        public virtual List<SubCategories> View_SubCategories()
        {
            return this.Database.SqlQuery<SubCategories>("select * from View_SubCategories ()").ToList();
        }
        public virtual SubCategories View_SubCategory(Int64 IDSubCategory)
        {
            var IDSubCategoryParameter =
               new Npgsql.NpgsqlParameter("IDSubCategory", IDSubCategory);

            return this.Database.SqlQuery<SubCategories>("select * from View_SubCategory (@IDSubCategory)", IDSubCategoryParameter).FirstOrDefault();
        }
        public virtual List<SubCategories> View_SubCategoryByCategory(Int64 IDSubCategory)
        {
            var IDSubCategoryParameter =
               new Npgsql.NpgsqlParameter("IDSubCategory", IDSubCategory);

            return this.Database.SqlQuery<SubCategories>("select * from View_SubCategoryByCategory (@IDSubCategory)", IDSubCategoryParameter).ToList();
        }
        public virtual String View_CategoryName(Int64 IDSubCategory)
        {
            var IDSubCategoryParameter =
               new Npgsql.NpgsqlParameter("IDSubCategory", IDSubCategory);

            return this.Database.SqlQuery<String>("select * from View_CategoryName (@IDSubCategory)", IDSubCategoryParameter).FirstOrDefault();
        }
        public virtual String Check_NameSubCategory(String Name, Int64 IDCategory)
        {
            var NameParameter = Name != null ?
                new Npgsql.NpgsqlParameter("Name", Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var IDCategoryParameter =
               new Npgsql.NpgsqlParameter("IDCategory", IDCategory);

            return this.Database.SqlQuery<String>("select * from Check_NameSubCategory (@name, @IDCategory)", NameParameter, IDCategoryParameter).FirstOrDefault();
        }
        #endregion
        //assetsliabilities
        #region AssetsLiabilities
        public virtual int Insert_AssetLiability(AssetsLiabilities assetsLiabilities)
        {
            var CurrentDateParameter = assetsLiabilities.CurrentDate != null ?
                new Npgsql.NpgsqlParameter("CurrentDate", assetsLiabilities.CurrentDate) :
                new Npgsql.NpgsqlParameter("CurrentDate", typeof(string));

            var NameParameter = assetsLiabilities.Name != null ?
                new Npgsql.NpgsqlParameter("Name", assetsLiabilities.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var RodeParameter =
                new Npgsql.NpgsqlParameter("Rode", assetsLiabilities.Rode);

            var CodeParameter =
                new Npgsql.NpgsqlParameter("Code", assetsLiabilities.Code);

            var DescriptionParameter =
                new Npgsql.NpgsqlParameter("Description", assetsLiabilities.Description);

            var IdUserParameter =
                new Npgsql.NpgsqlParameter("IdUser", assetsLiabilities.IdUser);

            var IdAccountParameter =
                new Npgsql.NpgsqlParameter("IdAccount", assetsLiabilities.IdAccount);

            var IdSubCategoryParameter =
                new Npgsql.NpgsqlParameter("IdSubCategory", assetsLiabilities.IdSubCategory);

            var TypeParameter =
               new Npgsql.NpgsqlParameter("Type", assetsLiabilities.Type);

            return this.Database.ExecuteSqlCommand("select * from Insert_AssetLiability (@CurrentDate, @Code, @Rode, @Type," +
                "@Description, @Name, @IdAccount, @IdSubCategory, @IdUser)", CurrentDateParameter, CodeParameter, RodeParameter, TypeParameter,
                 DescriptionParameter, NameParameter, IdAccountParameter, IdSubCategoryParameter, IdUserParameter);
        }
        public virtual int Insert_AssetLiability_Credit(AssetsLiabilities assetsLiabilities)
        {
            var CurrentDateParameter = assetsLiabilities.CurrentDate != null ?
                new Npgsql.NpgsqlParameter("CurrentDate", assetsLiabilities.CurrentDate) :
                new Npgsql.NpgsqlParameter("CurrentDate", typeof(string));

            var NameParameter = assetsLiabilities.Name != null ?
                new Npgsql.NpgsqlParameter("Name", assetsLiabilities.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var RodeParameter =
                new Npgsql.NpgsqlParameter("Rode", assetsLiabilities.Rode);

            var CodeParameter =
                new Npgsql.NpgsqlParameter("Code", assetsLiabilities.Code);

            var DescriptionParameter =
                new Npgsql.NpgsqlParameter("Description", assetsLiabilities.Description);

            var IdUserParameter =
                new Npgsql.NpgsqlParameter("IdUser", assetsLiabilities.IdUser);

            var IdAccountParameter =
                new Npgsql.NpgsqlParameter("IdAccount", assetsLiabilities.IdAccount);

            var IdSubCategoryParameter =
                new Npgsql.NpgsqlParameter("IdSubCategory", assetsLiabilities.IdSubCategory);

            var IdInvoiceParameter =
                new Npgsql.NpgsqlParameter("IdInvoice", assetsLiabilities.IdInvoice);

            var TypeParameter =
               new Npgsql.NpgsqlParameter("Type", assetsLiabilities.Type);

            return this.Database.ExecuteSqlCommand("select * from Insert_AssetLiability_Credit (@CurrentDate, @Code, @Rode, @Type," +
                "@Description, @Name, @IdAccount, @IdSubCategory, @IdUser, @IdInvoice)", CurrentDateParameter, CodeParameter, RodeParameter,
                 TypeParameter, DescriptionParameter, NameParameter, IdAccountParameter, IdSubCategoryParameter, IdUserParameter, IdInvoiceParameter);
        }
        public virtual int Delete_AssetLiability(Int64 IDAssetLiability)
        {
            var IDAssetLiabilityParameter =
                new Npgsql.NpgsqlParameter("IDAssetLiability", IDAssetLiability);

            return this.Database.ExecuteSqlCommand("select * from Delete_AssetLiability (@IDAssetLiability)", IDAssetLiabilityParameter);
        }
        public virtual AssetsLiabilities View_AssetLiability(Int64 IDAssetLiability)
        {
            var IDAssetLiabilityParameter =
                new Npgsql.NpgsqlParameter("IDAssetLiability", IDAssetLiability);

            return this.Database.SqlQuery<AssetsLiabilities>("select * from View_AssetLiability (@IDAssetLiability)", IDAssetLiabilityParameter).FirstOrDefault();
        }
        public virtual List<AssetsLiabilities> All_AssetsLiabilities()
        {
            return this.Database.SqlQuery<AssetsLiabilities>("select * from All_AssetsLiabilities ()").ToList();
        }
        public virtual Decimal? Date_Sum_AssetLiability(String dateMax, String dateMin, Boolean type)
        {
            var dateMinParameter = dateMin != null ?
                new Npgsql.NpgsqlParameter("dateMin", dateMin) :
                new Npgsql.NpgsqlParameter("dateMin", typeof(string));

            var dateMaxParameter = dateMax != null ?
                new Npgsql.NpgsqlParameter("dateMax", dateMax) :
                new Npgsql.NpgsqlParameter("dateMax", typeof(string));

            var typeParameter =
                new Npgsql.NpgsqlParameter("type", type);

            return this.Database.SqlQuery<Nullable<decimal>>("select * from Date_Sum_AssetLiability (@dateMin, @dateMax, @type)", dateMinParameter, dateMaxParameter, typeParameter).FirstOrDefault();
        }
        public virtual List<AssetsLiabilities> Date_AssetLiability(String dateMax, String dateMin)
        {
            var dateMaxParameter = dateMax != null ?
                new Npgsql.NpgsqlParameter("dateMax", dateMax) :
                new Npgsql.NpgsqlParameter("dateMax", typeof(string));

            var dateMinParameter = dateMin != null ?
                new Npgsql.NpgsqlParameter("dateMin", dateMin) :
                new Npgsql.NpgsqlParameter("dateMin", typeof(string));

            return this.Database.SqlQuery<AssetsLiabilities>("select * from Date_AssetLiability (@dateMin, @dateMax)", dateMinParameter, dateMaxParameter).ToList();
        }
        public virtual Check_Payment Check_Payment(Int64 IDInvoince, Boolean Type)
        {
            var IDInvoincenParameter =
                new Npgsql.NpgsqlParameter("IDInvoince", IDInvoince);

            var TypeParameter =
                new Npgsql.NpgsqlParameter("Type", Type);


            return this.Database.SqlQuery<Check_Payment>("select * from Check_Payment (@IDInvoince, @Type)", IDInvoincenParameter, TypeParameter).FirstOrDefault();
        }
        #endregion
        //details
        #region Details
        public virtual Int64 Insert_Detail(Int64 IDUser)
        {
            var IDUserParameter =
                new Npgsql.NpgsqlParameter("IDUser", IDUser);

            return this.Database.SqlQuery<Int64>("select * from Insert_Detail (@IDUser)", IDUserParameter).FirstOrDefault();
        }
        #endregion
        //purchases
        #region Purchases
        public virtual int Insert_Purchase(Purchases purchases)
        {
            var QuantityParameter =
                new Npgsql.NpgsqlParameter("Quantity", purchases.Quantity);

            var TotalParameter =
                new Npgsql.NpgsqlParameter("Total", purchases.Total);

            var IdDetailsParameter =
                new Npgsql.NpgsqlParameter("IdDetails", purchases.IdDetails);

            var IdProductParameter =
                new Npgsql.NpgsqlParameter("IdProduct", purchases.IdProduct);

            return this.Database.ExecuteSqlCommand("select * from Insert_Purchase (@Quantity, @Total, @IdDetails, @IdProduct)", QuantityParameter,
                TotalParameter, IdDetailsParameter, IdProductParameter);
        }
        public virtual int Delete_Purchase(Int64 IDPurchase)
        {
            var IDPurchaseParameter =
                new Npgsql.NpgsqlParameter("IDPurchase", IDPurchase);

            return this.Database.ExecuteSqlCommand("select * from Delete_Purchase (@IDPurchase)", IDPurchaseParameter);
        }
        #endregion
        //sales
        #region Sales
        public virtual int Insert_Sale(Sales sales)
        {
            var QuantityParameter =
                new Npgsql.NpgsqlParameter("Quantity", sales.Quantity);

            var TotalParameter =
                new Npgsql.NpgsqlParameter("Total", sales.Total);

            var IdDetailsParameter =
                new Npgsql.NpgsqlParameter("IdDetails", sales.IdDetails);

            var IdProductParameter =
                new Npgsql.NpgsqlParameter("IdProduct", sales.IdProduct);

            return this.Database.ExecuteSqlCommand("select * from Insert_Sale (@Quantity, @Total, @IdDetails, @IdProduct)", QuantityParameter,
                TotalParameter, IdDetailsParameter, IdProductParameter);
        }
        public virtual int Delete_Sale(Int64 IDSale)
        {
            var IDSaleParameter =
                new Npgsql.NpgsqlParameter("IDSale", IDSale);

            return this.Database.ExecuteSqlCommand("select * from Delete_Sale (@IDSale)", IDSaleParameter);
        }
        #endregion
        //invoice
        #region Invoice
        public virtual int Insert_Invoice(Invoices invoices)
        {
            var LimitDateParameter =
                new Npgsql.NpgsqlParameter("LimitDate", invoices.LimitDate);

            var CodeParameter =
                new Npgsql.NpgsqlParameter("Code", invoices.Code);

            var DiscountParameter =
                new Npgsql.NpgsqlParameter("Discount", invoices.Discount);

            var TotalParameter =
                new Npgsql.NpgsqlParameter("Total", invoices.Total);

            var IdProviderParameter =
                new Npgsql.NpgsqlParameter("IdProvider", invoices.IdProvider);

            var IdClientParameter =
                new Npgsql.NpgsqlParameter("IdClient", invoices.IdClient);

            var IdDetailParameter =
                new Npgsql.NpgsqlParameter("IdDetail", invoices.IdDetail);

            return this.Database.ExecuteSqlCommand("select * from Insert_Invoice (@LimitDate, @Code, @Discount, @Total, @IdProvider, " +
                "@IdClient, @IdDetail)", LimitDateParameter, CodeParameter, DiscountParameter, TotalParameter, IdProviderParameter, IdClientParameter, IdDetailParameter);
        }
        public virtual int Delete_Invoice(Int64 IDInvoice)
        {
            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.ExecuteSqlCommand("select * from Delete_Invoice (@IDInvoice)", IDInvoiceParameter);
        }
        public virtual Boolean? Check_AssestLiabilities(Int64 IDInvoice)
        {
            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<Nullable<Boolean>>("select * from Check_AssestLiabilities (@IDInvoice)", IDInvoiceParameter).FirstOrDefault();
        }
        public virtual String Code_Invoice()
        {
            return this.Database.SqlQuery<String>("select * from Code_Invoice ()").FirstOrDefault();
        }
        public virtual List<Views_Invoices> Views_Invoices_All_Sales()
        {
            return this.Database.SqlQuery<Views_Invoices>("select * from Views_Invoices_All_Sales ()").ToList();
        }
        public virtual List<Views_Invoices> Views_Invoices_All_Purchase()
        {
            return this.Database.SqlQuery<Views_Invoices>("select * from Views_Invoices_All_Purchase ()").ToList();
        }
        public virtual Views_Invoinces_Details View_Invoice_Clients(Int64 IDInvoice)
        {
            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<Views_Invoinces_Details>("select * from View_Invoice_Clients (@IDInvoice)", IDInvoiceParameter).FirstOrDefault();
        }
        public virtual Views_Invoinces_Details View_Invoice_Providers(Int64 IDInvoice)
        {
            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<Views_Invoinces_Details>("select * from View_Invoice_Providers (@IDInvoice)", IDInvoiceParameter).FirstOrDefault();
        }
        public virtual List<Views_Invoinces_Products> Views_Invoice_Product_Sale(Int64 IDInvoice)
        {
            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<Views_Invoinces_Products>("select * from Views_Invoice_Product_Sale (@IDInvoice)", IDInvoiceParameter).ToList();
        }
        public virtual List<Views_Invoinces_Products> Views_Invoice_Product_Purcase(Int64 IDInvoice)
        {
            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<Views_Invoinces_Products>("select * from Views_Invoice_Product_Purcase (@IDInvoice)", IDInvoiceParameter).ToList();
        }
        public virtual List<AssetsLiabilities> View_Invoice_AssetLiability(Int64 IDInvoice)
        {

            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<AssetsLiabilities>("select * from View_Invoice_AssetLiability (@IDInvoice)", IDInvoiceParameter).ToList();
        }
        #endregion
        //Charts
        #region Charts
        public virtual List<Charts_Accounts> Sum_Account()
        {
            return this.Database.SqlQuery<Charts_Accounts>("select * from Sum_Account ()").ToList();
        }
        public virtual List<Sum_Account_Category> Sum_Category()
        {
            return this.Database.SqlQuery<Sum_Account_Category>("select * from Sum_Category ()").ToList();
        }
        public virtual List<Sum_Account_Category> Sum_SubCategory(String Name)
        {
            var NameParameter =
                new Npgsql.NpgsqlParameter("Name", Name);

            return this.Database.SqlQuery<Sum_Account_Category>("select * from Sum_SubCategory (@Name)", NameParameter).ToList();
        }
        public virtual List<Sum_AssetLiability> Sum_AssetLiability_All()
        {
            return this.Database.SqlQuery<Sum_AssetLiability>("select * from Sum_AssetLiability_All ()").ToList();
        }
        public virtual List<Sum_AssetLiability> Sum_AssetLiability_Filter(String DateFilter, String DateSearch, String Date)
        {
            var DateFilterParameter = DateFilter != null ?
                new Npgsql.NpgsqlParameter("DateFilter", DateFilter) :
                new Npgsql.NpgsqlParameter("DateFilter", typeof(string));

            var DateSearchParameter = DateSearch != null ?
                new Npgsql.NpgsqlParameter("DateSearch", DateSearch) :
                new Npgsql.NpgsqlParameter("DateSearch", typeof(string));

            var DateParameter = Date != null ?
                new Npgsql.NpgsqlParameter("Date", Date) :
                new Npgsql.NpgsqlParameter("Date", typeof(string));

            return this.Database.SqlQuery<Sum_AssetLiability>("select * from Sum_AssetLiability_Filter (@DateFilter, @DateSearch, @Date)", DateFilterParameter, DateSearchParameter, DateParameter).ToList();
        }
        public virtual List<Sum_Products> Sum_Products_All()
        {
            return this.Database.SqlQuery<Sum_Products>("select * from Sum_Products_All ()").ToList();
        }
        public virtual List<Sum_Products> Sum_Products_Filter(Int32 Date)
        {
            var DateParameter =
                new Npgsql.NpgsqlParameter("Date", Date);

            return this.Database.SqlQuery<Sum_Products>("select * from Sum_Products_Filter (@Date)", DateParameter).ToList();
        }
        public virtual List<Charts_Clients> Sum_Clients_All()
        {
            return this.Database.SqlQuery<Charts_Clients>("select * from Sum_Clients_All ()").ToList();
        }
        public virtual List<Charts_Clients> Sum_Clients_Filter(Int32 Date)
        {
            var DateParameter =
                new Npgsql.NpgsqlParameter("Date", Date);

            return this.Database.SqlQuery<Charts_Clients>("select * from Sum_Clients_Filter (@Date)", DateParameter).ToList();
        }
        #endregion
        //Emails
        #region Emails
        public virtual int Insert_Email(Mails Email)
        {
            var EmailsParameter = Email.Email != null ?
                new Npgsql.NpgsqlParameter("email", Email.Email) :
                new Npgsql.NpgsqlParameter("email", typeof(string));

            var PasswordParameter = Email.Password != null ?
                new Npgsql.NpgsqlParameter("password", Email.Password) :
                new Npgsql.NpgsqlParameter("password", typeof(string));

            return this.Database.ExecuteSqlCommand("select * from Insert_Email (@email, @password)", EmailsParameter, PasswordParameter);
        }
        public virtual int Update_Email(Mails Email)
        {
            var EmailsParameter = Email.Email != null ?
                new Npgsql.NpgsqlParameter("email", Email.Email) :
                new Npgsql.NpgsqlParameter("email", typeof(string));

            var PasswordParameter = Email.Password != null ?
                new Npgsql.NpgsqlParameter("password", Email.Password) :
                new Npgsql.NpgsqlParameter("password", typeof(string));

            return this.Database.ExecuteSqlCommand("select * from Update_Email (@email, @password)", EmailsParameter, PasswordParameter);
        }
        public virtual Mails View_Email()
        {
            return this.Database.SqlQuery<Mails>("select * from View_Email ()").FirstOrDefault();
        }
        #endregion
    }
}
