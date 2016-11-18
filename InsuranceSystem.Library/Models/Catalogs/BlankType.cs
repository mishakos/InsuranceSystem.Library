using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class BlankType : Catalog
    {
        public virtual List<Blank> Blanks { get; set; }

    }
}
