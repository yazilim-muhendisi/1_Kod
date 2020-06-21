using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Models;
using tekno_egitim_web.core.Repository;

namespace tekno_egitim_web.data.Repository
{
    public class UniversiteRepository : Repository<Universite>, IUniversite
    {
        private SiteDbContext applicationdbcontext { get => _context as SiteDbContext; }
        public UniversiteRepository(DbContext context) : base(context)
        {
        }

        public async Task<List<Universite>> GetUniversiteListAsync()
        {
            return await applicationdbcontext.Universites.ToListAsync();
             
        }
    }
}
