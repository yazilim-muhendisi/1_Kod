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
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoServices _videoservices;
        private readonly IMapper _mapper;
        public VideosController(IVideoServices videoservices, IMapper mapper)
        {
            _videoservices = videoservices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var video = await _videoservices.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<VideoDto>>(video));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var video = await _videoservices.GetByIdAsync(id);
            return Ok(_mapper.Map<VideoDto>(video));
        }
        [HttpGet("{id}/kategori")]
        public async Task<IActionResult> GetWithKategoriById(int kategori_id)
        {
            var video = await _videoservices.GetWithKategoriByIdAsync(kategori_id);
            return Ok(_mapper.Map<VideoWithKategoriDto>(video));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(VideoDto videodto)
        {
            var newvideo = await _videoservices.AddAsync(_mapper.Map<Video>(videodto));
            return Created(string.Empty, _mapper.Map<VideoDto>(newvideo));
        }
        [HttpPut]
        public IActionResult Update(VideoDto videodto)
        {
            var video = _videoservices.Update(_mapper.Map<Video>(videodto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int video_id)
        {
            var video = _videoservices.GetByIdAsync(video_id).Result;
            return NoContent();
        }

    }
}