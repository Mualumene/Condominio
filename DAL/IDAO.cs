using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public interface IDAO<T>
  {
    void Add(T objeto);

    void Edit(T objeto);

    void Delete(T objeto);

    T FindById(object id);

    IQueryable<T> FindAll();
  }
}
