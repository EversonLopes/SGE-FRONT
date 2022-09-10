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
    }
}
