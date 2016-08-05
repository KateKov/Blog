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
    public class ArticleRepository : IRepository<Article>
    {
        ArticleContext db;
        public ArticleRepository(ArticleContext context)
        {
            this.db = context;
        }
        //Get all articles, that are in blog
        public IEnumerable<Article> GetAll()
        {
            return db.Articles.Include(x => x.Authors).Include(x=>x.Tags);
        }
        //Get article by the id
        public Article Get(int id)
        {
            return db.Articles.Find(id);
        }
        //Add article in the database
        public void Create(Article item)
        {
            db.Articles.Add(item);
            db.SaveChanges();
        }
        //Delete article by the id
        public void Delete(int id)
        {
            Article article = db.Articles.Find(id);
            if (article != null)
            {
                db.Articles.Remove(article);
                db.SaveChanges();
            }
        }
        //Find article by the predicate
        public IEnumerable<Article> Find(Func<Article, bool> predicate)
        {
            return db.Articles.Include(o => o.Authors).Include(o=>o.Tags).Where(predicate).ToList();
        }


        //Edit article 
        public void Update(Article item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Get Author
        public Author GetAuthorToArticle(Int32 ArticleId)
        {
            int authorId = Convert.ToInt32(db.Articles.Where(x => x.ArticleId == ArticleId).Select(x => x.AuthorId));
            return db.Authors.Find(authorId);
        }
    }
}
