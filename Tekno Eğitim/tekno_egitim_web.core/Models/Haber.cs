using System;
using System.Collections.Generic;
using System.Text;

namespace tekno_egitim_web.core.Model
{
    public class Haber
    {
        public int haber_id { get; set; }
        public string baslik { get; set; }
        public string aciklama { get; set; }
        public DateTime olusturulma { get; set; }
        public string imageUrl { get; set; }
        public int kategori_id { get; set; }
        public bool haber_silme { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
    }
}
