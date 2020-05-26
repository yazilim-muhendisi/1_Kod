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
    public class MakalesController : ControllerBase
    {
        private readonly IMakaleServices _makaleservices;
        private readonly IMapper _mapper;
        public MakalesController(IMakaleServices makaleservices, IMapper mapper)
        {
            _makaleservices = makaleservices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var makale = await _makaleservices.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<MakaleDto>>(makale));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var makale = await _makaleservices.GetByIdAsync(id);
            return Ok(_mapper.Map<MakaleDto>(makale));
        }
        [HttpGet("{id}/kategori")]
        public async Task<IActionResult> GetWithKategoriById(int kategori_id)
        {
            var makale = await _makaleservices.GetWithKategoriByIdAsync(kategori_id);
            return Ok(_mapper.Map<MakaleWithKategoriDto>(makale));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(MakaleDto makaledto)
        {
            var newmakale = await _makaleservices.AddAsync(_mapper.Map<Makale>(makaledto));
            return Created(string.Empty, _mapper.Map<MakaleDto>(newmakale));
        }
        [HttpPut]
        public IActionResult Update(MakaleDto makaledto)
        {
            var makale = _makaleservices.Update(_mapper.Map<Makale>(makaledto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int makale_id)
        {
            var makale = _makaleservices.GetByIdAsync(makale_id).Result;
            return NoContent();
        }


    }
}