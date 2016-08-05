using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogKovalenko.DAL.Entities
{
    public class Poll
    {
        public int PollId { get; set; }
        public string Title { get; set; }
        public int Sum { get; set; }
        public string SelectedVariant { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
    }
}
