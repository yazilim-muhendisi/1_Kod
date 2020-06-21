using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.core.Services
{
    public interface IBlogServices  : IService<Blog>
    {
        Task<Blog> GetWithKategoriByIdAsync(int blog_id);
        //veritabanı hariç yapacağımız kodlar
        Task BlogKaydet(Blog data);

        //Kategoriye özgü metotlar tanımlanır.
        //TagHelper
        //Hesaplama
    }
}
