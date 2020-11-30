using Microsoft.AspNetCore.Mvc;
using Imob.Models;
using Imob.DAL;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Imob.Controllers
{
    public class ImovelController : Controller
    {
        private readonly ImovelDAO _imovelDAO;
        private readonly TipoImovelDAO _tipoImovelDAO;

        private readonly IWebHostEnvironment _hosting;

        public ImovelController(ImovelDAO imovelDAO, TipoImovelDAO tipoImovelDAO, IWebHostEnvironment hosting)
        {
            _imovelDAO = imovelDAO;
            _hosting = hosting;
            _tipoImovelDAO = tipoImovelDAO;
        }

        public IActionResult CardsImoveis()
        {
            List<Imovel> imoveis = _imovelDAO.Listar();
            return View(imoveis);
        }

        public IActionResult CadastrarImovel()
        {
            ViewBag.Title = "Cadastrar Imovel";
            ViewBag.TipoImovel = new SelectList(_tipoImovelDAO.Listar(), "Id", "Descricao");
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarImovel(Imovel imovel, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string arquivo = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    string caminho = Path.Combine(_hosting.WebRootPath, "Images", arquivo);
                    string dbImage = $"\\Images\\{arquivo}";
                    file.CopyTo(new FileStream(caminho, FileMode.CreateNew));
                    imovel.Imagem = dbImage;
                }
                else
                {
                    imovel.Imagem= "/Images/semimagem.gif";
                }

                _imovelDAO.Cadastrar(imovel);
                return RedirectToAction("CardsImoveis", "Imovel");

            }
            ModelState.AddModelError("", "Não foi possível cadastrar imóvel tente novamente!");
            return View(imovel);
         
        }

        public IActionResult EditarImovel()
        {
            return View();
        }
    }
}
