using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SGEFront.Enums;

namespace SGEFront.Models
{
    public class Aluno
    {
        [Display(Name = "Aluno Id")]
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public NiveldePermissaoEnum NiveldePermissaoEnum { get; set; }

        public List<DisciplinasAlunos> DisciplinasAlunos { get; set; }
        public bool Status { get; set; }

        [Display(Name = "Curso")]
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int CursoID_FK { get; set; }       
        public virtual Curso Curso { get; set; }
        public Aluno()
        {
        }
    }
}