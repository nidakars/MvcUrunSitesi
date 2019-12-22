using MvcUrunSitesi.DAL;
using MvcUrunSitesi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcUrunSitesi.Controllers
{
    public class HomeController : Controller
    {
        UrunContext db = new UrunContext();
        public ActionResult Index()
        {
            return View(db.Product.ToList().OrderByDescending(s=> s.Id));
        }
        public PartialViewResult UstKategoriler()
        {
            return PartialView(db.Category.ToList());
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
        [Route("Urunlerimiz/{id}")]
        public ActionResult Urunlerimiz(int? id)
        {
            var Kategori = db.Category.Find(id);
            ViewBag.Kategori = Kategori.KategoriAdi;
            ViewBag.KategoriAciklama = Kategori.KategoriAciklamasi;

            return View(db.Product.Where(s => s.CategoryId==id).ToList());
        }
        [Route("UrunDetay/{id}")]
        public ActionResult UrunDetay(int? id)
        {
            ViewBag.Message = id + " no lu ürün detay sayfası.";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);

        }
        [Route("SayfaDetay/{id}")]
        public ActionResult SayfaDetay(int? id)
        {
            ViewBag.Message = id + " no lu sayfa detay.";
            return View();
        }
        [Route("kayit")]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost, Route("kayit")]
        public ActionResult Kayit(User Kullanici)
        {
            if (ModelState.IsValid)
            {
                Kullanici.EklenmeTarihi = DateTime.Now;
                db.User.Add(Kullanici);
                db.SaveChanges();
                return RedirectToAction("/giris");
            }
            return View(Kullanici);
        }
        [Route("giris")]
        public ActionResult UyeGiris()
        {
            return View();
        }
        [HttpPost, Route("giris")]
        public ActionResult UyeGiris(User Kullanici)
        {
            if (ModelState.IsValid)
            {
                //kullanıcı sorgu
                var kullanici = db.User.FirstOrDefault(s => s.Email == Kullanici.Email && s.Sifre == Kullanici.Sifre);
                if (kullanici != null)
                {
                    Session["kullanici"] = kullanici;//Session oturum işlemlerinde kullanılır
                    return RedirectToAction("Uyepaneli");
                }
            }
            return View(Kullanici);
        }
        [Route("UyePaneli")]
        public ActionResult UyePaneli()
        {
            //if (Session["kullanici"] != null) ViewBag.Message = Session["kullanici"];
            return View();
        }
        [HttpPost, Route("UyePaneli")]
        public ActionResult UyePaneli(User Kullanici)
        {
            if (ModelState.IsValid)
            {
                //kullanıcı sorgu
                var kullanici = db.User.FirstOrDefault(s => s.Email == Kullanici.Email && s.Sifre == Kullanici.Sifre);
                if (kullanici != null)
                {
                    //Session["kullanici"] = kullanici;//Session oturum işlemlerinde kullanılır
                    return RedirectToAction("Index");
                }
            }
            return View(Kullanici);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SepeteEkle(Product product, Sepet sepet)
        {
            if(product != null)
            {
                sepet.ProductId = product.Id;
                sepet.SepetKullanici = "kullanici";
                db.Sepet.Add(sepet);
                db.SaveChanges();
                return RedirectToAction("SepetGoster");
            }
            return View();
        }
        //[Route("Sepet")]
        public ActionResult SepetGoster()
        {
            //var Sepettekiler = db.Sepet.Where(s => s.SepetKullanici == "kullanici").ToList();
            var SepetUrunleri = db.Sepet.Include("Product").Where(s => s.SepetKullanici == "kullanici").ToList();
            return View(SepetUrunleri);
        }
        public ActionResult SepettenSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = db.Sepet.Find(id);
            if (sepet == null)
            {
                return HttpNotFound();
            }            
            db.Sepet.Remove(sepet);
            db.SaveChanges();
            return Redirect("/Home/SepetGoster");
        }
        [Route("Satinal")]
        public ActionResult Satinal()
        {
            var SepetUrunleri = db.Sepet.Include("Product").Where(s => s.SepetKullanici == "kullanici").ToList();
            return View(SepetUrunleri);
        }
        [Route("cikis")]
        public ActionResult Cikis()
        {
            Session["kullanici"] = null;
            return Redirect("/");
        }
    }
}