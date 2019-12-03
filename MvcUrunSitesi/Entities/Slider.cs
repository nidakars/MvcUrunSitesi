using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUrunSitesi.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public string Resim { get; set; }
        public string SliderAciklama { get; set; }
        public string SliderLink { get; set; }
    }
}