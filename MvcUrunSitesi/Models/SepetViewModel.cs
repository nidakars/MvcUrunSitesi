using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcUrunSitesi.Entities;

namespace MvcUrunSitesi.Models
{
    public class SepetViewModel
    {
        public Product UrunNesnesi { get; set; }
        public Sepet SepetNesnesi { get; set; }
    }
}