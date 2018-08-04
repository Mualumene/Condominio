using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCondominio.Infraestrutura
{
    public static class IdentityHelpers
    {
        //Este método, de acordo com o livro, é usado na view Index do PapelAdminController para exibir
        //todos os usuários do papel. Mas nesta aplicação ainda não e talvez não será usado.
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            GerenciadorUsuario mgr = HttpContext.Current.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }

        //Este método retorna o nome do usuário que está autenticado. Ele é usado na view _Layout.cshtm.
        //Página 193 do livro.
        public static MvcHtmlString GetAuthenticatedUser(this HtmlHelper html)
        {
            return new MvcHtmlString(HttpContext.Current.User.Identity.Name);
        }
    }
}