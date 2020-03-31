using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Models
{
    public class Pessoa
    {
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        [Required]
        [MinLength(9, ErrorMessage = "O CEP deve conter 9 caracteres")]
        public string CEP { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [Required]
        public string Cidade { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        [Required]
        public string Logradouro { get; set; }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        [Required]
        public string Nacionalidade { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        [MinLength(2, ErrorMessage = "O nome deve conter pelo menos 2 caracteres")]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        [Required]
        [MinLength(2, ErrorMessage = "O sobrenome deve conter pelo menos 2 caracteres")]
        public string Sobrenome { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [Required]
        [MinLength(14, ErrorMessage = "O CPF deve conter 14 caracteres")]
        public string CPF { get; set; }

        /// <summary>
        /// Telefone
        /// <//summary>
        [MinLength(9, ErrorMessage = "O telefone deve conter pelo menos 9 caracteres")]
        public string Telefone { get; set; }
    }
}
