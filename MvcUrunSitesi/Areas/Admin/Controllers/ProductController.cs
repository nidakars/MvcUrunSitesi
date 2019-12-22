using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcUrunSitesi.DAL;
using MvcUrunSitesi.Entities;
using System.IO;

namespace MvcUrunSitesi.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private UrunContext db = new UrunContext();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.Categories);
            return View(product.ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
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

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "KategoriAdi");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase UrunResmi)
        {
            if (ModelState.IsValid)
            {
                string directory = Server.MapPath("~/Img/Product/");
                if (UrunResmi != null && UrunResmi.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(UrunResmi.FileName);
                    UrunResmi.SaveAs(Path.Combine(directory, fileName));
                    product.UrunResmi = UrunResmi.FileName;
                }
                if (product.UrunStok < 0) product.UrunStok = 0;
                if (product.UrunFiyati < 0) product.UrunFiyati = 0;
                product.EklenmeTarihi = DateTime.Now;
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Category, "Id", "KategoriAdi", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "KategoriAdi", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase UrunResmi)
        {
            if (ModelState.IsValid)
            {
                string directory = Server.MapPath("~/Img/Product/");
                if (UrunResmi != null && UrunResmi.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(UrunResmi.FileName);
                    UrunResmi.SaveAs(Path.Combine(directory, fileName));
                    product.UrunResmi = UrunResmi.FileName;
                }
                if (product.UrunStok < 0) product.UrunStok = 0;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "KategoriAdi", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
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

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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
