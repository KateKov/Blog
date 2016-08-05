using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogKovalenko.DAL.Entities;
using BlogKovalenko.DAL.ViewModels;

namespace BlogKovalenko.DAL.EF
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(string connectionString) : base(connectionString) { }


        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Poll> Polls { get; set; }


        public ArticleContext() : base("DefaultConnection") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasMany(c => c.Tags)
                .WithMany(s => s.Articles)
                .Map(t => t.MapLeftKey("ArticleId")
                .MapRightKey("TagId")
                .ToTable("ArticleTag"));
        }
    }
}
