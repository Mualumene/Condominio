using EasyCondominio.Contexto;
using EasyCondominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EasyCondominio.Controllers
{
    public class BlocosController : Controller
    {

        private EFContext context = new EFContext();

        // GET: Blocos
        public ActionResult Index()
        {
            ViewBag.CondominioId = new SelectList(context.Condominios.OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio");
            return View(context.Blocos.OrderBy(b => b.NumBloco));
        }

        public ActionResult Create()
        {
            ViewBag.CondominioId = new SelectList(context.Condominios.OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bloco bloco)
        {
            context.Blocos.Add(bloco);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bloco bloco = context.Blocos.Find(id);

            if (bloco == null)
            {
                return HttpNotFound();
            }

            ViewBag.CondominioId = new SelectList(context.Condominios.OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio", bloco.CondominioId);
            return View(bloco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                context.Entry(bloco).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloco);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bloco bloco = context.Blocos.Find(id);

            if (bloco == null)
            {
                return HttpNotFound();
            }

            ViewBag.CondominioId = new SelectList(context.Condominios.OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio", bloco.CondominioId);
            return View(bloco);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bloco bloco = context.Blocos.Find(id);

            if (bloco == null)
            {
                return HttpNotFound();
            }

            ViewBag.CondominioId = new SelectList(context.Condominios.OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio", bloco.CondominioId);
            return View(bloco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Bloco bloco = context.Blocos.Find(id);
            context.Blocos.Remove(bloco);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}