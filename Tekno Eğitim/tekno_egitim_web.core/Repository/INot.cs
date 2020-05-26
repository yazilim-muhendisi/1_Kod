using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.core.Repository
{
    public interface INot : IRepository<Not>
    {
        Task<Not> GetWithKategoriByIdAsycn(int not_id);
    }
}
