[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(InsuranceSystem.Mvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(InsuranceSystem.Mvc.App_Start.NinjectWebCommon), "Stop")]

namespace InsuranceSystem.Mvc.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using InsuranceSystem.BLL.Services.Catalogs;
    using InsuranceSystem.BLL.Interfaces.Catalogs;

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
            kernel.Bind<IAreaOfUseService>().To<AreaOfUseService>();
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
            kernel.Bind<IBankService>().To<BankService>();
            kernel.Bind<IBrandService>().To<BrandService>();
            kernel.Bind<IBlankService>().To<BlankService>();
            kernel.Bind<IBlankTypeService>().To<BlankTypeService>();
            kernel.Bind<IClientService>().To<ClientService>();
            kernel.Bind<IContractTermService>().To<ContractTermService>();
            kernel.Bind<ICurrencyService>().To<CurrencyService>();
            kernel.Bind<IDepartmentService>().To<DepartmentService>();
            kernel.Bind<IDocumentCategoryService>().To<DocumentCategoryService>();
            kernel.Bind<IDriverExperienceService>().To<DriverExperienceService>();
            kernel.Bind<IDriversNumberService>().To<DriversNumberService>();
            kernel.Bind<IFirmService>().To<FirmService>();
        }        
    }
}
