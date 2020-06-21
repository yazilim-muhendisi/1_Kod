using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Models;

namespace tekno_egitim_web.core.Repository
{
    public interface IUniversite : IRepository<Universite>
    {
        Task<List<Universite>> GetUniversiteListAsync();
    }
}
