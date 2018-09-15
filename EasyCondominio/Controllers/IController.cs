using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EasyCondominio.Controllers
{
    public interface IController<T> where T : class
    {
        ActionResult Create(T objeto);
    }
}
