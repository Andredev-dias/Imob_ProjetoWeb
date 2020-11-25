using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Imob.Controllers
{
    public class CorretorController : Controller
    {
        public IActionResult CadastrarCorretor()
        {
            return View();
        }


        public IActionResult ListaCorretores()
        {
            return View();
        }
    }
}
