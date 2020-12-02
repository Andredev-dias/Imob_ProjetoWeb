using Imob.DAL;
using Imob.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Imob.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class LocatarioAPIController : ControllerBase
    {

        private LocatarioDAO _locatarioDAO { get; set; }

        public LocatarioAPIController(LocatarioDAO locatarioDAO)
        {
            _locatarioDAO = locatarioDAO;
        }

        [Route("filtrar/{nome}")]
        [HttpGet]
        public List<Locatario> ListarLocatariosPorFiltro(string nome)
        {
            var Locatarios = _locatarioDAO.FiltrarPorParteNome(nome);
            return Locatarios;
        }
    }
}
