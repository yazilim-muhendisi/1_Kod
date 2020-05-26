using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Services;
using tekno_egitim_web.core.UnitOfWorks;
using tekno_egitim_web.core.Repository;

namespace tekno_egitim_web.services.Services
{
    public class BlogService : Service<Blog>, IBlogServices
    {
        public BlogService(IUnitOfWork unitOfWork, IRepository<Blog> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Blog> GetWithKategoriByIdAsync(int blog_id)
        {
            return await _unitOfWork.Blogs.GetWithKategoriByIdAsycn(blog_id);
        }
    }
}
