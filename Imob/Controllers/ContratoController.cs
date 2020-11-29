using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Imob.DAL;
using Imob.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Imob.Controllers
{
    public class ContratoController : Controller
    {
        private readonly ContratoDAO _contratoDAO;
        private readonly IWebHostEnvironment _hosting;
        string _pathContratos = "C:/Users/Andrey/source/repos/Imob_ProjetoWeb/Imob/wwwroot/Contratos/";


        public ContratoController(ContratoDAO contratoDAO, IWebHostEnvironment hosting)
        {
            _contratoDAO = contratoDAO;
            _hosting = hosting;
        }

        public IActionResult CadastrarContrato()
        {
            return View();
        }

        public IActionResult ListaContratos(){
            List<Contrato> contratos;
            contratos = _contratoDAO.Listar();
            contratos.First().path = _pathContratos;
            return View(contratos);
        }

        public FileResult Download(string id)
        {

            int _arquivoId = Convert.ToInt32(id);
            var arquivo = _pathContratos + "contratoTeste.pdf";            
            //Os parametros para o arquivo são
            //1. o caminho do aruivo on servidor
            //2. o tipo de conteudo do tipo MIME
            //3. o parametro para o arquivos salvo pelo navegador*/
            return File(arquivo , "application/pdf", "contrato.pdf");
        }
    }
}
