using BLL.Models;
using System.Net;
using System.Web.Mvc;
using DAL;

namespace EasyCondominio.Controllers
{

  [Authorize(Roles ="Administradores")]
  public class CondominiosController : Controller
  {

    private GenericDAL<Condominio> genericDAL = new GenericDAL<Condominio>();

    public ActionResult Index()
    {
      return View(genericDAL.FindAll());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Condominio condominio)
    {
      genericDAL.Add(condominio);
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Condominio condominio = genericDAL.FindById(id);

      if (condominio == null)
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
        genericDAL.Edit(condominio);
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

      Condominio condominio = genericDAL.FindById(id);

      if (condominio == null)
      {
        return HttpNotFound();
      }
      return View(condominio);
    }

    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Condominio condominio = genericDAL.FindById(id);

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
      Condominio condominio = genericDAL.FindById(id);
      genericDAL.Delete(condominio);
      return RedirectToAction("Index");
    }
  }
}