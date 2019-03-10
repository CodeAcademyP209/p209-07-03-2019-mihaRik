using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminCRUD_03_March_2019.Models;
using AdminCRUD_03_March_2019.DAL;
using AdminCRUD_03_March_2019.Extensions;
using static AdminCRUD_03_March_2019.Utilities.Utility;

namespace AdminCRUD_03_March_2019.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        private readonly OstinPortfolioContext _db;

        public AboutController()
        {
            ViewBag.AboutIndex = "active";
            _db = new OstinPortfolioContext();
        }
        // GET: Admin/About
        public ActionResult Index()
        {
            return View(_db.Abouts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Title, Description, Photo")]About about)
        {
            if (!ModelState.IsValid || about.Photo == null) return View(about);

            if (about.Photo.IsImage())
            {
                about.Image = about.Photo.Save("about");
            }

            _db.Abouts.Add(about);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var about = _db.Abouts.Find(id);

            if (about == null) return HttpNotFound();

            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id, Title, Description, Photo")]About about)
        {
            if (!ModelState.IsValid) return View(about);

            var aboutFromDb = _db.Abouts.Find(about.Id);

            if (about.Photo != null)
            {
                if (!about.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Selected file is not image.");
                    return View(about);
                }

                Remove(aboutFromDb.Image);

                aboutFromDb.Image = about.Photo.Save("about");
            }

            aboutFromDb.Title = about.Title;
            aboutFromDb.Description = about.Description;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var about = _db.Abouts.Find(id);

            if (about == null) return HttpNotFound();

            return View(about);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAbout(int? id)
        {
            if (id == null) return HttpNotFound();

            var about = _db.Abouts.Find(id);

            if (about == null) return HttpNotFound();

            _db.Abouts.Remove(about);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}