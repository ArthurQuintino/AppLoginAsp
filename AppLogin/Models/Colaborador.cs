using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class Colaborador
    {
        [Display(Name = "Código", Description = "Código.")]
        public int Id { get; set; }
        [ValidateNever]

        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome")]
        [Required(ErrorMessage = "O Nome completo é obrigatorio")]
        public string Nome { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O Celular é obrigatorio")]
        public string Telefone { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string CPF { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O email não é Valido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email valido....")]
        public string Email { get; set; }


        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatoria")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        public string Senha { get; set; }


        [Display(Name = "Tipo")]
        public string? Tipo { get; set; }
    }
}
