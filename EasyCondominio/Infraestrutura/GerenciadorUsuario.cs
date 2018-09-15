using DAL.Contexto;
using BLL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyCondominio.Infraestrutura
{
  public class GerenciadorUsuario : UserManager<Usuario>
  {
    public GerenciadorUsuario(IUserStore<Usuario> store) : base(store)
    {
    }

    public static GerenciadorUsuario Create(IdentityFactoryOptions<GerenciadorUsuario> options, IOwinContext context)
    {
      IdentityContext db = context.Get<IdentityContext>();
      GerenciadorUsuario manager = new GerenciadorUsuario(new UserStore<Usuario>(db));
      return manager;
    }
  }
}