using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("Locatarios")]
    public class Locatario : Pessoa
    {
        [Required(ErrorMessage = "Renda disponível é obrigatório!")]
        public double RendaDisponivel { get; set; }
    }
}
