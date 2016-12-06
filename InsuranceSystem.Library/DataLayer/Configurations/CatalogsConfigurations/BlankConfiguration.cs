using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using InsuranceSystem.Library.Models.Catalogs;

namespace InsuranceSystem.Library.DataLayer.Configurations.CatalogsConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    class BlankConfiguration : EntityTypeConfiguration<Blank>, IEntityConfiguration
    {
        public BlankConfiguration()
        {
            //this.HasOptional(a => a.BlankType)
            //    .WithMany()
            //    .HasForeignKey(a => a.BlankTypeId);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
