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
    public class AdministradorController : Controller
    {        //Serviços utilizados no controller
        AdministradorService administradorService = new AdministradorService();
        DisciplinaService disciplinaService = new DisciplinaService();


        //Buscando todos os administradors e retornando na view Index
        // GET: Administrador
        public ActionResult Index()
        {
            List<Administrador> listaAdministradors = new List<Administrador>();

            var administradors = administradorService.ListarAdministradores();

            return View(administradors);
        }

        //Buscando o administradors, carregando a lista de check box e retornando para a view Details
        // GET: Administrador/Details/5
        public ActionResult Details(int id)
        {
            var administrador = administradorService.BuscarAdministrador(id);


            return View(administrador);
        }

        //Chamada da view Create, para cadastrar novo administrador
        // GET: Administrador/Create
        public ActionResult Create()
        {

            //Preenchedo a ViewBag com as vagas, para carregar no dropdownlist
            

            Administrador administrador = new Administrador();


            //Buscando todas as tecnologias cadastradas, para retornar as opções como checkbox


            return View(administrador);
        }

        //Cadastrar o administrador
        // POST: Administrador/Create
        [HttpPost]
        public ActionResult Create(Administrador administrador)
        {


            //Efetivando o cadastro do administrador, utilizando o serviço de inclusão
            var administradorCreate = administradorService.IncluirAdministrador(administrador);

            return RedirectToAction(nameof(Index));



            return View(administrador);
        }

        //Chamada da view Edit, para editar um administrador
        // GET: Administrador/Edit/5
        public ActionResult Edit(int id)
        {


            //Realizando a busca do administrador, utilizando o serviço de busca
            var administradorEdit = administradorService.BuscarAdministrador(id);




            if (administradorEdit != null)
            {
                return View(administradorEdit);
            }
            return View(nameof(Index));
        }

        //Editar o administrador
        // POST: Administrador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Administrador administrador)
        {


            if (ModelState.IsValid)
            {
                //Efetivando a edição do administrador, utilizando o serviço de edição
                var administradorEdit = administradorService.EditarAdministrador(id, administrador);

                return RedirectToAction(nameof(Index));
            }

            return View(administrador);
        }

        //Chamada da view Delete, para exclusão de um administrador
        // GET: Administrador/Delete/5
        public ActionResult Delete(int id)
        {
            var administradorDelete = administradorService.BuscarAdministrador(id);

            return View(administradorDelete);

        }

        //Excluir o administrador
        // POST: Administrador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Administrador collection)
        {
            try
            {
                // Efetivando a exclusão do administrador, utilizando o serviço de exclusão
                var administradorDelete = administradorService.ExcluirAdministrador(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}