using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCRUD.Models;
using ProjectCRUD.Repositories;

namespace ProjectCRUD.Controllers
{
    public class PessoasController : Controller
    {
        private readonly PessoaRepository repository;
        public PessoasController(IConfiguration configuration)
        {
            repository = new PessoaRepository(configuration);
        }

        // GET: PessoasController
        public IActionResult Index()
        {
            return View(repository.GetPessoas().ToList());
        }

        // GET: PessoasController/Create
        public IActionResult Adicionar() 
        {
            return View();
        }

        // POST: PessoasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar([Bind("Id, Nome, Telefone, CPF")] PessoaModel pessoa) 
        {
            if (ModelState.IsValid)
            {
                repository.Adicionar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);

        }

        // GET: PessoasController/Edit/5
        public IActionResult Atualizar(int id) 
        {
  
            PessoaModel pessoa = repository.Get(id);
            
            return View(pessoa);
        }

        // POST: PessoasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Atualizar([Bind("Nome, Telefone, CPF")]PessoaModel pessoa)  
        {
            if (ModelState.IsValid)
            {
                repository.Atualizar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: PessoasController/Delete/5
        public IActionResult Remover(int id) 
        {
            var pessoa = repository.Get(id);
            return View(pessoa);
        }

        // POST: PessoasController/Delete/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            repository.Deletar(id);
            return RedirectToAction("Index");

            
        }
    }
}
 