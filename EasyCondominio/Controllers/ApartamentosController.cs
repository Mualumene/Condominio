using DAL.Contexto;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace EasyCondominio.Controllers
{
  public class ApartamentosController : Controller
  {

    private GenericDAL<Apartamento> genericDAL = new GenericDAL<Apartamento>();
    private GenericDAL<Bloco> genericDALbloco = new GenericDAL<Bloco>();
    private GenericDAL<Proprietario> genericDALproprietario = new GenericDAL<Proprietario>();

    private EFContext context = new EFContext();

    // GET: Apartamentos
    public ActionResult Index()
    {
      ViewBag.BlocoId = new SelectList(genericDALbloco.FindAll().OrderBy(b => b.NumBloco), "BlocoId", "NumBloco");
      ViewBag.ProprietarioId = new SelectList(genericDALproprietario.FindAll().OrderBy(p => p.Nome), "ProprietarioId", "Nome");
      return View(genericDAL.FindAll().OrderBy(a => a.NumApto));
    }

    public ActionResult Create()
    {
      ViewBag.BlocoId = new SelectList(genericDALbloco.FindAll().OrderBy(b => b.NumBloco), "BlocoId", "NumBloco");
      ViewBag.ProprietarioId = new SelectList(genericDALproprietario.FindAll().OrderBy(p => p.Nome), "ProprietarioId", "Nome");
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Apartamento apartamento)
    {
      genericDAL.Add(apartamento);
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Apartamento apartamento = genericDAL.FindById(id);

      if (apartamento == null)
      {
        return HttpNotFound();
      }

      ViewBag.BlocoId = new SelectList(genericDALbloco.FindAll().OrderBy(b => b.NumBloco), "BlocoId", "NumBloco", apartamento.BlocoId);
      ViewBag.ProprietarioId = new SelectList(genericDALproprietario.FindAll().OrderBy(p => p.Nome), "ProprietarioId", "Nome", apartamento.ProprietarioId);
      return View(apartamento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Apartamento apartamento)
    {
      if (ModelState.IsValid)
      {
        genericDAL.Edit(apartamento);
        return RedirectToAction("Index");
      }
      return View(apartamento);
    }

    //Get
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Apartamento apartamento = genericDAL.FindById(id);


      if (apartamento == null)
      {
        return HttpNotFound();
      }

      ViewBag.BlocoId = new SelectList(genericDALbloco.FindAll().OrderBy(b => b.NumBloco), "BlocoId", "NumBloco", apartamento.BlocoId);
      ViewBag.ProprietarioId = new SelectList(genericDALproprietario.FindAll().OrderBy(p => p.Nome), "ProprietarioId", "Nome", apartamento.ProprietarioId);
      return View(apartamento);
    }

    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      Apartamento apartamento = genericDAL.FindById(id);


      if (apartamento == null)
      {
        return HttpNotFound();
      }

      ViewBag.BlocoId = new SelectList(genericDALbloco.FindAll().OrderBy(b => b.NumBloco), "BlocoId", "NumBloco", apartamento.BlocoId);
      ViewBag.ProprietarioId = new SelectList(genericDALproprietario.FindAll().OrderBy(p => p.Nome), "ProprietarioId", "Nome", apartamento.ProprietarioId);
      return View(apartamento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id)
    {
      Apartamento apartamento = genericDAL.FindById(id);
      genericDAL.Delete(apartamento);
      return RedirectToAction("Index");
    }
  }
}