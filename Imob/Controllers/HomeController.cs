using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Imob.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult InicialMenu()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
