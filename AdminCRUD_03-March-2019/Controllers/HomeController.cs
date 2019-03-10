using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminCRUD_03_March_2019.Models;
using AdminCRUD_03_March_2019.Models.ViewModels;
using AdminCRUD_03_March_2019.DAL;

namespace AdminCRUD_03_March_2019.Controllers
{
    public class HomeController : Controller
    {
        private readonly OstinPortfolioContext _db;

        public HomeController()
        {
            _db = new OstinPortfolioContext();
        }

        public ActionResult Index()
        {
            var vm = new HomeIndexViewModel
            {
                GalleryItem = _db.GalleryItems,
                About = _db.Abouts.Take(2),
                Pricings=_db.Pricings
            };
            return View(vm);
        }
    }
}