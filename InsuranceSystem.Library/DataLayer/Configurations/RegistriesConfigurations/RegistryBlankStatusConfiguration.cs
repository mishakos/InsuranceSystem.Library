using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using InsuranceSystem.Library.Models.Registries;

namespace InsuranceSystem.Library.DataLayer.Configurations.RegistriesConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    public class RegistryBlankStatusConfiguration : EntityTypeConfiguration<RegistryBlankStatus>, IEntityConfiguration
    {
        public RegistryBlankStatusConfiguration()
        {
            this.HasKey(a => new { a.BlankId, a.Period });
            this.HasRequired(a => a.Blank)
                .WithMany()
                .HasForeignKey(a => a.BlankId);
            this.HasRequired(a => a.Status)
                .WithMany()
                .HasForeignKey(a => a.StatusId);
            this.HasRequired(a => a.PostBlank)
                .WithMany()
                .HasForeignKey(a => a.PostBlankId);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
