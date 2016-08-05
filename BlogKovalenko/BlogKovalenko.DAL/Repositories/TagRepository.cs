using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogKovalenko.DAL.Interfaces;
using BlogKovalenko.DAL.Entities;
using BlogKovalenko.DAL.EF;
using System.Data.Entity;

namespace BlogKovalenko.DAL.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        ArticleContext db;
        public TagRepository(ArticleContext context)
        {
            this.db = context;
        }
        public void Create(Tag item)
        {
            db.Tags.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag != null)
            {
                db.Tags.Remove(tag);
                db.SaveChanges();
            }
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
        {
            return db.Tags.Where(predicate).ToList();
        }

        public Tag Get(int id)
        {
            return db.Tags.Find(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }

        public void Update(Tag item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
