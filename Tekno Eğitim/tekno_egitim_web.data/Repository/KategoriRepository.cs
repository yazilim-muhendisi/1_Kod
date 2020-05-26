using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Repository;

namespace tekno_egitim_web.data.Repository
{
    public class KategoriRepository : Repository<Kategoriler>, IKategoriler
    {
        private ApplicationDbContext applicationdbcontext { get => _context as ApplicationDbContext; }
        public KategoriRepository(DbContext context) : base(context)
        {
        }
        public async Task<Kategoriler> GetWithBlogByIdAsycn(int kategori_id)
        {
            return await applicationdbcontext.Kategoris.Include(x => x.Blogs).SingleOrDefaultAsync(x => x.kategori_id == kategori_id);
        }

        public async Task<Kategoriler> GetWithMakaleByIdAsycn(int kategori_id)
        {
            return await applicationdbcontext.Kategoris.Include(x => x.Makales).SingleOrDefaultAsync(x => x.kategori_id == kategori_id);
        }

        public async Task<Kategoriler> GetWithVideoByIdAsycn(int kategori_id)
        {
            return await applicationdbcontext.Kategoris.Include(x => x.Videos).SingleOrDefaultAsync(x => x.kategori_id == kategori_id);
        }

        public async Task<Kategoriler> GetWithHaberByIdAsycn(int kategori_id)
        {
            return await applicationdbcontext.Kategoris.Include(x => x.Habers).SingleOrDefaultAsync(x => x.kategori_id == kategori_id);
        }

        public async Task<Kategoriler> GetWithNotByIdAsycn(int kategori_id)
        {
            return await applicationdbcontext.Kategoris.Include(x => x.Nots).SingleOrDefaultAsync(x => x.kategori_id == kategori_id);
        }
    }
}
