using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("TipoImovel")]
    class TipoImovel : BaseModel
    {
        public int Comissao { get; set; }
        public string Descricao { get; set; }
    }
}