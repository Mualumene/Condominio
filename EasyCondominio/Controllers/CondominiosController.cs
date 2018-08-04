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

    [Authorize]
    public class CondominiosController : Controller
    {

        private EFContext context = new EFContext();
       
        public ActionResult Index()
        {
            return View(context.Condominios.OrderBy(c => c.NomeCondominio));
        }

        [Authorize(Roles = "Administradores")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Condominio condominio)
        {
            context.Condominios.Add(condominio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administradores")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Condominio condominio = context.Condominios.Find(id);

            if(condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                context.Entry(condominio).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condominio);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Condominio condominio = context.Condominios.Find(id);

            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        [Authorize(Roles = "Administradores")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Condominio condominio = context.Condominios.Find(id);

            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Condominio condominio = context.Condominios.Find(id);
            context.Condominios.Remove(condominio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}