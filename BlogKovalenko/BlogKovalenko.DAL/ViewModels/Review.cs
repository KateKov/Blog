using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogKovalenko.DAL.ViewModels
{
    public class Review
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
