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
    public class HabersController : ControllerBase
    {
        private readonly IHaberServices _haberservices;
        private readonly IMapper _mapper;
        public HabersController(IHaberServices haberservices, IMapper mapper)
        {
            _haberservices = haberservices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var haber = await _haberservices.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<HaberDto>>(haber));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var haber = await _haberservices.GetByIdAsync(id);
            return Ok(_mapper.Map<HaberDto>(haber));
        }
        [HttpGet("{id}/kategori")]
        public async Task<IActionResult> GetWithKategoriById(int kategori_id)
        {
            var haber = await _haberservices.GetWithKategoriByIdAsync(kategori_id);
            return Ok(_mapper.Map<HaberWithKategoriDto>(haber));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(HaberDto haberdto)
        {
            var newhaber = await _haberservices.AddAsync(_mapper.Map<Haber>(haberdto));
            return Created(string.Empty, _mapper.Map<HaberDto>(newhaber));
        }
        [HttpPut]
        public IActionResult Update(HaberDto haberdto)
        {
            var haber = _haberservices.Update(_mapper.Map<Haber>(haberdto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int haber_id)
        {
            var haber = _haberservices.GetByIdAsync(haber_id).Result;
            return NoContent();
        }


    }
}