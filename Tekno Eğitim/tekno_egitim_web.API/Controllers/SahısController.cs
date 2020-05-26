using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tekno_egitim_web.core.Models;
using tekno_egitim_web.core.Services;

namespace tekno_egitim_web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SahısController : ControllerBase
    {
        private readonly IService<Sahıs> _sahısservices;
        public SahısController(IService<Sahıs> sahısservices)
        {
            _sahısservices = sahısservices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sahıs = await _sahısservices.GetAllAsync();
            return Ok(sahıs);
        }
        //insert, update, delete metotlarını eklemeyi unutma
        // dto dönüştür
        [HttpPost]
        public async Task<IActionResult> Save(Sahıs sahıs)
        {
            var newsahis = await _sahısservices.AddAsync(sahıs);
            return Ok(newsahis);
        }

    }
}