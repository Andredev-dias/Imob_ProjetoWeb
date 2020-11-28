
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Imob.Models
{
    public class UsuarioLogado : BaseModel
    {
        [Display(Name = "E-mail:")]
        [EmailAddress]
        [Required(ErrorMessage = "E-mail obrigatório!")]
        public string Email { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "Senha obrigatória!")]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da senha:")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem!")]
        public string ConfirmacaoSenha { get; set; }
    }
}
