[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LenguajesAvanzados.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LenguajesAvanzados.Web.App_Start.NinjectWebCommon), "Stop")]

namespace LenguajesAvanzados.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Repository.EntityFramework;
    using Mapper;
    using Repository.EntityFramework.Repositories;
    using Crao.Repository.EntityFramework;
    using Core.ConfigInterface;
    using Core.Clients;
    using Mapper.Mapper.Clients;
    using Mapper.Mapper.Categories;
    using Core.Sales;
    using Core.Users;
    using Mapper.Dtos.Sales;
    using Mapper.Dtos.Users;
    using Mapper.Mapper.Users;
    using Mapper.Mapper.Sales;
    using Mapper.Dtos.Clients;
    using Core.Accounts;
    using Mapper.Dtos.Accounts;
    using Core.SubCategories;
    using Mapper.Dtos.SubCategories;
    using Core.Purchases;
    using Mapper.Dtos.Purchases;
    using Core.Providers;
    using Mapper.Dtos.Providers;
    using Core.Products;
    using Mapper.Dtos.Products;
    using Core.Persons;
    using Mapper.Dtos.Persons;
    using Core.Invoices;
    using Mapper.Dtos.Invoices;
    using Core.Categories;
    using Mapper.Dtos.Categories;
    using Mapper.Dtos.AssetsLiabilities;
    using Core.AssetsLiabilities;
    using Mapper.Mapper.Accounts;
    using Mapper.Mapper.AssetsLiabilities;
    using Mapper.Mapper.Persons;
    using Mapper.Mapper.SubCategories;
    using Mapper.Mapper.Purchases;
    using Mapper.Mapper.Providers;
    using Crao.Mapper.Mappers.Products;
    using Mapper.Mapper.Invoices;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            /// Generals
            kernel.Bind<DBContext>()
                  .ToSelf()
                  .InSingletonScope();
            kernel.Bind<IRepository>()
                  .To<EntityFrameworkRepository<DBContext>>()
                  .InSingletonScope();
            kernel.Bind<IReadOnlyRepository>()
                  .To<EntityFrameworkReadOnlyRepository<DBContext>>();

            /// Mappers
            kernel.Bind<IMapper<Client, ClientDto>>()
                  .To<ClientMapper>();
            kernel.Bind<IMapper<Account, AccountDto>>()
                  .To<AccountMapper>();
            kernel.Bind<IMapper<AssetLiability, AssetLiabilityDto>>()
                  .To<AssetLiabilityMapper>();
            kernel.Bind<IMapper<Category, CategoryDto>>()
                  .To<CategoryMapper>();
            kernel.Bind<IMapper<Invoice, InvoiceDto>>()
                  .To<InvoiceMapper>();
            kernel.Bind<IMapper<Person, PersonDto>>()
                  .To<PersonMapper>();
            kernel.Bind<IMapper<Sale, SaleDto>>()
                  .To<SaleMapper>();
            kernel.Bind<IMapper<Product, ProductDto>>()
                  .To<ProductMapper>();
            kernel.Bind<IMapper<Provider, ProviderDto>>()
                  .To<ProviderMapper>();
            kernel.Bind<IMapper<User, UserDto>>()
                  .To<UserMapper>();
            kernel.Bind<IMapper<Purchase, PurchaseDto>>()
                  .To<PurchaseMapper>();
            kernel.Bind<IMapper<SubCategory, SubCategoryDto>>()
                  .To<SubCategoryMapper>();

            /// Repositories
            kernel.Bind<IAccountRepository>()
                  .To<AccountRespository>();
            kernel.Bind<IAssetLiabilityRepository>()
                  .To<AssetLiabilityRepository>();
            kernel.Bind<ICategoryRepository>()
                  .To<CategoryRepository>();
            kernel.Bind<IClientRepository>()
                  .To<ClientRepository>();
            kernel.Bind<IInvoiceRepository>()
                  .To<InvoiceRepository>();
            kernel.Bind<IPersonRepository>()
                  .To<PersonRepository>();
            kernel.Bind<IProductRepository>()
                 .To<ProductRespository>();
            kernel.Bind<IProviderRepository>()
                  .To<ProviderRepository>();
            kernel.Bind<IPurchaseRepository>()
                  .To<PurchaseRepository>();
            kernel.Bind<ISaleRepository>()
                  .To<SaleRepository>();
            kernel.Bind<ISubCategoryRepository>()
                  .To<SubCategoryRespository>();
            kernel.Bind<IUserRepository>()
                  .To<UserRepository>();


            /// Cores
            kernel.Bind<IClientCore>()
                  .To<ClientCore>();
            kernel.Bind<IAccountCore>()
                  .To<AccountCore>();
            kernel.Bind<IAssetLiabilityCore>()
                  .To<AssetLiabilityCore>();
            kernel.Bind<ICategoryCore>()
                  .To<CategoryCore>();
            kernel.Bind<IInvoiceCore>()
                  .To<InvoiceCore>();
            kernel.Bind<IPersonCore>()
                  .To<PersonCore>();
            kernel.Bind<ISaleCore>()
                  .To<SaleCore>();
            kernel.Bind<IProductCore>()
                  .To<ProductCore>();
            kernel.Bind<IProviderCore>()
                  .To<ProviderCore>();
            kernel.Bind<IUserCore>()
                  .To<UserCore>();
            kernel.Bind<IPurchaseCore>()
                  .To<PurchaseCore>();
            kernel.Bind<ISubCategoryCore>()
                  .To<SubCategoryCore>();
        }
    }
}
