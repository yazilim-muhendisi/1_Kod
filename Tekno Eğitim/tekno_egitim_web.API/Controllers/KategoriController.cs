using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tekno_egitim_web.API.Data_Transfer_Objects;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Services;

namespace tekno_egitim_web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriServices _kategoriservices;
        private readonly IMapper _mapper;
        public KategoriController(IKategoriServices kategoriservices, IMapper mapper)
        {
            _kategoriservices = kategoriservices;
            _mapper = mapper;
        }

        [HttpGet("{id}/blogs")]
        public async Task<IActionResult> GetWithBlogById(int blog_id)
        {
            var kategori = await _kategoriservices.GetWithBlogByIdAsycn(blog_id);
            return Ok(_mapper.Map<KategoriWithBlogDto>(kategori));

        }
        [HttpGet("{id}/habers")]
        public async Task<IActionResult> GetWithHaberById(int haber_id)
        {
            var kategori = await _kategoriservices.GetWithHaberByIdAsycn(haber_id);
            return Ok(_mapper.Map<KategoriWithHaberDto>(kategori));

        }
        [HttpGet("{id}/makales")]
        public async Task<IActionResult> GetWithMakaleById(int makale_id)
        {
            var kategori = await _kategoriservices.GetWithMakaleByIdAsycn(makale_id);
            return Ok(_mapper.Map<KategoriWithMakaleDto>(kategori));

        }
        [HttpGet("{id}/nots")]
        public async Task<IActionResult> GetWithNotById(int not_id)
        {
            var kategori = await _kategoriservices.GetWithNotByIdAsycn(not_id);
            return Ok(_mapper.Map<KategoriWithNotDto>(kategori));

        }
        [HttpGet("{id}/videos")]
        public async Task<IActionResult> GetWithVideoById(int video_id)
        {
            var kategori = await _kategoriservices.GetWithVideoByIdAsycn(video_id);
            return Ok(_mapper.Map<KategoriWithVideoDto>(kategori));

        }
        [HttpPost]
        public async Task<IActionResult> Save(KategoriDto kategoridto)
        {
            var kategori = await _kategoriservices.AddAsync(_mapper.Map<Kategoriler>(kategoridto));
            return Created(string.Empty, _mapper.Map<KategoriDto>(kategoridto));
        }
        [HttpPut]
        public IActionResult Update(KategoriDto kategoridto)
        {
            var kategori = _kategoriservices.Update(_mapper.Map<Kategoriler>(kategoridto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var kategori = _kategoriservices.GetByIdAsync(id).Result;
            _kategoriservices.Remove(kategori);
            return NoContent();
        }


    }
}