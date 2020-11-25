using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("Contratos")]
    class Contrato : BaseModel
    {
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "Selecione um imóvel!")]
        public int ImovelId { get; set; }

        [Required(ErrorMessage = "Selecione um locatário!")]
        public int LocatarioId { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório!")]
        public double ValorAluguel { get; set; }

        [Required(ErrorMessage = "Comissão é obrigatório!")]
        public double ComissaoCorretor { get; set; }

        [Required(ErrorMessage = "Selecione um corretor!")]
        public int CorretorId { get; set; }

        public virtual Imovel Imovel { get; set; }
        public virtual Locatario Locatario { get; set; }
        public virtual Corretor Corretor { get; set; }
    }
}
