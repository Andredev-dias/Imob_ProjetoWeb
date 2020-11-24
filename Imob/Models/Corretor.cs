using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("Corretores")]
    class Corretor : Pessoa
    {
        [Required(ErrorMessage = "Número do Cofeci é obrigatório!")]
        public string Cofeci { get; set; }
     
    }
}
