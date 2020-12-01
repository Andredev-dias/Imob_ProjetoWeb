using System.Collections.Generic;
using Imob.DAL;
using Imob.Models;
using Imob.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Imob.Controllers
{
    public class ContratoController : Controller
    {
        private readonly ContratoDAO _contratoDAO;
        private readonly ImovelDAO _imovelDAO;
        private readonly LocatarioDAO _locatarioDAO;
        private readonly CorretorDAO _corretorDAO;
        private readonly GeradorDePDFUtils _geradorDePDF;

        public ContratoController(ContratoDAO contratoDAO, ImovelDAO imovelDAO, LocatarioDAO locatarioDAO, CorretorDAO corretorDAO, IWebHostEnvironment hosting)
        {
            _contratoDAO = contratoDAO;
            _imovelDAO = imovelDAO;
            _locatarioDAO = locatarioDAO;
            _corretorDAO = corretorDAO;
            _geradorDePDF = new GeradorDePDFUtils(hosting);
        }

        public IActionResult CadastrarContrato()
        {
            ViewBag.Title = "Corretores";
            ViewBag.Corretores = new SelectList(_corretorDAO.Listar(), "Id", "Nome");

            ViewBag.Title = "Locatario";
            ViewBag.Locatario = new SelectList(_locatarioDAO.Listar(), "Id", "Nome");

            ViewBag.Title = "Imoveis";
            ViewBag.Imoveis = new SelectList(_imovelDAO.Listar(), "Id", "Endereco");

            return View();
        }

        [HttpPost]
        public IActionResult CadastrarContrato(Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                var Corretor = _corretorDAO.BuscarPorId(contrato.CorretorId);
                var Locatario = _locatarioDAO.BuscarPorId(contrato.LocatarioId);
                var Imovel = _imovelDAO.BuscarPorId(contrato.ImovelId);
                contrato.Imovel = Imovel;
                contrato.Corretor = Corretor;
                contrato.Locatario = Locatario;
                contrato.ValorAluguel = Imovel.ValorAluguel;
                contrato.ComissaoCorretor = (Imovel.ValorAluguel / 100) * 2;

                var arquivo = _geradorDePDF.GetPdf(contrato);
                contrato.Arquivo = arquivo;
                _contratoDAO.Cadastrar(contrato);
                return RedirectToAction("ListaContratos", "Contrato");
            }
            ModelState.AddModelError("", "Não foi possível cadastrar contrato tente novamente!");
            return View(contrato);
        }

        public IActionResult ListaContratos(){
            List<Contrato> contratos;
            contratos = _contratoDAO.Listar();
            return View(contratos);
        }
    }
}
