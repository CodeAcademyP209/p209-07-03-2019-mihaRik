using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminCRUD_03_March_2019.Models;
using AdminCRUD_03_March_2019.DAL;
using System.Data.Entity;

namespace AdminCRUD_03_March_2019.Areas.Admin.Controllers
{
    public class PricingController : Controller
    {
        private readonly OstinPortfolioContext _db;

        public PricingController()
        {
            ViewBag.PricingIndex = "active";
            _db = new OstinPortfolioContext();
        }

        // GET: Admin/Pricing
        public ActionResult Index()
        {
            return View(_db.Pricings);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var pricing = _db.Pricings.Find(id);

            if (pricing == null) return HttpNotFound();

            return View(pricing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Title, Price, PhotosCount, Duration, Place")]Pricing pricing)
        {
            if (!ModelState.IsValid) return View(pricing);

            _db.Entry(pricing).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}