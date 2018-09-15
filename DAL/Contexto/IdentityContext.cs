using BLL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexto
{
  public class IdentityContext : IdentityDbContext<Usuario>
  {
    public IdentityContext() : base("DB_Identity") { }

    static IdentityContext()
    {
      Database.SetInitializer<IdentityContext>(new IdentityDbInit());
    }

    public static IdentityContext Create()
    {
      return new IdentityContext();
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityContext>
    {
    }
  }

}
