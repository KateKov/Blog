using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogKovalenko.DAL.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }


        [DisplayName("Id Автора"), Required]
        public int AuthorId { get; set; }//Foreign Key of AuthorTable

        public virtual Author Authors { get; set; }

        [DisplayName("Название"), Required]
        public string Title { get; set; }
        [DisplayName("Секции по статьям")]
        public virtual ICollection<Tag> Tags { get; set; }
        [DisplayName("Картинка")]
        public string Photo { get; set; }
        [DisplayName("Дата написания"), Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayName("Текст"), Required, DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}
