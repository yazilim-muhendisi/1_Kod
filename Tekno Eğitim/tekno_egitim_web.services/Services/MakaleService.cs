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
    public class MakaleService : Service<Makale>, IMakaleServices
    {
        public MakaleService(IUnitOfWork unitOfWork, IRepository<Makale> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Makale> GetWithKategoriByIdAsync(int makale_id)
        {
            throw new NotImplementedException();
        }
    }
}
