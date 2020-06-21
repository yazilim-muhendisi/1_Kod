﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Models;

namespace tekno_egitim_web.core.Services
{
    public interface IUniversiteServices  : IService<Universite>
    {
        Task<IEnumerable<Universite>> GetUniversiteListAsync();
       
    }
}
