using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tekno_egitim_web.coreproject.Data_Transfer_Objects
{
    public class NotWithKategoriDto : NotDto
    {
        public KategoriDto Kategoriler { get; set; }
    }
}
