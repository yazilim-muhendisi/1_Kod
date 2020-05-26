using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Repository;

namespace tekno_egitim_web.data.Repository
{
    public class HaberRepository : Repository<Haber>, IHaber
    {
        private ApplicationDbContext applicationdbcontext { get => _context as ApplicationDbContext; }
        public HaberRepository(DbContext context) : base(context)
        {
        }

        public async Task<Haber> GetWithKategoriByIdAsycn(int haber_id)
        {
            return await applicationdbcontext.Habers.Include(x => x.haber_id).SingleOrDefaultAsync
                 (x => x.haber_id == haber_id);
        }
    }
}
