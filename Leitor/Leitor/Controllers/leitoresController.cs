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
    public class leitoresController : Controller
    {

        private EFContext context = new EFContext();

        // GET: leitores
        public ActionResult Index()
        {
            return View(context.clientes.OrderBy(f => f.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (leitor cliente)
            {
                    context.clientes.Add(cliente);
                    context.SaveChanges();
                    return RedirectToAction("Index");
            }

        public ActionResult Edit (long? id)
            {
                    if (id == null)
                    {
                         return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                    }

                    leitor cliente = context.clientes.Find(id);
                    if (cliente == null)
                     {
                        return HttpNotFound();
                     }
            return View(cliente);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(leitor cliente)
            {
            if (ModelState.IsValid)
                {
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(cliente);
            }

        public ActionResult Details(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            leitor cliente = context.clientes.Find(id);
            if (cliente == null)
                {
                return HttpNotFound();
                }
            return View(cliente);
            }

        public ActionResult Delete(long? id)
            {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            leitor cliente = context.clientes.Find(id);
            if (cliente == null)
                {
                return HttpNotFound();
                }
            return View(cliente);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
            {
            leitor cliente = context.clientes.Find(id);
            context.clientes.Remove(cliente);
            context.SaveChanges();
            TempData["Message"] = "Leitor *" + cliente.Nome.ToUpper() + " FOI REMOVIDO ";
            return RedirectToAction("Index");
            }
        }
}