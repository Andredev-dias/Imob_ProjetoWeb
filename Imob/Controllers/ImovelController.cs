using Microsoft.AspNetCore.Mvc;
using Imob.Models;
using Imob.DAL;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace Imob.Controllers
{
    public class ImovelController : Controller
    {
        private readonly ImovelDAO _imovelDAO;
        private readonly IWebHostEnvironment _hosting;

        public ImovelController(ImovelDAO imovelDAO,
            IWebHostEnvironment hosting)
        {
            _imovelDAO = imovelDAO;
            _hosting = hosting;
        }

        public IActionResult CardsImoveis()
        {
            List<Imovel> imoveis = _imovelDAO.Listar();
            return View(imoveis);
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
