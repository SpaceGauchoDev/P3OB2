using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Presentacion.Controllers
{
    public class HomeSolicitanteController : Controller
    {
        public ActionResult Index()
        {
            return View("VerHomeSolicitante");
        }

        public ActionResult VerHomeSolicitante()
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
            //TODOMDA: agregar vista de busqueda con filtros para solicitantes
            return RedirectToAction("Index", "BusquedaDeProyectos");
        }

        public ActionResult Logout()
        {
            Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.NoRegistrado;
            Session["usuario"] = null;
            return RedirectToAction("Index", "HomeSinRegistrar");
        }
    }
}