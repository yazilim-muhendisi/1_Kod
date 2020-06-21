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
    public class NotsController : ControllerBase
    {
        private readonly INotServices _notservices;
        private readonly IMapper _mapper;
        public NotsController(INotServices notservices, IMapper mapper)
        {
            _notservices = notservices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var not = await _notservices.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<NotDto>>(not));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var not = await _notservices.GetByIdAsync(id);
            return Ok(_mapper.Map<NotDto>(not));
        }
        [HttpGet("{id}/kategori")]
        public async Task<IActionResult> GetWithKategoriById(int kategori_id)
        {
            var not = await _notservices.GetWithKategoriByIdAsync(kategori_id);
            return Ok(_mapper.Map<NotWithKategoriDto>(not));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(NotDto notdto)
        {
            var newnot = await _notservices.AddAsync(_mapper.Map<Not>(notdto));
            return Created(string.Empty, _mapper.Map<NotDto>(newnot));
        }
        [HttpPut]
        public IActionResult Update(NotDto notdto)
        {
            var not = _notservices.Update(_mapper.Map<Not>(notdto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int not_id)
        {
            var not = _notservices.GetByIdAsync(not_id).Result;
            return NoContent();
        }

    }
}