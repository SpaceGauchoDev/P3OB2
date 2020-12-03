using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Presentacion.ServicioSolicitantesRef;

namespace MVC_Presentacion.Controllers
{
    public class HomeSolicitanteController : CommonController
    {
        public ActionResult Index()
        {
            return View("VerHomeSolicitante");
        }

        public ActionResult VerHomeSolicitante()
        {
            return View();
        }

        public ActionResult BuscarProyectos()
        {
            //TODOMDA: agregar vista de busqueda con filtros para solicitantes
            return RedirectToAction("Index", "BusquedaDeProyectos");
        }
    }
}