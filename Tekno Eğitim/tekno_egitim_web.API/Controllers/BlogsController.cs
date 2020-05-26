using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tekno_egitim_web.API.Data_Transfer_Objects;
using tekno_egitim_web.API.Filters;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Services;

namespace tekno_egitim_web.API.Controllers
{
    [Route("api/[controller]B")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogServices _blogservices;
        private readonly IMapper _mapper;
        public BlogsController(IBlogServices blogservices, IMapper mapper)
        {
            _blogservices = blogservices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blog = await _blogservices.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<BlogDto>>(blog));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogservices.GetByIdAsync(id);
            return Ok(_mapper.Map<BlogDto>(blog));
        }
        [HttpGet("{id}/kategori")]
        public async Task<IActionResult> GetWithKategoriById(int kategori_id)
        {
            var blog = await _blogservices.GetWithKategoriByIdAsync(kategori_id);
            return Ok(_mapper.Map<BlogWithKategoriDto>(blog));
        }
        [HttpPost]
        public async Task<IActionResult> Save(BlogDto blogdto)
        {

            var newblog = await _blogservices.AddAsync(_mapper.Map<Blog>(blogdto));
            return Created(string.Empty, _mapper.Map<BlogDto>(newblog));
        }
        [HttpPut]
        public IActionResult Update(BlogDto blogdto)
        {
            if (string.IsNullOrEmpty(blogdto.blog_id.ToString()) || blogdto.blog_id<=0)
            {
                throw new Exception("id alanı gereklidir.");
            }
            var blog = _blogservices.Update(_mapper.Map<Blog>(blogdto));
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int blog_id)
        {
            var blog = _blogservices.GetByIdAsync(blog_id).Result;
            return NoContent();
        }


    }
}