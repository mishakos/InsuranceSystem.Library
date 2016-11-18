using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using InsuranceSystem.Library.Models.Documents;

namespace InsuranceSystem.Library.DataLayer.Configurations.DocumentsConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    public class MoveBlankConfiguration : EntityTypeConfiguration<MoveBlank>, IEntityConfiguration
    {
        public MoveBlankConfiguration()
        {
            this.HasRequired(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);
            this.HasRequired(a => a.FromPerson)
                .WithMany()
                .HasForeignKey(a => a.FromPersonId)
                .WillCascadeOnDelete(false);
            this.HasRequired(a => a.ToPerson)
                .WithMany()
                .HasForeignKey(a => a.ToPersonId)
                .WillCascadeOnDelete(false);
            

        }
        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
