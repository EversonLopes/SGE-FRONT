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
    public class CursoController : Controller
    {
        // GET: Curso
        CursoService cursoService = new CursoService();
        DisciplinaService disciplinaService = new DisciplinaService();
        [HttpGet]
        public ActionResult Index()
        {
            var cursos = cursoService.ListarCursos();

            return View(cursos);



        }

        // GET: Curso/Details/5
        public ActionResult Details(int id)
        {
            var cursos = cursoService.BuscarCurso(id);
            return View(cursos);
        }




        // GET: Curso/Create
        public ActionResult Create()
        {
            ViewBag.Disciplinas = new SelectList(disciplinaService.ListarDisciplinas(), "DisciplinaId", "DisciplinaNome");            

            return View(nameof(Create));
        }

        // POST: Curso/Create
        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            curso.DisciplinasCursos = new List<DisciplinasCursos>();

            if (ModelState.IsValid)
            {
                //Efetivando o cadastro da tecnologia, utilizando o serviço de inclusão
                var cursoCreate = cursoService.IncluirCurso(curso);

                return RedirectToAction(nameof(Index));
            }

            return View(curso);



        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int id)
        {
            var cursotoEdit = cursoService.BuscarCurso(id);

            if (cursotoEdit != null)
            {
                return View(cursotoEdit);
            }
            return View(nameof(Index));
        }

        // POST: Curso/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Curso curso)
        {

            if (ModelState.IsValid)
            {
                //Efetivando a edição da tecnologia, utilizando o serviço de edição
                var cursoEdit = cursoService.EditarCurso(id, curso);

                return RedirectToAction(nameof(Index));
            }

            return View(curso);
        }


        //Chamada da view Delete, para exclusão de uma tecnologia
        // GET: Curso/Delete/5
        public ActionResult Delete(int id)
        {
            var cursoDelete = cursoService.BuscarCurso(id);

            return View(cursoDelete);
        }

        //Excluir a tecnologia
        // POST: Tecnologia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Curso collection)
        {
            try
            {
                // Efetivando a exclusão da tecnologia, utilizando o serviço de exclusão
                var cursoDelete = cursoService.ExcluirCurso(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DiscCurso(int id)
        {
            //Busca a vaga
            var curso = cursoService.BuscarCurso(id);
            List<DisciplinasCursos> disciplinasCursos = new List<DisciplinasCursos> ();
            curso.DisciplinasCursos = new List<DisciplinasCursos>();

            ViewBag.Disciplinas = new SelectList(disciplinaService.ListarDisciplinas(), "DisciplinaId", "DisciplinaNome");
            ViewBag.Cursos = new SelectList(cursoService.ListarCursos(), "CursoId", "CursoNome");

            //retorna a lista de tecnologias da vaga, para ser apresentada na view, e ter a opções de cadastro de peso.
            return View(disciplinasCursos);
        }



        // GET: Curso/Create
        public ActionResult AdicionarDisciplina(int id)
        {
            var curso = cursoService.BuscarCurso(id);


            ViewBag.Disciplinas = new SelectList(disciplinaService.ListarDisciplinas(), "DisciplinaId", "DisciplinaNome");
            ViewBag.Cursos = new SelectList(cursoService.ListarCursos(), "CursoId", "CursoNome");
            var lista = curso.DisciplinasCursos;

            return View(lista);

        }
        

        // POST: Curso/Create
        [HttpPost]
        public ActionResult AdicionarDisciplina(int id,DisciplinasCursos disciplinasCursos)
        {

          
            var curso = cursoService.BuscarCurso(id);
            curso.DisciplinasCursos = new List<DisciplinasCursos>();

            DisciplinasCursos disciplinaCurso = new DisciplinasCursos();

            disciplinaCurso.CursoID_FK = curso.CursoId;
            disciplinaCurso.DisciplinaID_FK = disciplinasCursos.DisciplinaID_FK;
            
            curso.DisciplinasCursos.Add(disciplinaCurso);
            

           // vagaTecnologia.VagaId = vaga.VagaId;
           // vagaTecnologia.TecnologiaId = item.Id;

           // vaga.VagasTecnologias.Add(vagaTecnologia);


            if (ModelState.IsValid)
            {
                //Efetivando a edição da tecnologia, utilizando o serviço de edição
                var cursoEdit = cursoService.EditarCurso(id, curso);

                return RedirectToAction(nameof(Index));
            }

            return View("Index");       



        
        }
        [HttpGet]
        public ActionResult MostrarDisciplinasCurso(int id)
        {
            var cursos = cursoService.BuscarCurso(id);



            //Atualiza os dados da lista referente a objeto vaga. 

            for (int i = 0; i < cursos.DisciplinasCursos.Count; i++)
            {
                cursos.DisciplinasCursos[i].Curso = new Curso();
                cursos.DisciplinasCursos[i].Curso.CursoId = cursos.CursoId;
                cursos.DisciplinasCursos[i].Curso.CursoNome = cursos.CursoNome;              

                i = i++;
            }

            var lista = cursos.DisciplinasCursos;

            //retorna a lista de tecnologias da vaga, para ser apresentada na view, e ter a opções de cadastro de peso.
            return View(lista);


              
          
        }


    }
}
