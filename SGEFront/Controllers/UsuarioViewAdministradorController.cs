using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGEFront.Models;
using SGEFront.Service;
namespace SGEFront.Controllers
{
    public class UsuarioViewAdministradorController : Controller
    {
        AdministradorService administradorService = new AdministradorService();
        CursoService cursoService = new CursoService();
        DisciplinaService disciplinaService = new DisciplinaService();
        AlunoService alunoService = new AlunoService();
        ProfessorService professorService = new ProfessorService();

        // GET: Usuario
        public ActionResult Index()
        {
            
            UsuarioViewAdministrador admin = new UsuarioViewAdministrador();

            ViewBag.Cursos = new SelectList(cursoService.ListarCursos(), "CursoId", "CursoNome");

            var adm = administradorService.ListarAdministradores();
            var curso = cursoService.ListarCursos();
            var disciplina = disciplinaService.ListarDisciplinas();
            var aluno = alunoService.ListarAlunos();
            var professor = professorService.ListarProfessores();

            admin.viewAdministrador = adm;
            admin.viewCurso = curso;
            admin.viewDisciplina=disciplina;
            admin.viewAluno = aluno;
            admin.viewProfessor = professor;    
           
            return View(admin);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
