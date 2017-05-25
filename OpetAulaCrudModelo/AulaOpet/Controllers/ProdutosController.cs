using AulaOpet.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AulaOpet.Models;
using System.Net;

namespace AulaOpet.Controllers
{
    public class ProdutosController : Controller
    {
        private EfContext context = new EfContext();

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = context.Produtos.Include(context => context.Categoria).
                Include(f => f.Fornecedor).OrderBy(n => n.Nome);
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fornecedor).First();
            Fornecedor fornecedor = context.Fornecedores.Where(f => f.FornecedorId == id).Include("Produtos.Categoria").First();
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaID", "Nome");
            ViewBag.FornecedorId = new SelectList(context.Fornecedores.OrderBy(c => c.Nome), "FornecedorID", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                // TODO: Add insert logic here
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {

            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome", produto.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.Fornecedores.OrderBy(b => b.Nome), "FornecedorId", "Nome", produto.FornecedorId);
            return View(produto);

        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(produto).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch { return View(produto); }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fornecedor).First();
            if (produto == null) {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Produto produto = context.Produtos.Find(id); context.Produtos.Remove(produto);
                context.SaveChanges(); TempData["Message"] = "Produto	" + produto.Nome.ToUpper()
                                    + "	foi	removido"; return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
