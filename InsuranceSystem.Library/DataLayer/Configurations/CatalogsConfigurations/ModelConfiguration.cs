namespace InsuranceSystem.Library.DataLayer.Configurations.CatalogsConfigurations
{
    using Models.Catalogs;
    using System.ComponentModel.Composition;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Configuration;

    [Export(typeof(IEntityConfiguration))]
    class ModelConfiguration : EntityTypeConfiguration<Model>, IEntityConfiguration
    {
        public ModelConfiguration()
        {
            HasRequired(a => a.Brand)
                .WithMany()
                .HasForeignKey(a => a.BrandId)
                .WillCascadeOnDelete(false);
        }
        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
