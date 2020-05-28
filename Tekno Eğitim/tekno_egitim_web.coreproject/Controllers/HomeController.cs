using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace tekno_egitim.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Anasayfa";
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
            return View();
        }
        public IActionResult Iletisim()
        {
            ViewData["Title"] = "İletisim";
            return View();
        }

    }
}