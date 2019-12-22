using MvcUrunSitesi.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MvcUrunSitesi.DAL
{
    public class UrunInitializer : DropCreateDatabaseIfModelChanges<UrunContext>
    {//CreateDatabaseIfNotExists
        protected override void Seed(UrunContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
                new Category() { KategoriAdi="Genel", UstKategoriId=0 },
                new Category() { KategoriAdi="İndirimdekiler", UstKategoriId=0 }
            };
            foreach (var item in kategoriler)
            {
                context.Category.Add(item);
            }
            Admin admin = new Admin()
            {
                Adi = "", Aktif = true,
                EklenmeTarihi = DateTime.Now,
                Mail = "admin@siteadi.com",
                Sifre = "123456"
            };
            context.Admin.Add(admin);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}