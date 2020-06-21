using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tekno_egitim_web.API.Data_Transfer_Objects
{
    public class KategoriDto
    {
        public int kategori_id { get; set; }
        //client yeni bir nesne göndereceği zaman o isteğin bodysinde burası görüntülenir.
        [Required]
        public string kategori_ad { get; set; }
        //Bu alan zorunlu oldu. Eğer kategori adı girmezse hata alır. 
    }
}
