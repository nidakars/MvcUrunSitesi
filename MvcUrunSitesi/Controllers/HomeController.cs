using MvcUrunSitesi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUrunSitesi.Controllers
{
    public class HomeController : Controller
    {
        UrunContext db = new UrunContext();
        public ActionResult Index()
        {
            return View(db.Product.ToList());
        }
        [Route("hakkimizda")]
        public ActionResult About()
        {
            ViewBag.Message = "hakkımızda sayfası.";

            return View();
        }
        [Route("iletisim")]
        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim sayfası.";

            return View();
        }
        [Route("Urunlerimiz")]
        public ActionResult Urunler()
        {
            ViewBag.Message = "Urunlerimiz sayfası.";

            return View();
        }
        [Route("UrunDetay/{id}")]
        public ActionResult UrunDetay(int? id)
        {
            ViewBag.Message = id + " no lu ürün detay sayfası.";

            return View();
        }
        [Route("SayfaDetay/{id}")]
        public ActionResult SayfaDetay(int? id)
        {
            ViewBag.Message = id + " no lu sayfa detay.";
            return View();
        }
    }
}