using System;
using System.Collections.Generic;
using System.Text;

namespace tekno_egitim_web.core.Models
{
    public class VideoIzlenme
    {
        public int id { get; set; }
        public int video_id { get; set; }
        public int izlenme_sayisi { get; set; }
    }
}
