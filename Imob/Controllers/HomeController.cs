using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imob.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult InicialMenu()
        {
            if (User.Identity.IsAuthenticated) // Validação para debug
            {
                return View();
            }
            return View("Index", "Usuario");
        }
    }
}
