using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Presentacion.ServicioSolicitantesRef;

namespace MVC_Presentacion.Controllers
{
    public class HomeInversorController : CommonController
    {
        public ActionResult Index()
        {
            return View("VerHomeInversor");
        }

        public ActionResult VerHomeInversor()
        {
            return View();
        }

        public ActionResult BuscarProyectos()
        {
            //TODOMDA: agregar vista de busqueda con filtros para inversores
            return RedirectToAction("Index", "BusquedaDeProyectos");
        }

        public ActionResult VerFinanciaciones()
        {
            //TODOMDA: agregar vista de financiaciones de este inversor
            return RedirectToAction("Index", "VerFinanciaciones");
        }
    }
}