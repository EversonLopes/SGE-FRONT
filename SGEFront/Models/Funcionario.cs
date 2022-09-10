using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SGEFront.Enums;

namespace SGEFront.Models
{
    public class Funcionario
    {

        [Display(Name = "Funcionario Id")]
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public NiveldePermissaoEnum NiveldePermissaoEnum { get; set; }
    }
}