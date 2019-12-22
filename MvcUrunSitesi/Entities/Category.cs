using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUrunSitesi.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int UstKategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriAciklamasi { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}