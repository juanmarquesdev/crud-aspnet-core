using CadastroProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly _DbContext _db;

        public ProdutosController(_DbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Produtos> objProdutosList = _db.produtos;
            return View(objProdutosList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produtos objct)
        {

            IEnumerable<Produtos> objProdutosList = _db.produtos;
            foreach(var linha in objProdutosList)
            {
                if (objct.Descricao == linha.Descricao)
                {
                    ModelState.AddModelError("Descricao", "O produto já está cadastrado");
                }
            }
            if(ModelState.IsValid)
            {
                _db.produtos.Add(objct);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objct);
        }

        public IActionResult Update(int? id)
        {
            if(id == null || id == 0) 
            {
                return NotFound();
            }
            var produtoFromDb = _db.produtos.Find(id);

            if(produtoFromDb == null) 
            {
                return NotFound();
            }

            return View(produtoFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Produtos objct)
        {
            if(ModelState.IsValid)
            {
                _db.produtos.Update(objct);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objct);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0) 
            {
                return NotFound();
            }
            var produtoFromDb = _db.produtos.Find(id);

            if(produtoFromDb == null) 
            {
                return NotFound();
            }

            return View(produtoFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            
            var objct = _db.produtos.Find(id);
            if(objct == null) 
            {
                return NotFound();
            }

            _db.produtos.Remove(objct);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}