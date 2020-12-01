using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Presentacion.Models;

namespace MVC_Presentacion.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDataModel pLoginData)
        {
            // TODOMDA: reemplazar con buscar data en los repositorios apropiadoss
            LoginDataModel sol = new LoginDataModel();
            sol.NombreDeUsuario = "s";
            sol.Pass = "s";

            LoginDataModel inv = new LoginDataModel();
            inv.NombreDeUsuario = "i";
            inv.Pass = "i";

            if (pLoginData.NombreDeUsuario == sol.NombreDeUsuario && pLoginData.Pass == sol.Pass)
            {
                // ingresar como solicitante
                Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.Solicitante;
                return RedirectToAction("Index", "HomeSolicitante");
            }
            else if (pLoginData.NombreDeUsuario == inv.NombreDeUsuario && pLoginData.Pass == inv.Pass)
            {
                // ingresar como inversor
                Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.Inversor;
                return RedirectToAction("Index", "HomeInversor");
            }
            else
            {
                Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.NoRegistrado;
                ViewData["Mensaje"] = "Nombre de usuario y/o contraseña incorrectos.";
            }

            return View();
        }


        public ActionResult VolverAHome()
        {
            if (Session["tipoDeUsuario"] == null)
            {
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