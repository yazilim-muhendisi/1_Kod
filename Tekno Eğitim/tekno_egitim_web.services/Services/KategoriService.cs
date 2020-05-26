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
    public class KategoriService : Service<Kategoriler>, IKategoriServices
    {
        public KategoriService(IUnitOfWork unitOfWork, IRepository<Kategoriler> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Kategoriler> GetWithBlogByIdAsycn(int kategori_id)
        {
            return await _unitOfWork.Kategoris.GetWithBlogByIdAsycn(kategori_id);
        }

        public async Task<Kategoriler> GetWithHaberByIdAsycn(int kategori_id)
        {
            return await _unitOfWork.Kategoris.GetWithHaberByIdAsycn(kategori_id);
        }

        public async Task<Kategoriler> GetWithMakaleByIdAsycn(int kategori_id)
        {
            return await _unitOfWork.Kategoris.GetWithMakaleByIdAsycn(kategori_id);
        }

        public async Task<Kategoriler> GetWithNotByIdAsycn(int kategori_id)
        {
            return await _unitOfWork.Kategoris.GetWithNotByIdAsycn(kategori_id);
        }

        public async Task<Kategoriler> GetWithVideoByIdAsycn(int kategori_id)
        {
            return await _unitOfWork.Kategoris.GetWithVideoByIdAsycn(kategori_id);
        }
    }
}
