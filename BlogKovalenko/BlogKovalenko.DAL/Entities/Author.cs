using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogKovalenko.DAL.Entities
{
    public class Author
    {

        public int AuthorId { get; set; }
        [DisplayName("Фамилия"), Required]
        public string Surname { get; set; }
        [DisplayName("Имя"), Required]
        public string Name { get; set; }

        [DisplayName("e-mail"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual ICollection<Article> Articles { get; set; }//Author can has a lot of articles
    }
}
