using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Repository;

namespace tekno_egitim_web.data.Repository
{
    public class MakaleRepository : Repository<Makale>, IMakale
    {
        private SiteDbContext applicationdbcontext { get => _context as SiteDbContext; }
        public MakaleRepository(DbContext context) : base(context)
        {
        }

        public async Task<Makale> GetWithKategoriByIdAsycn(int makale_id)
        {
            return await applicationdbcontext.Makales.Include(x => x.makale_id).SingleOrDefaultAsync
               (x => x.makale_id == makale_id);
        }
    }
}
