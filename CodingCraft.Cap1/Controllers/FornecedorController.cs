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
    public class FornecedorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fornecedor
        [AuthorizeAttribute]
        public async Task<ActionResult> Index()
        {
            return View(await db.Fornecedors.ToListAsync());
        }

        // GET: Fornecedor/Details/5
        [AuthorizeAttribute]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = await db.Fornecedors.FindAsync(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        [AuthorizeAttribute]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute]
        public async Task<ActionResult> Create([Bind(Include = "FornecedorId,Nome,DataModificacao,UsuarioModificacao,DataCriacao,UsuarioCriacao")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                fornecedor.FornecedorId = Guid.NewGuid();
                db.Fornecedors.Add(fornecedor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/5
        [AuthorizeAttribute]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = await db.Fornecedors.FindAsync(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute]
        public async Task<ActionResult> Edit([Bind(Include = "FornecedorId,Nome,DataModificacao,UsuarioModificacao,DataCriacao,UsuarioCriacao")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        [AuthorizeAttribute]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = await db.Fornecedors.FindAsync(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeAttribute]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Fornecedor fornecedor = await db.Fornecedors.FindAsync(id);
            db.Fornecedors.Remove(fornecedor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
