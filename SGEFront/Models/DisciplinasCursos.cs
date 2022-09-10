using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGEFront.Models
{
    public class DisciplinasCursos
    {
        public int Id { get; set; }
        public int CursoID_FK { get; set; }     
        public virtual Curso Curso { get; set; }
        public int DisciplinaID_FK { get; set; }     
        public virtual Disciplina Disciplina { get; set; }
    }
}
