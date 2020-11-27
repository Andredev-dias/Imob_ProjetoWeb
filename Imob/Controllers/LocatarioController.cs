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
