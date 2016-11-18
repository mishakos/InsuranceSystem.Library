namespace InsuranceSystem.Library.DataLayer.Configurations.CatalogsConfigurations
{
    using Models.Catalogs;
    using System.ComponentModel.Composition;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Configuration;

    [Export(typeof(IEntityConfiguration))]
    class SalesOfficeConfiguration : EntityTypeConfiguration<SalesOffice>, IEntityConfiguration
    {
        public SalesOfficeConfiguration()
        {
            HasRequired(a => a.Department)
                .WithMany()
                .HasForeignKey(a => a.DepartmentId)
                .WillCascadeOnDelete(false);
        }
        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
