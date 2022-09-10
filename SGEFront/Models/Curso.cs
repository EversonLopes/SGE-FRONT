using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGEFront.Models
{
    public class Curso
    {
        [Display(Name = "Curso Id")] 
        public int CursoId { get; set; }
        [Display(Name = "Curso")]
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string CursoNome { get; set; }
        public ICollection<Aluno> Alunos { get; set; }        
        public List<DisciplinasCursos> DisciplinasCursos { get; set; }
    }
}