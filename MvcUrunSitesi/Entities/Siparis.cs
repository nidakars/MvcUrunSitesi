using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUrunSitesi.Entities
{
   public class Siparis
   {
      public int Id { get; set; }
      public int ProductId { get; set; }
      public int UserId { get; set; }
      public decimal UrunFiyati { get; set; }
      public decimal SepetToplamTutar { get; set; }
      public string SiparisNo { get; set; }
      public string SepetUser { get; set; }
      public DateTime SiparisTarihi { get; set; }
      public virtual User Users { get; set; }
      public virtual List<Product> Products { get; set; }
   }
}