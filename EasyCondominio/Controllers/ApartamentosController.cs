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
    public class ApartamentosController : Controller
    {

        private EFContext context = new EFContext();

        // GET: Apartamentos
        public ActionResult Index()
        {
            ViewBag.BlocoId = new SelectList(context.Blocos.OrderBy(b => b.NumBloco), "BlocoId", "NumBloco");
            ViewBag.ProprietarioId = new SelectList(context.Proprietarios.OrderBy(p => p.Nome), "ProprietarioId", "Nome");
            return View(context.Apartamentos.OrderBy(a => a.NumApto));
        }

        public ActionResult Create()
        {
            ViewBag.BlocoId = new SelectList(context.Blocos.OrderBy(b => b.NumBloco), "BlocoId", "NumBloco");
            ViewBag.ProprietarioId = new SelectList(context.Proprietarios.OrderBy(p => p.Nome), "ProprietarioId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Apartamento apartamento)
        {
            context.Apartamentos.Add(apartamento);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Apartamento apartamento = context.Apartamentos.Find(id);

            if (apartamento == null)
            {
                return HttpNotFound();
            }

            ViewBag.BlocoId = new SelectList(context.Blocos.OrderBy(b => b.NumBloco), "BlocoId", "NumBloco", apartamento.BlocoId);
            ViewBag.ProprietarioId = new SelectList(context.Proprietarios.OrderBy(p => p.Nome), "ProprietarioId", "Nome", apartamento.ProprietarioId);
            return View(apartamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                context.Entry(apartamento).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apartamento);
        }
    }
}