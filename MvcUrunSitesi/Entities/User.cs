using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcUrunSitesi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int AdresId { get; set; }
        [DisplayName("Adınız")]
        public string Adi { get; set; }
        [DisplayName("Soyadınız")]
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        [DisplayName("E Mail Adresiniz")]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public DateTime EklenmeTarihi { get; set; }

        public virtual List<Adres> Adresler { get; set; }
        public virtual List<Siparis> Siparisler { get; set; }
    }
}