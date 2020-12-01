using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Presentacion.Models;

namespace MVC_Presentacion.Controllers
{
    public class ImportarUsuariosController : Controller
    {
        // GET: ImportarProyectos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FileUploadModel pUploadedFile)
        {
            return RedirectToAction("Index", "ImportarUsuarios");
        }


        public ActionResult VolverAHome()
        {
            if (Session["tipoDeUsuario"] == null) {
                return RedirectToAction("Index", "HomeSinRegistrar");
            }

            if (Session["tipoDeUsuario"].ToString() == TiposDeUsuario.E_Nav.Inversor.ToString())
            {
                return RedirectToAction("Index", "HomeInversor");
            }
            else if (Session["tipoDeUsuario"].ToString() == TiposDeUsuario.E_Nav.Solicitante.ToString())
            {
                return RedirectToAction("Index", "HomeSolicitante");
            }
            else
            {
                return RedirectToAction("Index", "HomeSinRegistrar");
            }
        }
    }
}