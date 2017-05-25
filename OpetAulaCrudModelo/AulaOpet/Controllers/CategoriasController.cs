using AulaOpet.Contexts;
using AulaOpet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaOpet.Controllers
{
    public class CategoriasController : Controller
    {


        #region [Propriedades]
        private EfContext context = new EfContext();
        #endregion
        // GET: Fornecedor


        #region [Actions]
        public ActionResult Index()
        {
            var fornecedor = context.Categorias.OrderBy(s => s.Nome);
            return View(fornecedor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria cat)
        {
            context.Categorias.Add(cat);
            context.SaveChanges();
            TempData["Message"] = "Categoria " + cat.Nome.ToUpper() + " foi inserida";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Categoria cat = context.Categorias.Where(c => c.CategoriaId == id).First();
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria cat)
        {
            Categoria categ = context.Categorias.Where(c => c.CategoriaId == cat.CategoriaId).First();
            categ.Nome = cat.Nome;
            context.SaveChanges();
            TempData["Message"] = "Categoria " + categ.Nome.ToUpper() + " foi alterada";
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult Details(int id)
        {
            Categoria categ = context.Categorias.Where(c => c.CategoriaId == id).First();
            return View(categ);
        }


        public ActionResult Delete(int id)
        {
            Categoria categ = context.Categorias.Where(c => c.CategoriaId == id).First();
            //categoriaList.Remove(categoria);
            //return RedirectToAction("Index");
            return View(categ);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categ = context.Categorias.Where(c => c.CategoriaId == id).First();
            context.Categorias.Remove(categ);
            context.SaveChanges();
            TempData["Message"] = "Categoria " + categ.Nome.ToUpper() + " foi removida";
            return RedirectToAction("Index");
            //return View(categoria);
        }
    }


}