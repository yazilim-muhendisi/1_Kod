﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tekno_egitim_web.API.Data_Transfer_Objects
{
    public class KategoriWithBlogDto : KategoriDto
    {
    public ICollection<BlogDto> Blogs { get; set; }
    }
}
