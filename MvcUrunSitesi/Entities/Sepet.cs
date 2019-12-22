using System.Collections.Generic;

namespace MvcUrunSitesi.Entities
{
    public class Sepet
   {
      public int Id { get; set; }
      public int ProductId { get; set; }
      public int UserId { get; set; }
      public string SepetKullanici { get; set; }

      public virtual Product Product { get; set; }
      //public virtual User Users { get; set; }
   }
}