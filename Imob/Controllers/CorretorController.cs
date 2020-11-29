using System.Collections.Generic;
using Imob.DAL;
using Imob.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Imob.Controllers
{
    public class CorretorController : Controller
    {
        private readonly CorretorDAO _corretorDAO;
        private readonly IWebHostEnvironment _hosting;

        public CorretorController(CorretorDAO corretorDAO,
            IWebHostEnvironment hosting)
        {
            _corretorDAO = corretorDAO;
            _hosting = hosting;
        }

        public IActionResult ListaCorretores()
        {
            List<Corretor> corretores = _corretorDAO.Listar();
            return View(corretores);
        }

        // Cadastrar
        public IActionResult CadastrarCorretor() => View();

        [HttpPost]
        public IActionResult CadastrarCorretor(Corretor corretor)
        {
            _corretorDAO.Cadastrar(corretor);
            return RedirectToAction("ListaCorretores", "Corretor");
        }

        // Atualizar
        public IActionResult EditarCorretor(int id)
        {
            return View(_corretorDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult EditarCorretor(Corretor corretor)
        {   
            _corretorDAO.Atualizar(corretor);
            return RedirectToAction("ListaCorretores", "Corretor");
        }
        
        // Remover
        public IActionResult Remover(int id)
        {
            _corretorDAO.Remover(id);
            return RedirectToAction("ListaCorretores", "Corretor");
        }

    }
}
