using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGEFront.Service;
using SGEFront.Models;

namespace SGEFront.Controllers
{
    public class AlunoController : Controller
    {

        AlunoService alunoService = new AlunoService();
      
       CursoService cursoService = new CursoService();
        ProfessorService professorService = new ProfessorService();
        DisciplinaService disciplinaService = new DisciplinaService();  


        // GET: Aluno
        public ActionResult Index()
        {
            List<Aluno> listaAlunos = new List<Aluno>();

            var alunos = alunoService.ListarAlunos();

            return View(alunos);
        }


        //Buscando o alunos, carregando a lista de check box e retornando para a view Details
        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {
            var aluno = alunoService.BuscarAluno(id);


            return View(aluno);
        }

        //Chamada da view Create, para cadastrar novo aluno
        // GET: Aluno/Create
        public ActionResult Create()
        {

            //Preenchedo a ViewBag com as vagas, para carregar no dropdownlist
            ViewBag.Cursos = new SelectList(cursoService.ListarCursos(), "CursoId", "CursoNome");

            Aluno aluno = new Aluno();


            //Buscando todas as tecnologias cadastradas, para retornar as opções como checkbox


            return View(aluno);
        }

        //Cadastrar o aluno
        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {

          
            //Efetivando o cadastro do aluno, utilizando o serviço de inclusão
            var alunoCreate = alunoService.IncluirAluno(aluno);

            return RedirectToAction(nameof(Index));



            return View(aluno);
        }

        //Chamada da view Edit, para editar um aluno
        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {


            //Realizando a busca do aluno, utilizando o serviço de busca
            var alunoEdit = alunoService.BuscarAluno(id);




            if (alunoEdit != null)
            {
                return View(alunoEdit);
            }
            return View(nameof(Index));
        }

        //Editar o aluno
        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Aluno aluno)
        {


            if (ModelState.IsValid)
            {
                //Efetivando a edição do aluno, utilizando o serviço de edição
                var alunoEdit = alunoService.EditarAluno(id, aluno);

                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

        //Chamada da view Delete, para exclusão de um aluno
        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            var alunoDelete = alunoService.BuscarAluno(id);

            return View(alunoDelete);

        }

        //Excluir o aluno
        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Aluno collection)
        {
            try
            {
                // Efetivando a exclusão do aluno, utilizando o serviço de exclusão
                var alunoDelete = alunoService.ExcluirAluno(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



 

        public ActionResult CadastrarNotasAlunos(int id) {

            var aluno = alunoService.BuscarAluno(id);
            var professor=professorService.BuscarProfessor(id);
            var curso = cursoService.BuscarCurso(aluno.CursoID_FK);
            var lista = aluno.DisciplinasAlunos;
            var lista2 = curso.DisciplinasCursos;


            ViewBag.Alunos = new SelectList(alunoService.ListarAlunos().Where( o => o.CursoID_FK==aluno.Curso.CursoId), "AlunoId", "Nome");
            ViewBag.Disciplinas = new SelectList(disciplinaService.ListarDisciplinas().Where(o => lista2.Any(o2 => o2.DisciplinaID_FK == o.DisciplinaId)), "DisciplinaId", "DisciplinaNome"); ;





            return View(lista);
        }



        [HttpPost]
        public ActionResult CadastrarNotasAlunos(int id, DisciplinasAlunos disciplinasAlunos)
        {


            var aluno = alunoService.BuscarAluno(id);            
            //aluno.DisciplinasAlunos = new List<DisciplinasAlunos>();            
            

            DisciplinasAlunos disciplinaAluno = new DisciplinasAlunos();

            disciplinaAluno.AlunoID_FK = aluno.AlunoId;
            disciplinaAluno.DisciplinaID_FK = disciplinasAlunos.DisciplinaID_FK;
            disciplinaAluno.Nota1 = disciplinasAlunos.Nota1;
            disciplinaAluno.Nota2 = disciplinasAlunos.Nota2;
            disciplinaAluno.MediaFinal = ((disciplinaAluno.Nota1) + (disciplinaAluno.Nota2)) / 2;


            aluno.DisciplinasAlunos.Add(disciplinaAluno);                         




            if (ModelState.IsValid)
            {
                //Efetivando a edição da tecnologia, utilizando o serviço de edição
                var alunoEdit = alunoService.EditarAluno(id, aluno);

                return RedirectToAction(nameof(Index));
            }

            return View("Index");



        }

        [HttpGet]
        public ActionResult MostrarInfoAlunos(int id)
        {
            var buscarAluno = alunoService.BuscarAluno(id);

            for (int i = 0; i < buscarAluno.DisciplinasAlunos.Count; i++)
            {
                buscarAluno.DisciplinasAlunos[i].Aluno = new Aluno();
                buscarAluno.DisciplinasAlunos[i].Aluno.AlunoId = buscarAluno.AlunoId;
                buscarAluno.DisciplinasAlunos[i].Aluno.Nome = buscarAluno.Nome;

                i = i++;
            }


            var lista = buscarAluno.DisciplinasAlunos;

            //retorna a lista de tecnologias da vaga, para ser apresentada na view, e ter a opções de cadastro de peso.
            return View(lista);

        }
    }
}
