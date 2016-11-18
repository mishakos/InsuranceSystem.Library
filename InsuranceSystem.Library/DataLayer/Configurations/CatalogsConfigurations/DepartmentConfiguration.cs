
namespace InsuranceSystem.Library.DataLayer.Configurations.CatalogsConfigurations
{
    using Models.Catalogs;
    using System.ComponentModel.Composition;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System;

    [Export(typeof(IEntityConfiguration))]
    class DepartmentConfiguration : EntityTypeConfiguration<Department>, IEntityConfiguration
    {
        public DepartmentConfiguration()
        {
            this.HasRequired(a => a.Firm)
                .WithMany()
                .HasForeignKey(a => a.FirmId)
                .WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
