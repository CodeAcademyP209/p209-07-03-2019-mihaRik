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
    public class GalleryController : Controller
    {
        private readonly OstinPortfolioContext _db;

        public GalleryController()
        {
            ViewBag.GalleryItemIndex = "active";
            _db = new OstinPortfolioContext();
        }

        // GET: Admin/Gallery
        public ActionResult Index()
        {
            return View(_db.GalleryItems);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tag, Photo")]GalleryItem galleryItem)
        {
            if (!ModelState.IsValid || galleryItem.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please add photo.");
                return View(galleryItem);
            }

            if (galleryItem.Photo.IsImage())
            {
                galleryItem.Image = galleryItem.Photo.Save("gallery");
            }

            _db.GalleryItems.Add(galleryItem);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var galleryItem = _db.GalleryItems.Find(id);

            if (galleryItem == null) return HttpNotFound();

            return View(galleryItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Tag, Photo")]GalleryItem galleryItem)
        {
            if (!ModelState.IsValid) return View(galleryItem);

            var galleryFromDb = _db.GalleryItems.Find(galleryItem.Id);

            if (galleryItem.Photo != null)
            {
                if (!galleryItem.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Selected file is not image.");
                    return View(galleryItem);
                }

                Remove(galleryFromDb.Image);

                galleryFromDb.Image = galleryItem.Photo.Save("gallery");
            }

            galleryFromDb.Tag = galleryItem.Tag;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var galleryItem = _db.GalleryItems.Find(id);

            if (galleryItem == null) return HttpNotFound();

            return View(galleryItem);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGalleryItem(int? id)
        {
            var galleryItemFromDb = _db.GalleryItems.Find(id);
            _db.GalleryItems.Remove(galleryItemFromDb);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}