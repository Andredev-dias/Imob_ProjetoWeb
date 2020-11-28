using Imob.DAL;
using Imob.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Imob.Controllers
{
    public class LocatarioController : Controller
    {
        private readonly LocatarioDAO _locatarioDAO;
        private readonly IWebHostEnvironment _hosting;

        public LocatarioController(LocatarioDAO locatarioDAO,
            IWebHostEnvironment hosting)

        {
            _locatarioDAO = locatarioDAO;
            _hosting = hosting;
        }
        public IActionResult ListaLocatarios()
        {
            List<Locatario> locatario = _locatarioDAO.Listar();
            return View(locatario);
        }

        // Cadastrar
        public IActionResult CadastrarLocatario()
        {
            return View();
        }
        
        //Remover
        public IActionResult Remover(int id)
        {
            _locatarioDAO.Remover(id);
            return RedirectToAction("ListaLocatarios");
        }

        public IActionResult EditarLocatario()
        {
            return View();
        }
    }
}
