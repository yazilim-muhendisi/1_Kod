using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.core.Services
{
    public interface IVideoServices : IService<Video>
    {
        Task<Video> GetWithKategoriByIdAsync(int video_id);
    }
}
