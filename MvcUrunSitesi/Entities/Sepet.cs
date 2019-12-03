using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUrunSitesi.Entities
{
    public class Sepet
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string SepetKullanici { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}