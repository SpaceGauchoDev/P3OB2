using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Presentacion.Controllers
{
    public class HomeSinRegistrarController : Controller
    {
        // GET: HomeSinRegistrar
        public ActionResult Index()
        {
            // para cuando entra por primera vez a la pagina
            if (Session["tipoDeUsuario"] == null)
            {
                Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.NoRegistrado;
            }
            return View("VerHomeSinRegistrar");
        }

        public ActionResult VerHomeSinRegistrar()
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

        public ActionResult IrARegistrarInversor()
        {
            return RedirectToAction("Index", "InversorRegistration");
        }

        public ActionResult IrALogin()
        {
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Logout()
        {
            Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.NoRegistrado;
            Session["usuario"] = null;
            return View("VerHomeSinRegistrar");
        }
    }
}