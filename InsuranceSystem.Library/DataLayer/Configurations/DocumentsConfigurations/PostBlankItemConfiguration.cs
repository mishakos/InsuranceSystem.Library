using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using InsuranceSystem.Library.Models.Documents;

namespace InsuranceSystem.Library.DataLayer.Configurations.DocumentsConfigurations
{
    public class PostBlankItemConfiguration : EntityTypeConfiguration<PostBlankItem>, IEntityConfiguration
    {
        public PostBlankItemConfiguration()
        {
            this.HasRequired(a => a.Blank)
                .WithMany()
                .HasForeignKey(a => a.BlankId)
                .WillCascadeOnDelete(false);
            this.HasRequired(a => a.PostBlank)
                .WithMany()
                .HasForeignKey(a => a.PostBlankId)
                .WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
