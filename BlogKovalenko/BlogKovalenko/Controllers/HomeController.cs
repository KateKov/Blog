using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogKovalenko.DAL.EF;
using BlogKovalenko.DAL.Entities;
using BlogKovalenko.DAL.ViewModels;
using BlogKovalenko.Models.ViewModels;
using System.Net;
using BlogKovalenko.Helpers;

namespace BlogKovalenko.Controllers
{
    public class HomeController : Controller
    {
        ArticleContext db = new ArticleContext();
        public Poll poll;

        public HomeController()
        {
            poll = db.Polls.ToList()[0];

        }


        string ip;

        // GET: Home
        public ActionResult Index()
        {


            IEnumerable<Article> articles = db.Articles.ToList();

            return View(articles);
        }
        [HttpPost]
        public ActionResult Index(Poll poll)
        {
            if (ip != HttpContext.Request.UserHostAddress)
            {
                Session["isfirstsubmit"] = "true";
                ip = HttpContext.Request.UserHostAddress;
                foreach (Variant var in this.poll.Variants)
                {
                    if (var.Text == poll.SelectedVariant)
                    {
                        var.Vote++;

                    }

                    this.poll.Sum += var.Vote;


                }
                db.Polls.Find(0).Sum = poll.Sum;
                db.Polls.Find(0).Variants = poll.Variants;
                db.SaveChanges();
            }
            else
            {
                Session["isfirstsubmit"] = "false";
            }
            IEnumerable<Article> articles = db.Articles.ToList();

            return View(articles);
        }

        [HttpGet]
        public ActionResult TagDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }
        [HttpPost]
        public ActionResult TagDetail(Tag tag)
        {
            return View(tag);
        }
        [HttpGet]
        public ActionResult ArticleDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
        [HttpPost]
        public ActionResult ArticleDetail(Article article)
        {
            return View(article);
        }
        [HttpGet]
        public ActionResult Review()
        {
            IEnumerable<Review> reviews = db.Reviews;
            ViewBag.Reviews = reviews;
            return View();
        }
        [HttpPost]
        public ActionResult Review(Review review)
        {
            review.Date = DateTime.Now;
            db.Reviews.Add(review);
            db.SaveChanges();
            IEnumerable<Review> reviews = db.Reviews;
            ViewBag.Reviews = reviews;
            return View();
        }
        [HttpPost]
        public ActionResult Quest(Form form)
        {


            ViewBag.Form = form;
            return View("~/Views/Home/FinishQuest.cshtml");

        }
        [HttpGet]
        public ActionResult Quest()
        {
            Form model = new Form();

            model.Subject = new List<CheckBoxes>
    {
        new CheckBoxes { Text = "It" },
        new CheckBoxes { Text = "Музыка" },
        new CheckBoxes { Text = "Путешествия" },
        new CheckBoxes { Text = "Спорт" },
        new CheckBoxes { Text = "Художественная литература" },
        new CheckBoxes { Text = "Поэзия" },
        new CheckBoxes { Text = "Кулинария" }
    };
            model.Technologies = new List<CheckBoxes>
            {
                new CheckBoxes {Text="C#" },
                new CheckBoxes {Text="Java" },
                new CheckBoxes {Text="C/C++" },
                new CheckBoxes {Text="JavaScript / HTML / CSS" },
                new CheckBoxes {Text="Python" },
                new CheckBoxes {Text="SQL" },
                new CheckBoxes {Text="XML/XSL/XSLT" }
            };
            model.Languages = new List<CheckBoxes>
            {
                new CheckBoxes {Text="Английский" },
                new CheckBoxes {Text="Немецкий" },
                new CheckBoxes {Text="Французский" },
                new CheckBoxes {Text="Испанский" },
                new CheckBoxes {Text="Итальянский" },
                new CheckBoxes {Text="Китайский" },
                new CheckBoxes {Text="Другой" }
            };

            return View(model);
        }
    }
}