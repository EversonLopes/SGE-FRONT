using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGEFront.Models
{
    public class UsuarioViewAdministrador
    {
        public List<Administrador> viewAdministrador { get; set; }              
        public List<Aluno> viewAluno { get; set; }
        public List<Funcionario> viewFuncionario { get; set; }
        public List<Professor> viewProfessor { get; set; }
        public List<Curso> viewCurso { get; set; }
        public List<Disciplina> viewDisciplina { get; set; }
        public DisciplinasCursos viewdiscCursos { get; set; }
        public DisciplinasAlunos viewdiscAlunos { get; set; }

    }
}