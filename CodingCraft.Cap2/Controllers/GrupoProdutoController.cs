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
    public class GrupoProdutoController : Controller
    {
        private CodingCraftCap2Context context = new CodingCraftCap2Context();

        //
        // GET: /GrupoProduto/

        public ViewResult Index()
        {
            return View(context.GrupoProdutos.Include(grupoproduto => grupoproduto.Produtos).ToList());
        }

        //
        // GET: /GrupoProduto/Detalhes/5

        public ViewResult Detalhes(System.Guid id)
        {
            GrupoProduto grupoproduto = context.GrupoProdutos.Single(x => x.GrupoProdutoId == id);
            return View(grupoproduto);
        }

        //
        // GET: /GrupoProduto/Create

        public ActionResult Criar()
        {
            return View();
        } 

        //
        // POST: /GrupoProduto/Criar

        [HttpPost]
        public ActionResult Criar(GrupoProduto grupoproduto)
        {
            if (ModelState.IsValid)
            {
                grupoproduto.GrupoProdutoId = Guid.NewGuid();
                context.GrupoProdutos.Add(grupoproduto);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(grupoproduto);
        }
        
        //
        // GET: /GrupoProduto/Editar/5
 
        public ActionResult Editar(System.Guid id)
        {
            GrupoProduto grupoproduto = context.GrupoProdutos.Single(x => x.GrupoProdutoId == id);
            return View(grupoproduto);
        }

        //
        // POST: /GrupoProduto/Editar/5

        [HttpPost]
        public ActionResult Editar(GrupoProduto grupoproduto)
        {
            if (ModelState.IsValid)
            {
                context.Entry(grupoproduto).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoproduto);
        }

        //
        // GET: /GrupoProduto/Delete/5
 
        public ActionResult Excluir(System.Guid id)
        {
            GrupoProduto grupoproduto = context.GrupoProdutos.Single(x => x.GrupoProdutoId == id);
            return View(grupoproduto);
        }

        //
        // POST: /GrupoProduto/Excluir/5

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmed(System.Guid id)
        {
            GrupoProduto grupoproduto = context.GrupoProdutos.Single(x => x.GrupoProdutoId == id);
            context.GrupoProdutos.Remove(grupoproduto);
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