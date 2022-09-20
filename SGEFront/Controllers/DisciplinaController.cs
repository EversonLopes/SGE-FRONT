using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGEFront.Service;
using SGEFront.Util;
using SGEFront.Models;

namespace SGEFront.Controllers
{
    public class DisciplinaController : Controller
    {
        // GET: Disciplina
      DisciplinaService disciplinaService = new DisciplinaService();
        ProfessorService professorService = new ProfessorService(); 

        [HttpGet]
        public ActionResult Index()
        {
            var disciplinas = disciplinaService.ListarDisciplinas();

            return View(disciplinas);



        }  

        // GET: Disciplina/Details/5
        public ActionResult Details(int id)
        {
            var disciplinas = disciplinaService.BuscarDisciplina(id);
            return View(disciplinas);
        }

    


        // GET: Disciplina/Create
        public ActionResult Create()
        {
            ViewBag.Professores = new SelectList(professorService.ListarProfessores(), "ProfessorId", "Nome");

        
            return View(nameof(Create));
        }

        // POST: Disciplina/Create
        [HttpPost]
        public ActionResult Create(Disciplina disciplina)
        {

            if (ModelState.IsValid)
            {
                //Efetivando o cadastro da tecnologia, utilizando o serviço de inclusão
                var disciplinaCreate = disciplinaService.IncluirDisciplina(disciplina);

                return RedirectToAction(nameof(Index));
            }

            return View(disciplina);         
            

        
        }

        // GET: Disciplina/Edit/5
        public ActionResult Edit(int id)
        {
            var disciplinatoEdit = disciplinaService.BuscarDisciplina(id);

            if (disciplinatoEdit != null)
            {
                return View(disciplinatoEdit);
            }
            return View(nameof(Index));
        }

        // POST: Disciplina/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                //Efetivando a edição da tecnologia, utilizando o serviço de edição
                var disciplinaEdit = disciplinaService.EditarDisciplina(id, disciplina);

                return RedirectToAction(nameof(Index));
            }

            return View(disciplina);
        }


        //Chamada da view Delete, para exclusão de uma tecnologia
        // GET: Disciplina/Delete/5
        public ActionResult Delete(int id)
        {
            var disciplinaDelete = disciplinaService.BuscarDisciplina(id);

            return View(disciplinaDelete);
        }

        //Excluir a tecnologia
        // POST: Tecnologia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Disciplina collection)
        {
            try
            {
                // Efetivando a exclusão da tecnologia, utilizando o serviço de exclusão
                var disciplinaDelete = disciplinaService.ExcluirDisciplina(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
