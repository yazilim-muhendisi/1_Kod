﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tekno_egitim_web.coreproject.Data_Transfer_Objects
{
    public class KategoriWithMakaleDto : KategoriDto
    {
        public ICollection<MakaleDto> Makales { get; set; }
    }
}
