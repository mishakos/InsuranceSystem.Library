using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Reflection;
using InsuranceSystem.Library.DataLayer.Configurations;
using InsuranceSystem.Library.Models.Catalogs;
using InsuranceSystem.Library.Models.Documents;
using InsuranceSystem.Library.Models.Registries;

namespace InsuranceSystem.Library.DataLayer
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext() 
            : base("InsuranceDb")
        {
        }
        // Catalogs
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Blank> Blanks { get; set; }
        public DbSet<BlankType> BlankTypes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<AreaOfUse> AreasOfUses { get; set; }
        public DbSet<BonusMalus> BonusMaluses { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<ContractTerm> ContractTerms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DocumentCategory> DocumentCategories { get; set; }
        public DbSet<DriverExperience> DriverExperiences { get; set; }
        public DbSet<DriversNumber> DriverNumbers { get; set; }
        public DbSet<FraudAttempt> FraudAttemts { get; set; }
        public DbSet<InsuranceProduct> InsuranceProducts { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<LocalityVehicleRegistration> LocalityVehicleRegistrations { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<SalesOffice> SalesOffices { get; set; }
        public DbSet<TerritoryRegistration> TerritoryRegistrations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclesNumber> VehiclesNumbers { get; set; }
        public DbSet<User> Users { get; set; }


        // Documents
        public DbSet<PostBlank> PostBlanks { get; set; }
        public DbSet<PostBlankItem> PostBlankItems { get; set; }
        public DbSet<MoveBlank> MoveBlanks { get; set; }
        public DbSet<MoveBlankItem> MoveBlankItems { get; set; }
        public DbSet<MTPLPolicy> MTPLPolicies { get; set; }


        // Registries
        public DbSet<RegistryBlankStatus> RegistryBlankStatuses { get; set; }
        public DbSet<RegBlankRest> RegBlankRest { get; set; }
        public DbSet<RegBlankMotion> RegBlankMotion { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var contextConfiguration = new ContextConfiguration();
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(contextConfiguration);
            foreach (var configuration in contextConfiguration.Configurations)
            {
                configuration.AddConfiguration(modelBuilder.Configurations);
            }

            base.OnModelCreating(modelBuilder);
        }

        public new void  Dispose()
        {
            base.Dispose();
        }
    }
}
