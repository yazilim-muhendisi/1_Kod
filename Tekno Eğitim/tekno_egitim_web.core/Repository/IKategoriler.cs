using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.core.Repository
{
   public interface IKategoriler : IRepository<Kategoriler>
    {
        Task<Kategoriler> GetWithBlogByIdAsycn(int kategori_id);
        Task<Kategoriler> GetWithMakaleByIdAsycn(int kategori_id);
        Task<Kategoriler> GetWithVideoByIdAsycn(int kategori_id);
        Task<Kategoriler> GetWithHaberByIdAsycn(int kategori_id);
        Task<Kategoriler> GetWithNotByIdAsycn(int kategori_id);
    }
}
