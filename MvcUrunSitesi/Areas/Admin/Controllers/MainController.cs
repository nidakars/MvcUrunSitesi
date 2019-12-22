using MvcUrunSitesi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUrunSitesi.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        // GET: Admin/Main
        UrunContext db = new UrunContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Entities.Admin admin)
        {
            if (ModelState.IsValid)
            {
                var yonetici = db.Admin.FirstOrDefault(s => s.Mail == admin.Mail && s.Sifre == admin.Sifre);
                if (yonetici != null)
                {
                    Session["yonetici"] = yonetici;
                    return Redirect("/Admin");
                }
            }
            return View(admin);
        }
    }
}