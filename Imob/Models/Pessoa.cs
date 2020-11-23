using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    class Pessoa : BaseModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}