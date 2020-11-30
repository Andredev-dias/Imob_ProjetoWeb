using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imob.Models
{
    [Table("Locatarios")]
    public class Locatario : Pessoa
    {
        [Required(ErrorMessage = "Renda disponível é obrigatório!")]
        public double RendaDisponivel { get; set; }
    }
}
