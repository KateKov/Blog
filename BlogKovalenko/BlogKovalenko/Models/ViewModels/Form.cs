using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogKovalenko.Helpers;

namespace BlogKovalenko.Models.ViewModels
{
    public class Form
    {
        public int FormId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public List<CheckBoxes> Subject { get; set; }
        public string Gender { get; set; }
        public List<CheckBoxes> Technologies { get; set; }
        public List<CheckBoxes> Languages { get; set; }
        public string AddInfo { get; set; }
        public string IqQuestion { get; set; }
    }
}