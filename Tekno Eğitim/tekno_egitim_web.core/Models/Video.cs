using System;
using System.Collections.Generic;
using System.Text;

namespace tekno_egitim_web.core.Model
{
    public class Video
    {
        public int video_id { get; set; }
        public string baslik { get; set; }
        public string aciklama { get; set; }
        public DateTime olusturulma { get; set; }
        public string videoUrl { get; set; }
        public int kategori_id { get; set; }
        public bool video_silme { get; set; }
        public int izlenme_sayisi { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }
    }
}
