using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("Locatarios")]
    class Locatario : Pessoa
    {
        public double RendaDisponivel { get; set; }
    }
}
