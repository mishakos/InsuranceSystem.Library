namespace InsuranceSystem.Library.DataLayer.Configurations.CatalogsConfigurations
{
    using Models.Catalogs;
    using System.ComponentModel.Composition;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Configuration;

    [Export(typeof(IEntityConfiguration))]
    class BankAccountConfiguration : EntityTypeConfiguration<BankAccount>, IEntityConfiguration
    {
        public BankAccountConfiguration()
        {
            this.HasRequired(a => a.Bank)
                .WithMany()
                .HasForeignKey(a => a.BankId)
                .WillCascadeOnDelete(false);
            this.HasRequired(a => a.Currency)
                .WithMany()
                .HasForeignKey(a => a.CurrencyId)
                .WillCascadeOnDelete(false);
        }
        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
