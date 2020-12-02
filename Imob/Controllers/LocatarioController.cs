using Imob.DAL;
using Imob.Models;
using Imob.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Imob.Controllers
{
    [Authorize]
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
            List<Locatario> locatarios = _locatarioDAO.Listar();
            return View(locatarios);
        }

        // Cadastrar
        public IActionResult CadastrarLocatario() => View();

        [HttpPost]
        public IActionResult CadastrarLocatario(Locatario locatario)
        {
            if (ModelState.IsValid)
            {
                if (ValidacaoCpfUtils.ValidarCpf(locatario.Cpf))
                {
                    _locatarioDAO.Cadastrar(locatario);
                    return RedirectToAction("ListaLocatarios", "Locatario");
                }
                ModelState.AddModelError("", "CPF Inválido");
            }
            ModelState.AddModelError("","Não foi possível cadastrar! Digite todos os campos e tente novamente!");
            return View(locatario);
        }

        // Atualizar
        public IActionResult EditarLocatario(int id)
        {
            return View(_locatarioDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult EditarLocatario(Locatario locatario)
        {
            _locatarioDAO.Atualizar(locatario);
            return RedirectToAction("ListaLocatarios", "Locatario");
        }

        //Remover
        public IActionResult Remover(int id)
        {
            _locatarioDAO.Remover(id);
            return RedirectToAction("ListaLocatarios", "Locatario");
        }

    }
}
