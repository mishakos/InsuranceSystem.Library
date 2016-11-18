using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using InsuranceSystem.Library.Models.Documents;

namespace InsuranceSystem.Library.DataLayer.Configurations.DocumentsConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    public class MoveBlankItemConfiguration : EntityTypeConfiguration<MoveBlankItem>, IEntityConfiguration
    {
        public MoveBlankItemConfiguration()
        {
            this.HasRequired(a => a.Blank)
                .WithMany()
                .HasForeignKey(a => a.BlankId)
                .WillCascadeOnDelete(false);
            this.HasRequired(a => a.MoveBlank)
                .WithMany()
                .HasForeignKey(a => a.MoveBlankId);                
        }
        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
