using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Imob.Controllers
{
    public class ContratoController : Controller
    {
        public IActionResult CadastrarContrato()
        {
            return View();
        }
    }
}
