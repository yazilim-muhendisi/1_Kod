using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Repository;

namespace tekno_egitim_web.data.Repository
{
    public class BlogRepository : Repository<Blog>, IBlog
    {
        private SiteDbContext applicationdbcontext { get => _context as SiteDbContext; }
        public BlogRepository(DbContext context) : base(context)
        {
        }

        public async Task<Blog> GetWithKategoriByIdAsycn(int blog_id)
        {
            return await applicationdbcontext.Blogs.Include(x => x.blog_id).SingleOrDefaultAsync
               (x => x.blog_id == blog_id);
        }
    }
}
