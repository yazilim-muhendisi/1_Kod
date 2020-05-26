using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Services;
using tekno_egitim_web.coreproject.Data_Transfer_Objects;
using tekno_egitim_web.coreproject.Filters;

namespace tekno_egitim_web.coreproject.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IKategoriServices _kategoriservices;
        private readonly IMapper _mapper;
        public KategoriController(IKategoriServices kategoriservices, IMapper mapper)
        {
            _kategoriservices = kategoriservices;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var kategori = await _kategoriservices.GetAllAsync();
            return View(_mapper.Map<IEnumerable<KategoriDto>>(kategori));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(KategoriDto kategoriDto)
        {
            await _kategoriservices.AddAsync(_mapper.Map<Kategoriler>(kategoriDto));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var kategori = await _kategoriservices.GetByIdAsync(id);

            return View(_mapper.Map<KategoriDto>(kategori));
        }

        [HttpPost]
        public IActionResult Update(KategoriDto kategoriDto)
        {
            _kategoriservices.Update(_mapper.Map<Kategoriler>(kategoriDto));

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var kategori = _kategoriservices.GetByIdAsync(id).Result;

            _kategoriservices.Remove(kategori);

            return RedirectToAction("Index");
        }




    }
}