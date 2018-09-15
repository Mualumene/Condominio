using DAL.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class GenericDAL<T> : IDAO<T> where T : class
  {

    private readonly EFContext ctx = new EFContext();

    public void Add(T objeto)
    {
      ctx.Set<T>().Add(objeto);
      ctx.SaveChanges();
    }

    public void Delete(T objeto)
    {
      ctx.Set<T>().Remove(objeto);
      ctx.SaveChanges();
    }

    public void Edit(T objeto)
    {
      ctx.Entry(objeto).State = EntityState.Modified;
      ctx.SaveChanges();
    }

    public IQueryable<T> FindAll()
    {
      return ctx.Set<T>();
    }

    public T FindById(object id)
    {
      return ctx.Set<T>().Find(id);
    }
  }
}
