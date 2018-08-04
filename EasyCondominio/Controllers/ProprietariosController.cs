using EasyCondominio.Contexto;
using EasyCondominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCondominio.Controllers
{
    public class ProprietariosController : Controller
    {

        private EFContext context = new EFContext();

        // GET: Proprietarios
        public ActionResult Index()
        {
            ViewBag.UsuarioId = new SelectList(context.Users.OrderBy(u => u.UserName), "Id", "UserName");
            return View(context.Proprietarios.OrderBy(p => p.Nome));
        }

        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(context.Users.OrderBy(u => u.UserName), "Id", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proprietario  proprietario)
        {
            context.Proprietarios.Add(proprietario);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}