using AulaOpet.Contexts;
using AulaOpet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaOpet.Controllers
{
    public class FornecedorController : Controller
    {

        #region [Propriedades]
        private EfContext context = new EfContext();
        #endregion
        // GET: Fornecedor


        #region [Actions]
        public ActionResult Index()
        {
            var fornecedor = context.Fornecedores.OrderBy(s => s.Nome);
            return View(fornecedor);
        } 

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fornecedor fornecedor)
        {
            context.Fornecedores.Add(fornecedor);
            context.SaveChanges();
            TempData["Message"] = "Fornecedor " + fornecedor.Nome.ToUpper() + " foi inserido";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Fornecedor fornecedor = context.Fornecedores.Where(c => c.FornecedorId == id).First();
            return View(fornecedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fornecedor fornecedor)
        {
            var fornec = context
                .Fornecedores
                .Where(c => c.FornecedorId == fornecedor.FornecedorId)
                .First();
            fornec.Nome = fornecedor.Nome;
            context.SaveChanges();
            TempData["Message"] = "Fornecedor " + fornecedor.Nome.ToUpper() + " foi alterado";
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult Details(int id)
        {
            var fornecedor = context
                .Fornecedores
                .Where(c => c.FornecedorId == id)
                .First();
            return View(fornecedor);
        }


        public ActionResult Delete(int id)
        {
            Fornecedor fornecedor = context.Fornecedores.Where(c => c.FornecedorId == id).First();
            //categoriaList.Remove(categoria);
            //return RedirectToAction("Index");
            return View(fornecedor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fornecedor fornecedor = context.Fornecedores.Where(c => c.FornecedorId == id).First();
            context.Fornecedores.Remove(fornecedor);
            context.SaveChanges();
            TempData["Message"] = "Fornecedor " + fornecedor.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
            //return View(categoria);
        }
    }
}