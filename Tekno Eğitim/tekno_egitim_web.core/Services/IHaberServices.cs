using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.core.Services
{
    public interface IHaberServices : IService<Haber>
    {
        Task<Haber> GetWithKategoriByIdAsync(int haber_id);
    }
}
