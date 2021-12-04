using Leitor.Context;
using Leitor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Leitor.Controllers
{
    public class LivrosController : Controller
    {

        private EFContext context = new EFContext();

        // GET: Livros
        public ActionResult Index()
        {
            return View(context.livros.OrderBy(f => f.Nome_Autor));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
            {
            context.livros.Add(livro);
            context.SaveChanges();
            return RedirectToAction("Index");
            }

        public ActionResult Edit(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }

            Livro livro = context.livros.Find(id);
            if (livro == null)
                {
                return HttpNotFound();
                }
            return View(livro);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Livro livro)
            {
            if (ModelState.IsValid)
                {
                context.Entry(livro).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(livro);
            }

        public ActionResult Details(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Livro livro = context.livros.Find(id);
            if (livro == null)
                {
                return HttpNotFound();
                }
            return View(livro);
            }

        public ActionResult Delete(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Livro livro = context.livros.Find(id);
            if (livro == null)
                {
                return HttpNotFound();
                }
            return View(livro);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
            {
            Livro livro = context.livros.Find(id);
            context.livros.Remove(livro);
            context.SaveChanges();
            TempData["Message"] = "Livro *" + livro.Nome_Autor.ToUpper() + " FOI REMOVIDO ";
            return RedirectToAction("Index");
            }
        }
}