using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    class Pessoa : BaseModel
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório!")]
        public string UF { get; set; }

    }
}