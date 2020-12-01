using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Presentacion.Controllers
{
    public class HomeInversorController : Controller
    {
        public ActionResult Index()
        {
            return View("VerHomeInversor");
        }

        public ActionResult VerHomeInversor()
        {
            return View();
        }

        public ActionResult ImportarUsuarios()
        {
            return RedirectToAction("Index", "ImportarUsuarios");
        }

        public ActionResult ImportarProyectos()
        {
            return RedirectToAction("Index", "ImportarProyectos");
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

        public ActionResult Logout()
        {
            Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.NoRegistrado;
            Session["usuario"] = null;
            return RedirectToAction("Index", "HomeSinRegistrar");
        }
    }
}