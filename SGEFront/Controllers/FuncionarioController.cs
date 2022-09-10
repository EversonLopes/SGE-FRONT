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
    public class FuncionarioController : Controller
    {        //Serviços utilizados no controller
        FuncionarioService funcionarioService = new FuncionarioService();
        DisciplinaService disciplinaService = new DisciplinaService();


        //Buscando todos os funcionarios e retornando na view Index
        // GET: Funcionario
        public ActionResult Index()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            var funcionarios = funcionarioService.ListarFuncionarios();

            return View(funcionarios);
        }

        //Buscando o funcionarios, carregando a lista de check box e retornando para a view Details
        // GET: Funcionario/Details/5
        public ActionResult Details(int id)
        {
            var funcionario = funcionarioService.BuscarFuncionario(id);


            return View(funcionario);
        }

        //Chamada da view Create, para cadastrar novo funcionario
        // GET: Funcionario/Create
        public ActionResult Create()
        {

            //Preenchedo a ViewBag com as vagas, para carregar no dropdownlist


            Funcionario funcionario = new Funcionario();


            //Buscando todas as tecnologias cadastradas, para retornar as opções como checkbox


            return View(funcionario);
        }

        //Cadastrar o funcionario
        // POST: Funcionario/Create
        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {


            //Efetivando o cadastro do funcionario, utilizando o serviço de inclusão
            var funcionarioCreate = funcionarioService.IncluirFuncionario(funcionario);

            return RedirectToAction(nameof(Index));



            return View(funcionario);
        }

        //Chamada da view Edit, para editar um funcionario
        // GET: Funcionario/Edit/5
        public ActionResult Edit(int id)
        {


            //Realizando a busca do funcionario, utilizando o serviço de busca
            var funcionarioEdit = funcionarioService.BuscarFuncionario(id);




            if (funcionarioEdit != null)
            {
                return View(funcionarioEdit);
            }
            return View(nameof(Index));
        }

        //Editar o funcionario
        // POST: Funcionario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Funcionario funcionario)
        {


            if (ModelState.IsValid)
            {
                //Efetivando a edição do funcionario, utilizando o serviço de edição
                var funcionarioEdit = funcionarioService.EditarFuncionario(id, funcionario);

                return RedirectToAction(nameof(Index));
            }

            return View(funcionario);
        }

        //Chamada da view Delete, para exclusão de um funcionario
        // GET: Funcionario/Delete/5
        public ActionResult Delete(int id)
        {
            var funcionarioDelete = funcionarioService.BuscarFuncionario(id);

            return View(funcionarioDelete);

        }

        //Excluir o funcionario
        // POST: Funcionario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Funcionario collection)
        {
            try
            {
                // Efetivando a exclusão do funcionario, utilizando o serviço de exclusão
                var funcionarioDelete = funcionarioService.ExcluirFuncionario(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}