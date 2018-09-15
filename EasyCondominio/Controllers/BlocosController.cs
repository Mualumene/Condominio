using BLL.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL;

namespace EasyCondominio.Controllers
{
  public class BlocosController : Controller
  {

    private GenericDAL<Bloco> genericDAL = new GenericDAL<Bloco>();
    private GenericDAL<Condominio> genericDALcondominio = new GenericDAL<Condominio>();

    // GET: Blocos
    public ActionResult Index()
    {
      ViewBag.CondominioId = new SelectList(genericDALcondominio.FindAll().OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio");
      return View(genericDAL.FindAll().OrderBy(b => b.NumBloco));
    }

    public ActionResult Create()
    {
      ViewBag.CondominioId = new SelectList(genericDALcondominio.FindAll().OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio");
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Bloco bloco)
    {
      genericDAL.Add(bloco);
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Bloco bloco = genericDAL.FindById(id);

      if (bloco == null)
      {
        return HttpNotFound();
      }

      ViewBag.CondominioId = new SelectList(genericDALcondominio.FindAll().OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio", bloco.CondominioId);
      return View(bloco);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Bloco bloco)
    {
      if (ModelState.IsValid)
      {
        genericDAL.Edit(bloco);
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

      Bloco bloco = genericDAL.FindById(id);

      if (bloco == null)
      {
        return HttpNotFound();
      }

      ViewBag.CondominioId = new SelectList(genericDALcondominio.FindAll().OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio", bloco.CondominioId);
      return View(bloco);
    }

    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Bloco bloco = genericDAL.FindById(id);

      if (bloco == null)
      {
        return HttpNotFound();
      }

      ViewBag.CondominioId = new SelectList(genericDALcondominio.FindAll().OrderBy(c => c.NomeCondominio), "CondominioId", "NomeCondominio", bloco.CondominioId);
      return View(bloco);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id)
    {
      Bloco bloco = genericDAL.FindById(id);
      genericDAL.Delete(bloco);
      return RedirectToAction("Index");
    }

  }
}