using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using InsuranceSystem.Library.Models.Documents;

namespace InsuranceSystem.Library.DataLayer.Configurations.DocumentsConfigurations
{
    [Export(typeof(IEntityConfiguration))]
    public class MTPLPolicyConfiguration : EntityTypeConfiguration<MTPLPolicy>, IEntityConfiguration
    {
        public MTPLPolicyConfiguration()
        {
            this.HasRequired(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);
            this.HasRequired(a => a.Client)
                .WithMany()
                .HasForeignKey(a => a.ClientId)
                .WillCascadeOnDelete(false);
            this.HasRequired(a => a.Policy)
                .WithMany()
                .HasForeignKey(a => a.PolicyId)
                .WillCascadeOnDelete(false);
            this.HasRequired(a => a.Sticker)
                .WithMany()
                .HasForeignKey(a => a.StickerId)
                .WillCascadeOnDelete(false);

            

        }
        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
