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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        //clients
        #region Clients
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

            var EmailParameter = person.Email != null ?
                new Npgsql.NpgsqlParameter("Email", person.Email) :
                new Npgsql.NpgsqlParameter("Email", typeof(string));

            var PhoneParameter = person.Phone != null ?
                new Npgsql.NpgsqlParameter("Phone", person.Phone) :
                new Npgsql.NpgsqlParameter("Phone", typeof(string));

            var CellPhoneParameter = person.CellPhone != null ?
                new Npgsql.NpgsqlParameter("CellPhone", person.CellPhone) :
                new Npgsql.NpgsqlParameter("CellPhone", typeof(string));

            var AddressParameter = person.Address != null ?
                new Npgsql.NpgsqlParameter("Address", person.Address) :
                new Npgsql.NpgsqlParameter("Address", typeof(string));

            var identificationParameter = person.identification != null ?
                new Npgsql.NpgsqlParameter("identification", person.identification) :
                new Npgsql.NpgsqlParameter("identification", typeof(string));

            var NameCompanyParameter = person.NameCompany != null ?
                new Npgsql.NpgsqlParameter("NameCompany", person.NameCompany) :
                new Npgsql.NpgsqlParameter("NameCompany", typeof(string));

            return this.Database.ExecuteSqlCommand("select * from Insert_Client (@Name, @FirstName, @SecondName, @Phone, " +
                "@CellPhone, @Email, @Address, @Identification, @NameCompany)", NameParameter, FirstNameParameter,
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

            var EmailParameter = person.Email != null ?
                new Npgsql.NpgsqlParameter("Email", person.Email) :
                new Npgsql.NpgsqlParameter("Email", typeof(string));

            var PhoneParameter = person.Phone != null ?
                new Npgsql.NpgsqlParameter("Phone", person.Phone) :
                new Npgsql.NpgsqlParameter("Phone", typeof(string));

            var CellPhoneParameter = person.CellPhone != null ?
                new Npgsql.NpgsqlParameter("CellPhone", person.CellPhone) :
                new Npgsql.NpgsqlParameter("CellPhone", typeof(string));

            var AddressParameter = person.Address != null ?
                new Npgsql.NpgsqlParameter("Address", person.Address) :
                new Npgsql.NpgsqlParameter("Address", typeof(string));

            var identificationParameter = person.identification != null ?
                new Npgsql.NpgsqlParameter("identification", person.identification) :
                new Npgsql.NpgsqlParameter("identification", typeof(string));

            var NameCompanyParameter = person.NameCompany != null ?
                new Npgsql.NpgsqlParameter("NameCompany", person.NameCompany) :
                new Npgsql.NpgsqlParameter("NameCompany", typeof(string));

            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.ExecuteSqlCommand("select * from update_Client (@Name, @FirstName, @SecondName, @Phone, " +
                "@CellPhone, @Email, @Address, @Identification, @NameCompany, @IDPerson)", NameParameter, FirstNameParameter,
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

            return this.Database.ExecuteSqlCommand("select * from Delete_Client (@IdPerson)", IdPersonParameter);
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
        #endregion
        //porviders
        #region Providers
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

            var EmailParameter = person.Email != null ?
                new Npgsql.NpgsqlParameter("Email", person.Email) :
                new Npgsql.NpgsqlParameter("Email", typeof(string));

            var PhoneParameter = person.Phone != null ?
                new Npgsql.NpgsqlParameter("Phone", person.Phone) :
                new Npgsql.NpgsqlParameter("Phone", typeof(string));

            var CellPhoneParameter = person.CellPhone != null ?
                new Npgsql.NpgsqlParameter("CellPhone", person.CellPhone) :
                new Npgsql.NpgsqlParameter("CellPhone", typeof(string));

            var AddressParameter = person.Address != null ?
                new Npgsql.NpgsqlParameter("Address", person.Address) :
                new Npgsql.NpgsqlParameter("Address", typeof(string));

            var identificationParameter = person.identification != null ?
                new Npgsql.NpgsqlParameter("identification", person.identification) :
                new Npgsql.NpgsqlParameter("identification", typeof(string));

            var NameCompanyParameter = person.NameCompany != null ?
                new Npgsql.NpgsqlParameter("NameCompany", person.NameCompany) :
                new Npgsql.NpgsqlParameter("NameCompany", typeof(string));

            return this.Database.ExecuteSqlCommand("select * from Insert_Provider (@Name, @FirstName, @SecondName, @Phone, " +
                "@CellPhone, @Email, @Address, @Identification, @NameCompany)", NameParameter, FirstNameParameter,
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

            var EmailParameter = person.Email != null ?
                new Npgsql.NpgsqlParameter("Email", person.Email) :
                new Npgsql.NpgsqlParameter("Email", typeof(string));

            var PhoneParameter = person.Phone != null ?
                new Npgsql.NpgsqlParameter("Phone", person.Phone) :
                new Npgsql.NpgsqlParameter("Phone", typeof(string));

            var CellPhoneParameter = person.CellPhone != null ?
                new Npgsql.NpgsqlParameter("CellPhone", person.CellPhone) :
                new Npgsql.NpgsqlParameter("CellPhone", typeof(string));

            var AddressParameter = person.Address != null ?
                new Npgsql.NpgsqlParameter("Address", person.Address) :
                new Npgsql.NpgsqlParameter("Address", typeof(string));

            var identificationParameter = person.identification != null ?
                new Npgsql.NpgsqlParameter("identification", person.identification) :
                new Npgsql.NpgsqlParameter("identification", typeof(string));

            var NameCompanyParameter = person.NameCompany != null ?
                new Npgsql.NpgsqlParameter("NameCompany", person.NameCompany) :
                new Npgsql.NpgsqlParameter("NameCompany", typeof(string));

            var IdPersonParameter =
                new Npgsql.NpgsqlParameter("IdPerson", IdPerson);

            return this.Database.ExecuteSqlCommand("select * from Update_Provider (@Name, @FirstName, @SecondName, @Phone, " +
                "@CellPhone, @Email, @Address, @Identification, @NameCompany, @IDPerson)", NameParameter, FirstNameParameter,
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
        public virtual int Insert_Product(Products product)
        {
            var NameParameter = product.Name != null ?
                new Npgsql.NpgsqlParameter("Name", product.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var CodeParameter = product.Code != null ?
                new Npgsql.NpgsqlParameter("Code", product.Code) :
                new Npgsql.NpgsqlParameter("Code", typeof(string));

            var StateParameter =
                new Npgsql.NpgsqlParameter("State", product.State);

            var DescriptionParameter = product.Description != null ?
                new Npgsql.NpgsqlParameter("Description", product.Description) :
                new Npgsql.NpgsqlParameter("Description", typeof(string));

            var PriceParameter =
                new Npgsql.NpgsqlParameter("Price", product.Price);

            var IdProviderParameter =
                new Npgsql.NpgsqlParameter("IdProvider", product.IdProvider);

            return this.Database.ExecuteSqlCommand("select * from Insert_Product (@Description, @Price, @Code, @Name, @IdProvider)", DescriptionParameter, PriceParameter,
                CodeParameter, NameParameter, IdProviderParameter);
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

            var DescriptionParameter = product.Description != null ?
                new Npgsql.NpgsqlParameter("Description", product.Description) :
                new Npgsql.NpgsqlParameter("Description", typeof(string));

            var PriceParameter =
                new Npgsql.NpgsqlParameter("Price", product.Price);

            return this.Database.ExecuteSqlCommand("select * from Insert_Product_SM (@Description, @Price, @Code, @Name)", DescriptionParameter, PriceParameter,
                CodeParameter, NameParameter);
        }
        public virtual int Update_Product(Products product, Int64 IDAccount)
        {
            var NameParameter = product.Name != null ?
                new Npgsql.NpgsqlParameter("Name", product.Name) :
                new Npgsql.NpgsqlParameter("Name", typeof(string));

            var CodeParameter = product.Code != null ?
                new Npgsql.NpgsqlParameter("Code", product.Code) :
                new Npgsql.NpgsqlParameter("Code", typeof(string));

            var StateParameter =
                new Npgsql.NpgsqlParameter("State", product.State);

            var DescriptionParameter = product.Description != null ?
                new Npgsql.NpgsqlParameter("Description", product.Description) :
                new Npgsql.NpgsqlParameter("Description", typeof(string));

            var PriceParameter =
                new Npgsql.NpgsqlParameter("Price", product.Price);

            var IDAccountParameter =
                new Npgsql.NpgsqlParameter("IDAccount", IDAccount);

            return this.Database.ExecuteSqlCommand("select * from Update_Product (@Description, @Price, @Code, @Name, @IDAccount)", DescriptionParameter, PriceParameter,
                CodeParameter, NameParameter, IDAccountParameter);
        }
        public virtual int Delete_Product(Int64 IDAccount)
        {
            var IDAccountParameter =
                new Npgsql.NpgsqlParameter("IDAccount", IDAccount);

            return this.Database.ExecuteSqlCommand("select * from Delete_Product (@IDAccount)", IDAccountParameter);
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
         public virtual Users View_Users(Int64 IDUser)
        {
            var IDUserParameter =
               new Npgsql.NpgsqlParameter("IDUser", IDUser);

            return this.Database.SqlQuery<Users>("select * from View_Users (@IDUser)", IDUserParameter).FirstOrDefault();
        }
        #endregion
        //accounts
        #region Accounts
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
        public virtual List<Accounts> List_Accounts()
        {
            return this.Database.SqlQuery<Accounts>("select * from List_Accounts ()").ToList();
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
        public virtual List<Categories> View_Categories()
        {
            return this.Database.SqlQuery<Categories>("select * from View_Categories ()").ToList();
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
        public virtual List<SubCategories> View_SubCategory()
        {
            return this.Database.SqlQuery<SubCategories>("select * from View_SubCategory ()").ToList();
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

            var TypeParameter = 
                new Npgsql.NpgsqlParameter("Type", assetsLiabilities.Type);

            var RodeParameter = 
                new Npgsql.NpgsqlParameter("Rode", assetsLiabilities.Rode);

            var CodeParameter = assetsLiabilities.Code != null ?
                new Npgsql.NpgsqlParameter("Code", assetsLiabilities.Code) :
                new Npgsql.NpgsqlParameter("Code", typeof(string));

            var DescriptionParameter = assetsLiabilities.Description != null ?
                new Npgsql.NpgsqlParameter("Description", assetsLiabilities.Description) :
                new Npgsql.NpgsqlParameter("Description", typeof(string));

            var IdUserParameter =
                new Npgsql.NpgsqlParameter("IdUser", assetsLiabilities.IdUser);

            var IdAccountParameter =
                new Npgsql.NpgsqlParameter("IdAccount", assetsLiabilities.IdAccount);

            var IdCategoryParameter =
                new Npgsql.NpgsqlParameter("IdCategory", assetsLiabilities.IdCategory);

            var IdSubCategoryParameter =
                new Npgsql.NpgsqlParameter("IdSubCategory", assetsLiabilities.IdSubCategory);

            var IdInvoiceParameter =
                new Npgsql.NpgsqlParameter("IdInvoice", assetsLiabilities.IdInvoice);

            return this.Database.ExecuteSqlCommand("select * from Insert_AssetLiability (@CurrentDate, @Name, @Type, @Rode, " +
                "@Code, @Description, @IdUser, @IdAccount, @IdCategory, @IdSubCategory, @IdInvoice)", CurrentDateParameter, NameParameter,
                TypeParameter, RodeParameter, CodeParameter, DescriptionParameter, IdUserParameter, IdAccountParameter,
                IdCategoryParameter, IdSubCategoryParameter, IdInvoiceParameter);
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
        public virtual decimal Date_Sum_AssetLiability(string dateMax, string dateMin, bool type)
        {
            var dateMaxParameter = dateMax != null ?
                new Npgsql.NpgsqlParameter("dateMax", dateMax) :
                new Npgsql.NpgsqlParameter("dateMax", typeof(string));

            var dateMinParameter = dateMin != null ?
                new Npgsql.NpgsqlParameter("dateMin", dateMin) :
                new Npgsql.NpgsqlParameter("dateMin", typeof(string));

            var typeParameter =
                new Npgsql.NpgsqlParameter("type", type);

            return this.Database.SqlQuery<decimal>("select * from Date_Sum_AssetLiability (@dateMax, @dateMin, @type)", dateMaxParameter, dateMinParameter, typeParameter).FirstOrDefault();
        }
        public virtual List<AssetsLiabilities> Date_AssetLiability(string dateMax, string dateMin)
        {
            var dateMaxParameter = dateMax != null ?
                new Npgsql.NpgsqlParameter("dateMax", dateMax) :
                new Npgsql.NpgsqlParameter("dateMax", typeof(string));

            var dateMinParameter = dateMin != null ?
                new Npgsql.NpgsqlParameter("dateMin", dateMin) :
                new Npgsql.NpgsqlParameter("dateMin", typeof(string));

            return this.Database.SqlQuery<AssetsLiabilities>("select * from Date_AssetLiability (@dateMax, @dateMin, @type)", dateMaxParameter, dateMinParameter).ToList();
        }
        public virtual List<Sum_Account_Category> Sum_Account()
        {
            return this.Database.SqlQuery<Sum_Account_Category>("select * from Sum_Account ()").ToList();
        }
        public virtual List<Sum_Account_Category> Sum_Category()
        {
            return this.Database.SqlQuery<Sum_Account_Category>("select * from Sum_Category ()").ToList();
        }
        public virtual List<Sum_AssetLiability> Sum_AssetLiability()
        {
            return this.Database.SqlQuery<Sum_AssetLiability>("select * from Sum_AssetLiability ()").ToList();
        }
        #endregion
        //details
        #region Details
        public virtual int Insert_Detail(Int64 IDUser)
        {
            var IDUserParameter = 
                new Npgsql.NpgsqlParameter("IDUser", IDUser);

            return this.Database.ExecuteSqlCommand("select * from Insert_Detail (@IDUser)", IDUserParameter);
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
            var LimitDateParameter = invoices.LimitDate != null ?
                new Npgsql.NpgsqlParameter("LimitDate", invoices.LimitDate) :
                new Npgsql.NpgsqlParameter("LimitDate", typeof(string));

            var CodeParameter =
                new Npgsql.NpgsqlParameter("Code", invoices.Code);

            var DiscountParameter =
                new Npgsql.NpgsqlParameter("Discount", invoices.Discount);

            var TaxParameter =
                new Npgsql.NpgsqlParameter("Tax", invoices.Tax);

            var TotalParameter =
                new Npgsql.NpgsqlParameter("Total", invoices.Total);

            var StateParameter =
                new Npgsql.NpgsqlParameter("State", invoices.State);

            var IdProviderParameter =
                new Npgsql.NpgsqlParameter("IdProvider", invoices.IdProvider);

            var IdClientParameter =
                new Npgsql.NpgsqlParameter("IdClient", invoices.IdClient);

            var IdDetailParameter =
                new Npgsql.NpgsqlParameter("IdDetail", invoices.IdDetail);

            return this.Database.ExecuteSqlCommand("select * from Insert_Invoice (@LimitDate, @Code, @Discount, @Tax, @Total, @State, @IdProvider, " +
                "@IdClient, @IdDetail)", LimitDateParameter, CodeParameter, DiscountParameter, TaxParameter, TotalParameter, StateParameter
                , IdProviderParameter, IdClientParameter, IdDetailParameter);
        }
        public virtual List<Views_Invoices> Views_Invoices_All_Sales()
        {
            return this.Database.SqlQuery<Views_Invoices>("select * from Views_Invoices_All_Sales ()").ToList();
        }
        public virtual List<Views_Invoices> Views_Invoices_All_Purchase()
        {
            return this.Database.SqlQuery<Views_Invoices>("select * from Views_Invoices_All_Purchase ()").ToList();
        }
        public virtual List<View_Invoice_Details> View_Invoice_Details(Int64 IDInvoice)
        {

            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<View_Invoice_Details>("select * from View_Invoice_Details ( @IDInvoice)", IDInvoiceParameter).ToList();
        }
        public virtual decimal Sum_Invoices_Sale(Int64 IDInvoice)
        {

            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<decimal>("select * from Sum_Invoices_Sale ( @IDInvoice)", IDInvoiceParameter).FirstOrDefault();
        }
        public virtual decimal Sum_Invoices_Purchase(Int64 IDInvoice)
        {

            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<decimal>("select * from Sum_Invoices_Purchase ( @IDInvoice)", IDInvoiceParameter).FirstOrDefault();
        }
        public virtual Views_Sales_Purchase_Product Views_Sales_Product(Int64 IDInvoice)
        {

            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<Views_Sales_Purchase_Product>("select * from Views_Sales_Product ( @IDInvoice)", IDInvoiceParameter).FirstOrDefault();
        }
        public virtual Views_Sales_Purchase_Product Views_Purchase_Product(Int64 IDInvoice)
        {

            var IDInvoiceParameter =
                new Npgsql.NpgsqlParameter("IDInvoice", IDInvoice);

            return this.Database.SqlQuery<Views_Sales_Purchase_Product>("select * from Views_Purchase_Product ( @IDInvoice)", IDInvoiceParameter).FirstOrDefault();
        }
        #endregion
    }
}
