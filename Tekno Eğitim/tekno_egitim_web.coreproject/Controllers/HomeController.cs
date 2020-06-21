using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tekno_egitim_web.core.Services;
using tekno_egitim_web.coreproject.Data_Transfer_Objects;
using tekno_egitim_web.coreproject.Models;
using tekno_egitim_web.data;

namespace tekno_egitim.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUniversiteServices _services;
        private readonly IVideoServices _videoServices;

        public HomeController(IUniversiteServices service, IVideoServices videoServices)
        {
            _services = service;
            _videoServices = videoServices;
        }
        public IActionResult Index()
        {

            ViewData["Title"] = "Anasayfa";
            SessionObject._universiteler = _services.GetUniversiteListAsync().Result.ToList();

            return View();
        }
        public IActionResult Hakkimizda()
        {
            ViewData["Title"] = "Hakkimizda";
            return View();
        }
        public IActionResult Kurs()
        {
            ViewData["Title"] = "Enler";
            return View();
        }
        public IActionResult Etkinlik()
        {
            ViewData["Title"] = "Etkinlikler";
            return View();
        }
        public IActionResult Blog()
        {
            ViewData["Title"] = "Üniversiteler";

            ViewData["videolar"] = _videoServices.GetAllAsync().Result.ToList();

            return View();
        }
        public IActionResult Iletisim()
        {
            ViewData["Title"] = "İletisim";
            return View();
        }

    }
}