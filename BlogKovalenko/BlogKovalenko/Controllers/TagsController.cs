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
    public class TagsController : Controller
    {
        ArticleContext db;

        private TagRepository tagRepository;
        public TagsController()
        {
            db = new ArticleContext();
            tagRepository = new TagRepository(db);
        }
        // GET: Tags
        public ActionResult Index()
        {
            IEnumerable<Tag> tags = tagRepository.GetAll();
            return View(tags);
        }

        // GET: Tags/Details/5
        public ActionResult Details(int id)
        {
            return View(tagRepository.Get(id));
        }

        // GET: Tags/Create
        public ActionResult Create(int? id)
        {
            Tag model = new Tag();
            if (id.HasValue)
            {
                model = tagRepository.Get(id.Value);
            }

            ViewBag.Articles = (new ArticleRepository(db)).GetAll().ToList();
            return View(model);
        }

        // POST: Tags/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                tagRepository.Create(tag);
                return RedirectToAction("Index");
            }

            ViewBag.Articles = (new ArticleRepository(db)).GetAll().ToList();
            return View(tag);
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Articles = (new ArticleRepository(db)).GetAll().ToList();
            return View(tagRepository.Get(id));
        }

        // POST: Tags/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TagId,Title")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                tagRepository.Update(tag);
                TempData["EditTag"] = "Updaited Tag " + tag.TagId;

                return RedirectToAction("Index");
            }

            ViewBag.Articles = (new ArticleRepository(db)).GetAll().ToList();
            return View(tag);
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tagRepository.Get(id));
        }

        // POST: Tags/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tag tag)
        {
            try
            {
                tagRepository.Delete(id);
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