﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tekno_egitim_web.coreproject.Data_Transfer_Objects
{
    public class HaberDto
    {
        public int haber_id { get; set; }
        public string baslik { get; set; }
        public string aciklama { get; set; }
        public DateTime olusturulma { get; set; }
        public string imageUrl { get; set; }
        public int kategori_id { get; set; }
    }
}
