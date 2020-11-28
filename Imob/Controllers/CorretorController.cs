using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult CadastrarCorretor()
        {
            return View();
        }


        public IActionResult Atualizar(int id)
        {
            return View(_corretorDAO.BuscarPorId(id));
        }

        public IActionResult Atualizar(Corretor corretor)
        {
            _corretorDAO.Atualizar(corretor);
            return RedirectToAction("ListaCorretores");
        }
    }
}
