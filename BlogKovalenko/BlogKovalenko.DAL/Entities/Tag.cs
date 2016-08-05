using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogKovalenko.DAL.Entities
{
    public class Tag
    {
        public int TagId { get; set; }

        [DisplayName("Название"), Required]
        public string Title { get; set; }

        [DisplayName("Статьи секции")]
        public virtual ICollection<Article> Articles { get; set; }

        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}
