using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGEFront.Models
{
    public class Disciplina
    {
        [Display(Name = "Disciplina ID")]
        public int DisciplinaId { get; set; }
        [Display(Name = "Nome da Disciplina")]
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string DisciplinaNome { get; set; }
        public List<DisciplinasAlunos> DisciplinasAlunos { get; set; }
        public List<DisciplinasCursos> DisciplinasCursos { get; set; }
        [Display(Name = "Nome do Professor")]
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int ProfessorID_FK { get; set; }       
        public virtual Professor Professor { get; set; }
    }
}