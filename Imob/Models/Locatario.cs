using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imob.Models
{
    [Table("Locatarios")]
    public class Locatario : Pessoa
    {
        [Required(ErrorMessage = "Renda disponível é obrigatório!")]
        public double RendaDisponivel { get; set; }

        [Required(ErrorMessage = "RG é obrigatório!")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "DataNascimento é obrigatório!")]
        public DateTime DataNascimento { get; set; }
    }
}
