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
    public class AdminController : Controller
    {
        // GET: Admin 
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }

        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(GerenciadorPapel.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuarioViewModel model, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario { UserName = model.Nome, Email = model.Email };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);

                if (result.Succeeded)
                {
                    //Adiciona o usuário à(s) regra(s) selecionada(s)
                    if (selectedRoles != null)
                    {
                        var resultado = GerenciadorUsuario.AddToRoles(user.Id, selectedRoles);
               
                        if (!resultado.Succeeded)
                        {
                            AddErrorsFromResult(resultado);
                            return View();
                        }
                    }
                    return RedirectToAction("Index");
                }

                else
                {
                    AddErrorsFromResult(result);
                    return View();
                }
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario usuario = GerenciadorUsuario.FindById(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            var uvm = new UsuarioViewModel();
            uvm.Id = usuario.Id;
            uvm.Nome = usuario.UserName;
            uvm.Email = usuario.Email;

            return View(uvm);
        }

        [HttpPost]
        public ActionResult Edit(UsuarioViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = GerenciadorUsuario.FindById(uvm.Id);
                usuario.UserName = uvm.Nome;
                usuario.Email = uvm.Email;
                usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.HashPassword(uvm.Senha);
                IdentityResult result = GerenciadorUsuario.Update(usuario);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(uvm);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario usuario = GerenciadorUsuario.FindById(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario usuario = GerenciadorUsuario.FindById(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            Usuario user = GerenciadorUsuario.FindById(usuario.Id);

            if (user != null)
            {
                IdentityResult result = GerenciadorUsuario.Delete(user);

                if (result.Succeeded)
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

        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }

        private GerenciadorPapel GerenciadorPapel
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorPapel>();
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