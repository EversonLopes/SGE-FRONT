using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SGEFront.Util
{
    public class RestApi
    {
        //Métodos dos modelo candidato
        public string ListarAlunos = "Alunoes";
        public string BuscarAluno = "Alunoes/{0}";
        public string SalvarAluno = "Alunoes";
        public string EditarAluno = "Alunoes/{0}";
        public string DeletarAluno = "Alunoes/{0}";

        public string ListarAdministradores = "Administradors";
        public string BuscarAdministrador = "Administradors/{0}";
        public string SalvarAdministrador = "Administradors";
        public string EditarAdministrador = "Administradors/{0}";
        public string DeletarAdministrador = "Administradors/{0}";

        public string ListarProfessores = "Professors";
        public string BuscarProfessor = "Professors/{0}";
        public string SalvarProfessor = "Professors";
        public string EditarProfessor = "Professors/{0}";
        public string DeletarProfessor = "Professors/{0}";

        public string ListarFuncionarios = "Funcionarios";
        public string BuscarFuncionario = "Funcionarios/{0}";
        public string SalvarFuncionario = "Funcionarios";
        public string EditarFuncionario = "Funcionarios/{0}";
        public string DeletarFuncionario = "Funcionarios/{0}";

        //Métodos dos modelo tecnologia
        public string ListarDisciplinas = "Disciplinas"; 
        public string BuscarDisciplina = "Disciplinas/{0}";
        public string SalvarDisciplina = "Disciplinas";
        public string EditarDisciplina = "Disciplinas/{0}";
        public string DeletarDisciplina = "Disciplinas/{0}";

        //Métodos dos modelo vaga
        public string ListarCursos = "Cursoes";
        public string BuscarCurso = "Cursoes/{0}";
        public string SalvarCurso = "Cursoes";
        public string EditarCurso = "Cursoes/{0}";
        public string DeletarCurso = "Cursoes/{0}";



        //Método que defini a uri, que é informada no arquivo web.config e o tipo de texto que será transferido
        public HttpClient BaseUrl()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["RestApi"].ToString());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

    }
}