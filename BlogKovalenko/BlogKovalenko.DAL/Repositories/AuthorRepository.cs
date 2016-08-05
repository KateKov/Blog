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
    public class AuthorRepository : IRepository<Author>
    {
        //Main database of articles
        ArticleContext db;

        public AuthorRepository(ArticleContext context)
        {
            this.db = context;
        }
        //Create author by the item
        public void Create(Author item)
        {
            db.Authors.Add(item);
            db.SaveChanges();
        }
        //Delete author by the id
        public void Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if (author != null)
            {
                db.Authors.Remove(author);
                db.SaveChanges();
            }
        }
        //Find author using expression
        public IEnumerable<Author> Find(Func<Author, bool> predicate)
        {
            return db.Authors.Where(predicate).ToList();
        }
        //Get author by id
        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }
        //Get surname of author
        public List<String> GetAuthorsSurname
        {
            get { return db.Authors.Select(x => x.Surname).ToList<String>(); }
        }
        //Get all authors
        public IEnumerable<Author> GetAll()
        {
            return db.Authors;
        }
        //Edit information about author
        public void Update(Author item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
