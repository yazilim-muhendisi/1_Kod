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
    public class VideoService : Service<Video>, IVideoServices
    {
        public VideoService(IUnitOfWork unitOfWork, IRepository<Video> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Video> GetWithKategoriByIdAsync(int video_id)
        {
            return await _unitOfWork.Videos.GetWithKategoriByIdAsycn(video_id);
        }
    }
}
