using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("Corretores")]
    class Corretor : Pessoa
    {
        public string Cofeci { get; set; }
        public string Sobrenome { get; set; }
        public string RG { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
