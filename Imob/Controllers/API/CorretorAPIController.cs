using Imob.DAL;
using Imob.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Imob.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorretorAPIController : ControllerBase
    {
        private CorretorDAO _coretorDAO { get; set; }

        public CorretorAPIController(CorretorDAO coretorDAO)
        {
            _coretorDAO = coretorDAO;
        }

        [Route("filtrar/{nome}")]
        [HttpGet]
        public List<Corretor> ListarLocatariosPorFiltro(string nome)
        {
            var Corretores = _coretorDAO.FiltrarPorParteNome(nome);
            return Corretores;
        }
    }
}
