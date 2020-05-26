using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Repository;
using tekno_egitim_web.core.Services;
using tekno_egitim_web.core.UnitOfWorks;

namespace tekno_egitim_web.services.Services
{
    public class HaberService : Service<Haber>, IHaberServices
    {
        public HaberService(IUnitOfWork unitOfWork, IRepository<Haber> repository) : base(unitOfWork, repository)
        {
        }
        public async Task<Haber> GetWithKategoriByIdAsync(int haber_id)
        {
            return await _unitOfWork.Habers.GetWithKategoriByIdAsycn(haber_id);
        }
    }
}
