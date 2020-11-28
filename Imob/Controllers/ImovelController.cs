using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Imob.Controllers
{
    public class ImovelController : Controller
    {
        public IActionResult CardsImoveis()
        {
            return View();
        }

        public IActionResult CadastrarImovel()
        {
            return View();
        }

        public IActionResult EditarImovel()
        {
            return View();
        }
    }
}
