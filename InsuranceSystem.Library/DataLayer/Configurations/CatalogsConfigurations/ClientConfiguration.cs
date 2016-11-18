using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using InsuranceSystem.Library.Models.Catalogs;

namespace InsuranceSystem.Library.DataLayer.Configurations.CatalogsConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    public class ClientConfiguration : EntityTypeConfiguration<Client>, IEntityConfiguration
    {
        public ClientConfiguration()
        {
            this.HasOptional(a => a.FactAdress)
                .WithMany()
                .HasForeignKey(a => a.FactAdressId);
            this.HasOptional(a => a.LegalAdress)
                .WithMany()
                .HasForeignKey(a => a.LegalAdressId);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
