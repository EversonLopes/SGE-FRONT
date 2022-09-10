using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGEFront.Service;
using SGEFront.Models;
using SGEFront.Util;
namespace SGEFront.Controllers
{
    public class ProfessorController : Controller
    {        //Serviços utilizados no controller
        ProfessorService professorService = new ProfessorService();
        DisciplinaService disciplinaService = new DisciplinaService();


        //Buscando todos os professors e retornando na view Index
        // GET: Professor
        public ActionResult Index()
        {
            List<Professor> listaProfessors = new List<Professor>();

            var professors = professorService.ListarProfessores();

            return View(professors);
        }

        //Buscando o professors, carregando a lista de check box e retornando para a view Details
        // GET: Professor/Details/5
        public ActionResult Details(int id)
        {
            var professor = professorService.BuscarProfessor(id);


            return View(professor);
        }

        //Chamada da view Create, para cadastrar novo professor
        // GET: Professor/Create
        public ActionResult Create()
        {

            //Preenchedo a ViewBag com as vagas, para carregar no dropdownlist
            ViewBag.Disciplinas = new SelectList(disciplinaService.ListarDisciplinas(), "DisciplinaId", "DisciplinaNome");

            Professor professor = new Professor();


            //Buscando todas as tecnologias cadastradas, para retornar as opções como checkbox


            return View(professor);
        }

        //Cadastrar o professor
        // POST: Professor/Create
        [HttpPost]
        public ActionResult Create(Professor professor)
        {


            //Efetivando o cadastro do professor, utilizando o serviço de inclusão
            var professorCreate = professorService.IncluirProfessor(professor);

            return RedirectToAction(nameof(Index));



            return View(professor);
        }

        //Chamada da view Edit, para editar um professor
        // GET: Professor/Edit/5
        public ActionResult Edit(int id)
        {


            //Realizando a busca do professor, utilizando o serviço de busca
            var professorEdit = professorService.BuscarProfessor(id);




            if (professorEdit != null)
            {
                return View(professorEdit);
            }
            return View(nameof(Index));
        }

        //Editar o professor
        // POST: Professor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Professor professor)
        {


            if (ModelState.IsValid)
            {
                //Efetivando a edição do professor, utilizando o serviço de edição
                var professorEdit = professorService.EditarProfessor(id, professor);

                return RedirectToAction(nameof(Index));
            }

            return View(professor);
        }

        //Chamada da view Delete, para exclusão de um professor
        // GET: Professor/Delete/5
        public ActionResult Delete(int id)
        {
            var professorDelete = professorService.BuscarProfessor(id);                  
            
                return View(professorDelete);           
            
        }

        //Excluir o professor
        // POST: Professor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Professor collection)
        {
            try
            {
                // Efetivando a exclusão do professor, utilizando o serviço de exclusão
                var professorDelete = professorService.ExcluirProfessor(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

  
    }
}