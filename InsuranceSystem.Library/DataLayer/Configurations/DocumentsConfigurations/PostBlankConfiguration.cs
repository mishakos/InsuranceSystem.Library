using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using InsuranceSystem.Library.Models.Documents;

namespace InsuranceSystem.Library.DataLayer.Configurations.DocumentsConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    public class PostBlankConfiguration : EntityTypeConfiguration<PostBlank>, IEntityConfiguration
    {
        public PostBlankConfiguration()
        {
            this.HasRequired(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);
            this.HasRequired(a => a.MRPerson)
                .WithMany()
                .HasForeignKey(a => a.MRPersonId)
                .WillCascadeOnDelete(false);
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
