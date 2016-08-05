using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogKovalenko.DAL.EF;
using BlogKovalenko.DAL.Entities;
using BlogKovalenko.DAL.Repositories;

namespace BlogKovalenko.Controllers
{
    public class AuthorsController : Controller
    {
        ArticleContext db;

        private AuthorRepository authorRepository;
        public AuthorsController()
        {
            db = new ArticleContext();
            authorRepository = new AuthorRepository(db);
        }
        // GET: Articles
        public ActionResult Index()
        {
            IEnumerable<Author> author = authorRepository.GetAll();
            return View(author);

        }

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            return View(authorRepository.Get(id));
        }

        // GET: Articles/Create
        public ActionResult Create(int? id)
        {

            Author model = new Author();
            if (id.HasValue)
            {
                model = authorRepository.Get(id.Value);
            }
            return View(model);
        }

        // POST: Articles/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {



            if (ModelState.IsValid)
            {
                authorRepository.Create(author);
                return RedirectToAction("Index");
            }


            return View(author);



        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
            return View(authorRepository.Get(id));
        }

        // POST: Articles/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author author)
        {

            if (ModelState.IsValid)
            {

                authorRepository.Update(author);
                TempData["EditAuthor"] = "Updaited Author " + author.AuthorId;

                return RedirectToAction("Index");
            }

            return View(author);


        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            return View(authorRepository.Get(id));

        }

        // POST: Articles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Article article)
        {
            try
            {
                authorRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}