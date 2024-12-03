using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace AppLogin.Models
{
    public class Cliente
    {
        [Display(Name = "Código", Description ="Código.")]
        public int Id { get; set; }

        [Display(Name ="Nome Completo", Description = "Nome e Sobrenome")]
        [Required(ErrorMessage ="O Nome completo é obrigatorio")]
        public string Nome { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "A data é obrigatorio")]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "O Sexo é obrigatorio")]
        [StringLength(1, ErrorMessage ="Deve conter apenas 1 Caractere")]
        public string Sexo { get; set; }


        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string CPF { get; set; }


        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone é obrigatorio")]
        public string Telefone { get; set; }


        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O email não é Valido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Informe um email valido....")]
        public string Email { get; set; }


        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatoria")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        public string Senha { get; set; }


        [Display(Name = "Situação")]
        [Required(ErrorMessage = "A situação é Obrigatoria")]
        public string Situacao { get; set; }
    }
}
