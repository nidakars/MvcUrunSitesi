using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUrunSitesi.Entities
{
    public class Adres
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Baslik { get; set; }
        public string AcikAdres { get; set; }
        public string Sehir { get; set; }

        public virtual User Users { get; set; }
    }
}