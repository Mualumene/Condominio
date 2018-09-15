using EasyCondominio.Infraestrutura;
using BLL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EasyCondominio.Controllers
{
    public class PapelAdminController : Controller
    {
        // GET: PapelAdmin
        public ActionResult Index()
        {
            return View(InternoRoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PapelViewModel model)
        {
            if (ModelState.IsValid)
            {
                Papel papel = new Papel { Name = model.Nome };
                IdentityResult resultado = InternoRoleManager.Create(papel);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    AddErrorsFromResult(resultado);
                }
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Papel papel = InternoRoleManager.FindById(id);

            if (papel == null)
            {
                return HttpNotFound();
            }

            var pvm = new PapelViewModel();
            pvm.Id = papel.Id;
            pvm.Nome = papel.Name;

            return View(pvm);
        }

        [HttpPost]
        public ActionResult Edit(PapelViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                Papel papel = InternoRoleManager.FindById(pvm.Id);
                papel.Name = pvm.Nome;

                IdentityResult resultado = InternoRoleManager.Update(papel);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    AddErrorsFromResult(resultado);
                }
            }
            return View(pvm);
        }

        public ActionResult Details(string id)
        {
            Papel papel = InternoRoleManager.FindById(id);
            string[] memberIDs = papel.Users.Select(x => x.UserId).ToArray();
            IEnumerable<Usuario> membros = InternoUserManager.Users.Where(x => memberIDs.Any(y => y == x.Id));
            return View(new PapelDetailsModel { Role = papel, Membros = membros });
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Papel papel = InternoRoleManager.FindById(id);

            if (papel == null)
            {
                return HttpNotFound();
            }

            return View(papel);
        }

        [HttpPost]
        public ActionResult Delete(Papel papel)
        {
            Papel p = InternoRoleManager.FindById(papel.Id);

            if (p != null)
            {
                IdentityResult resultado = InternoRoleManager.Delete(p);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            else
            {
                return HttpNotFound();
            }
        }

        private GerenciadorPapel InternoRoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorPapel>();
            }
        }

        private GerenciadorUsuario InternoUserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}