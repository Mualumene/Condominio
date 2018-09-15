using EasyCondominio.Infraestrutura;
using BLL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace EasyCondominio.Controllers
{

    public class AccountController : Controller
    {
        
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Usuario user = InternoUserManager.Find(details.Nome, details.Senha);

                if (user == null)
                {
                    ModelState.AddModelError("", "Nome ou senha inválido(s).");
                }

                else
                {
                    ClaimsIdentity identidade = InternoUserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    InternoAuthManager.SignOut();
                    InternoAuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identidade);

                    if (returnUrl == null)
                    {
                        returnUrl = "/Home";
                    }
                    return Redirect(returnUrl);

                }
            }
            return View(details);
        }

        public ActionResult Logout()
        {
            InternoAuthManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private GerenciadorUsuario InternoUserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }

        private IAuthenticationManager InternoAuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


    }
}