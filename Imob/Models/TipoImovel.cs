using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("TipoImovel")]
    class TipoImovel : BaseModel
    {
        [Required(ErrorMessage = "Comissão é obrigatório!")]
        public int Comissao { get; set; }

        [Required(ErrorMessage = "Descrição do imóvel é obrigatória!")]
        public string Descricao { get; set; }
    }
}