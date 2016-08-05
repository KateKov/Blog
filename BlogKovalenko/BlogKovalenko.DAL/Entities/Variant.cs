using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogKovalenko.DAL.Entities
{
    public class Variant
    {
        public int VariantId { get; set; }
        public string Text { get; set; }
        public int Vote { get; set; }
        public virtual Poll Poll { get; set; }
    }
}
