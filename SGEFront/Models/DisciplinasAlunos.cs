using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGEFront.Models
{
    public class DisciplinasAlunos
    {
        public int Id { get; set; }
        public int AlunoID_FK { get; set; }
        public virtual Aluno Aluno { get; set; }
        public int DisciplinaID_FK { get; set; }   
        public virtual Disciplina Disciplina { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public int MediaFinal { get; set; }
        public bool DisciplinaAprovado { get; set; }
    }
}