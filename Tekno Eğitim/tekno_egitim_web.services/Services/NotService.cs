using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Services;
using tekno_egitim_web.core.UnitOfWorks;

namespace tekno_egitim_web.services.Services
{
    public class NotService : Service<Not>, INotServices
    {
        public NotService(IUnitOfWork unitOfWork, core.Repository.IRepository<Not> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Not> GetWithKategoriByIdAsync(int not_id)
        {
            return await _unitOfWork.Nots.GetWithKategoriByIdAsycn(not_id);
        }
    }
}
