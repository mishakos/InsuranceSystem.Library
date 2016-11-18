using System.Data.Entity.ModelConfiguration.Configuration;

namespace InsuranceSystem.Library.DataLayer.Configurations
{
    public interface IEntityConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar registrar);
    }
}
