using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("Imoveis")]
    class Imovel : BaseModel
    {
        public string Endereco { get; set; }
        public bool Locado { get; set; }
        public int TipoImovelId { get; set; }
        public virtual TipoImovel TipoImovel { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public double ValorAluguel { get; set; }
        public double Area { get; set; }

    }
}