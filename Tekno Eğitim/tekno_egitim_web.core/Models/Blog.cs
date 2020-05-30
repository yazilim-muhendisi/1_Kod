using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tekno_egitim_web.core.Model
{
    public class Blog
    {
        [Required]
        public int blog_id { get; set; }
        [Required]
        public string baslik { get; set; }
        [Required]
        public string aciklama { get; set; }
        [Required]
        public DateTime olusturulma { get; set; }
        public string imageUrl { get; set; }
        public int kategori_id { get; set; }
        public bool blog_silme { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }

    }
}
