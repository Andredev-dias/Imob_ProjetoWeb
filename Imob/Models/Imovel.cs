using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Imob.Models
{
    [Table("Imoveis")]
    public class Imovel : BaseModel
    {
        [Required(ErrorMessage = "Endereço é obrigatório!")]
        public string Endereco { get; set; }

        public bool Locado { get; set; }

        [ForeignKey("TipoImovelId")]
        [Required(ErrorMessage = "Tipo do imóvel é obrigatório!")]
        public int TipoImovelId { get; set; }

          
        [Required(ErrorMessage = "Cidade é obrigatório!")]
        public string Cidade { get; set; }


        [Required(ErrorMessage = "Estado é obrigatório!")]
        public string UF { get; set; }


        [Required(ErrorMessage = "Valor do aluguel é obrigatório!")]
        public double ValorAluguel { get; set; }


        [Required(ErrorMessage = "Área do imóvel é obrigatório!")]
        public double Area { get; set; }

        public string Imagem { get; set; }


        public virtual TipoImovel TipoImovel { get; set; }
    }
}