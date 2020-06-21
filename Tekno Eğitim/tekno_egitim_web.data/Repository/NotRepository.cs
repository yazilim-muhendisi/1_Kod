using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Repository;

namespace tekno_egitim_web.data.Repository
{
    public class NotRepository : Repository<Not>, INot
    {
        private SiteDbContext applicationdbcontext { get => _context as SiteDbContext; }
        public NotRepository(DbContext context) : base(context)
        {
        }

        public async Task<Not> GetWithKategoriByIdAsycn(int not_id)
        {
            return await applicationdbcontext.Nots.Include(x => x.not_id).SingleOrDefaultAsync
                  (x => x.not_id == not_id);
        }
    }
}
