using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Imob.Controllers
{
    public class LocatarioController : Controller
    {
        public IActionResult CadastrarLocatario()
        {
            return View();
        }
        public IActionResult ListaLocatarios()
        {
            return View();
        }
    }
}
