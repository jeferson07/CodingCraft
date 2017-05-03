using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodingCraft.Cap1.Models;
using CodingCraft.Cap1.Models.Entidades;

namespace CodingCraft.Cap1.Controllers
{
    public class CompraController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Compra
        [AuthorizeAttribute]
        public async Task<ActionResult> Index()
        {
            var compras = db.Compras.Include(c => c.Fornecedor);
            return View(await compras.ToListAsync());
        }

        // GET: Compra/Details/5
        [AuthorizeAttribute]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compra/Create
        [AuthorizeAttribute]
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome");
            return View();
        }

        // POST: Compra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute]
        public async Task<ActionResult> Create([Bind(Include = "CompraId,DataCompra,DataVencimento,DataPagamento,FornecedorId,DataModificacao,UsuarioModificacao,DataCriacao,UsuarioCriacao,ProdutoCompras")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                compra.CompraId = Guid.NewGuid();
                compra.ProdutoCompras.Select(pc => { pc.ProdutoCompraId = Guid.NewGuid(); return pc; }).ToList();
                db.Compras.Add(compra);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome", compra.FornecedorId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome");
            return View(compra);
        }

        // GET: Compra/Edit/5
        [AuthorizeAttribute]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome", compra.FornecedorId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome");
            return View(compra);
        }

        // POST: Compra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute]
        public async Task<ActionResult> Edit([Bind(Include = "CompraId,DataCompra,DataVencimento,DataPagamento,FornecedorId,DataModificacao,UsuarioModificacao,DataCriacao,UsuarioCriacao,ProdutoCompras")] Compra compra)
        {
            
            if (ModelState.IsValid)
            {
                compra.ProdutoCompras.Select(pc => { pc.CompraId = compra.CompraId; return pc; }).ToList();

                var list = compra.ProdutoCompras.Select(x => x.ProdutoCompraId);
                var produtosCompraDelete = db.ProdutoCompras.Where(pc => pc.CompraId == compra.CompraId && !list.Contains(pc.ProdutoCompraId));
                db.ProdutoCompras.RemoveRange(produtosCompraDelete);

                foreach (var produtoCompra in compra.ProdutoCompras)
                {
                    produtoCompra.Produto = null;

                    if (produtoCompra.ProdutoCompraId == Guid.Empty)
                    {
                        produtoCompra.ProdutoCompraId = Guid.NewGuid();
                        db.ProdutoCompras.Add(produtoCompra);
                    }
                    else
                    {
                        db.Entry(produtoCompra).State = EntityState.Modified;
                    }
                }

                db.Entry(compra).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome", compra.FornecedorId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome");
            return View(compra);
        }

        // GET: Compra/Delete/5
        [AuthorizeAttribute]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Compra compra = await db.Compras.FindAsync(id);
            db.Compras.Remove(compra);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Compra/Create
        [AuthorizeAttribute]
        public async Task<ActionResult> AdicionaProduto(Guid id)
        {
            var model = new ProdutoCompra();
            model.Produto = await db.Produtos.FindAsync(id);
            model.ProdutoId = model.Produto.ProdutoId;
            //model.ProdutoCompraId = Guid.NewGuid();

            return PartialView("_PartialProdutoCompra",model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
