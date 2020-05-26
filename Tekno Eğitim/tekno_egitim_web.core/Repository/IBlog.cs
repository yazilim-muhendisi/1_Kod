﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.core.Repository
{
    public interface IBlog : IRepository<Blog>
    {
        Task<Blog> GetWithKategoriByIdAsycn(int blog_id);
    }
}
