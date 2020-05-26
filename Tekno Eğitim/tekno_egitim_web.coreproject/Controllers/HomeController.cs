using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tekno_egitim_web.coreproject.Data_Transfer_Objects;

namespace tekno_egitim_web.coreproject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorDto errordto)
        {
            return View(errordto);
        }
    }
}