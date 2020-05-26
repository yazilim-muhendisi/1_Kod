using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Repository;

namespace tekno_egitim_web.data.Repository
{
    public class VideoRepository : Repository<Video>, IVideo
    {
        private ApplicationDbContext applicationdbcontext { get => _context as ApplicationDbContext; }
        public VideoRepository(DbContext context) : base(context)
        {
        }

        public async Task<Video> GetWithKategoriByIdAsycn(int video_id)
        {
            return await applicationdbcontext.Videos.Include(x => x.video_id).SingleOrDefaultAsync
     (x => x.video_id == video_id);
        }
    }
}
