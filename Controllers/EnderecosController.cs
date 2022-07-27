using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCRUD.Models;
using ProjectCRUD.Repositories;

namespace ProjectCRUD.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly EnderecoRepository repository;
        public EnderecosController(IConfiguration configuration)
        {
            repository = new EnderecoRepository(configuration);
        }

        // GET: EnderecosController
        public IActionResult Index()
        {
            return View(repository.GetEnderecos().ToList());
        }

        // GET: EnderecosController/Create
        public IActionResult Adicionar()
        {
            return View();
        }

        // POST: EnderecosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar([Bind("Id, Endereco, CEP, Cidade, Estado")]EnderecoModel endereco)
        {
            if (ModelState.IsValid) 
            {
                repository.Adicionar(endereco);
                return RedirectToAction("Index");
            }
            return View(endereco);

        }

        // GET: EnderecosController/Edit/5
        public IActionResult Atualizar(int id)
        {

            EnderecoModel endereco = repository.Get(id);

            return View(endereco);
        }

        // POST: EnderecosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Atualizar(EnderecoModel endereco)
        {
            if (ModelState.IsValid)
            {
                repository.Atualizar(endereco);
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        // GET: EnderecosController/Delete/5
        public IActionResult Deletar(int id)
        {
            EnderecoModel endereco = repository.Get(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        // POST: EnderecosController/Delete/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            repository.Deletar(id);
            return RedirectToAction("Index");


        }
    }
}
