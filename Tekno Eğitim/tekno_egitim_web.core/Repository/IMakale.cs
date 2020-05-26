using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.core.Repository
{
    public interface IMakale : IRepository<Makale>
    {
        Task<Makale> GetWithKategoriByIdAsycn(int makale_id);
    }
}
