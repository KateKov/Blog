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
    public class ArticlesController : Controller
    {
        ArticleContext db;

        private ArticleRepository articleRepository;
        public ArticlesController()
        {
            db = new ArticleContext();
            articleRepository = new ArticleRepository(db);
        }
        // GET: Articles
        public ActionResult Index()
        {

            IEnumerable<Article> articles = articleRepository.GetAll();
            return View(articles);

        }

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            return View(articleRepository.Get(id));
        }

        // GET: Articles/Create
        public ActionResult Create(int? id)
        {

            Article model = new Article();
            if (id.HasValue)
            {
                model = articleRepository.Get(id.Value);
            }
            ViewBag.AuthorId = new SelectList((new AuthorRepository(db)).GetAll(), "AuthorId", "Name");
            ViewBag.Tags = (new TagRepository(db)).GetAll().ToList();
            return View(model);
        }

        // POST: Articles/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleId,AuthorId,Title,Photo,Date,Text")] Article article)
        {



            if (ModelState.IsValid)
            {
                articleRepository.Create(article);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList((new AuthorRepository(db)).GetAll(), "AuthorId", "Name", article.AuthorId);
            ViewBag.Tags = (new TagRepository(db)).GetAll().ToList();
            return View(article);



        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.AuthorId = new SelectList((new AuthorRepository(db)).GetAll(), "AuthorId", "Name");
            ViewBag.Tags = (new TagRepository(db)).GetAll().ToList();
            return View(articleRepository.Get(id));
        }

        // POST: Articles/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    // get name of the file
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    // save in the folder "Content" the image
                    image.SaveAs(Server.MapPath("~/Content/" + fileName));
                    article.Photo = "../../Content/" + fileName;
                }
                articleRepository.Update(article);
                TempData["EditArticle"] = "Updaited Article " + article.ArticleId;

                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList((new AuthorRepository(db)).GetAll(), "AuthorId", "Name", article.AuthorId);
            ViewBag.Tags = (new TagRepository(db)).GetAll().ToList();
            return View(article);


        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            return View(articleRepository.Get(id));

        }

        // POST: Articles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Article article)
        {
            try
            {
                articleRepository.Delete(id);
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