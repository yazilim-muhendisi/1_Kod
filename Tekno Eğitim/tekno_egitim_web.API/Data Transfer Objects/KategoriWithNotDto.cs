﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tekno_egitim_web.API.Data_Transfer_Objects
{
    public class KategoriWithNotDto : KategoriDto
    {
        public ICollection<NotDto> Nots { get; set; }
    }
}
