using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("Contratos")]
    class Contrato : BaseModel
    {
        public DateTime DataVencimento { get; set; }
        public int ImovelId { get; set; }
        public int LocatarioId { get; set; }
        public double ValorAluguel { get; set; }
        public double ComissaoCorretor { get; set; }
        public int CorretorId { get; set; }

        public virtual Imovel Imovel { get; set; }
        public virtual Locatario Locatario { get; set; }
        public virtual Corretor Corretor { get; set; }
    }
}
