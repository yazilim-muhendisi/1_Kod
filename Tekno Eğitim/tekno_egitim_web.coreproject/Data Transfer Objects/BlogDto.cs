using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tekno_egitim_web.coreproject.Data_Transfer_Objects
{
    public class BlogDto
    {
        //Ekleme yapılabilir
        public int blog_id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş olamaz")]
        public string baslik { get; set; }
        public string aciklama { get; set; }
        public DateTime olusturulma { get; set; }
        public string imageUrl { get; set; }
        public int kategori_id { get; set; }

    }
}
