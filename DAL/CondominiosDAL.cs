using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Contexto;
using System.Data.Entity;

namespace DAL
{
  public class CondominiosDAL : IDAO<Condominio>
  {

    private readonly EFContext ctx = new EFContext();

    public void Add(Condominio objeto)
    {
      ctx.Condominios.Add(objeto);
      ctx.SaveChanges();
    }

    public void Delete(Condominio objeto)
    {
      ctx.Condominios.Remove(objeto);
      ctx.SaveChanges();
    }

    public void Edit(Condominio objeto)
    {
      ctx.Entry(objeto).State = EntityState.Modified;
      ctx.SaveChanges();
    }

    public IQueryable<Condominio> FindAll()
    {
      return ctx.Condominios.OrderBy(c => c.NomeCondominio);
    }

    public Condominio FindById(object id)
    {
      return ctx.Condominios.Find(id);
    }
  }
}
