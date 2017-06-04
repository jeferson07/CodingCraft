using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodingCraft.Cap2.Models.Entities;
using CodingCraft.Cap2.Models;

namespace CodingCraft.Cap2.Controllers
{   
    public class ProdutoController : Controller
    {
        private CodingCraftCap2Context context = new CodingCraftCap2Context();

        //
        // GET: /Produto/

        public ViewResult Index()
        {
            return View(context.Produtos.Include(produto => produto.GrupoProduto).Include(produto => produto.Vendas).ToList());
        }

        //
        // GET: /Produto/Detalhes/5

        public ViewResult Detalhes(System.Guid id)
        {
            Produto produto = context.Produtos.Single(x => x.ProdutoId == id);
            return View(produto);
        }

        //
        // GET: /Produto/Create

        public ActionResult Criar()
        {
            ViewBag.PossibleGrupoProdutos = context.GrupoProdutos;
            return View();
        } 

        //
        // POST: /Produto/Criar

        [HttpPost]
        public ActionResult Criar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.ProdutoId = Guid.NewGuid();
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleGrupoProdutos = context.GrupoProdutos;
            return View(produto);
        }
        
        //
        // GET: /Produto/Editar/5
 
        public ActionResult Editar(System.Guid id)
        {
            Produto produto = context.Produtos.Single(x => x.ProdutoId == id);
            ViewBag.PossibleGrupoProdutos = context.GrupoProdutos;
            return View(produto);
        }

        //
        // POST: /Produto/Editar/5

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                context.Entry(produto).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleGrupoProdutos = context.GrupoProdutos;
            return View(produto);
        }

        //
        // GET: /Produto/Delete/5
 
        public ActionResult Excluir(System.Guid id)
        {
            Produto produto = context.Produtos.Single(x => x.ProdutoId == id);
            return View(produto);
        }

        //
        // POST: /Produto/Excluir/5

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmed(System.Guid id)
        {
            Produto produto = context.Produtos.Single(x => x.ProdutoId == id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}