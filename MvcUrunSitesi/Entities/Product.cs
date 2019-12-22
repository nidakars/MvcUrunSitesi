using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUrunSitesi.Entities
{
   public class Product
   {
      public int Id { get; set; }
      public int CategoryId { get; set; }
      public string UrunAdi { get; set; }
      public string UrunAciklamasi { get; set; }
      public string UrunResmi { get; set; }
      public decimal UrunFiyati { get; set; }
      public int? UrunStok { get; set; }
      public double? Iskonto { get; set; }
      public bool Anasayfa { get; set; }
      public DateTime? EklenmeTarihi { get; set; }

      public virtual Category Categories { get; set; }
   }
}