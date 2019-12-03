using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUrunSitesi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public int AdresId { get; set; }
        public DateTime EklenmeTarihi { get; set; }

        public Adres Adres { get; set; }
    }
}