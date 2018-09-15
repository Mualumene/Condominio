using DAL.Contexto;
using BLL.Models;
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
    private IdentityContext IdentityCtx = new IdentityContext();

    // GET: Proprietarios
    public ActionResult Index()
    {
      ViewBag.UsuarioId = new SelectList(IdentityCtx.Users.OrderBy(u => u.UserName), "Id", "UserName");
      return View(context.Proprietarios.OrderBy(p => p.Nome));
    }

    public ActionResult Create()
    {
      ViewBag.UsuarioId = new SelectList(IdentityCtx.Users.OrderBy(u => u.UserName), "Id", "UserName");
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Proprietario proprietario)
    {
      context.Proprietarios.Add(proprietario);
      context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}