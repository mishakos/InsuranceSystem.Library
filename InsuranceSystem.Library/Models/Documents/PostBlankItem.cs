using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceSystem.Library.Models.Catalogs;

namespace InsuranceSystem.Library.Models.Documents
{
    public class PostBlankItem
    {
        public int Id { get; set; }
        public int PostBlankId { get; set; }
        public virtual PostBlank PostBlank { get; set; }
        public int BlankId { get; set; }
        public virtual Blank Blank { get; set; }
        public decimal Price { get; set; }

    }
}
