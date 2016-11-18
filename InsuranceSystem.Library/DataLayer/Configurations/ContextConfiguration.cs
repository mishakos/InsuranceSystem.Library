using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace InsuranceSystem.Library.DataLayer.Configurations
{
    public class ContextConfiguration
    {
        [ImportMany(typeof(IEntityConfiguration))]
        public IEnumerable<IEntityConfiguration> Configurations { get; set; }

    }
}
