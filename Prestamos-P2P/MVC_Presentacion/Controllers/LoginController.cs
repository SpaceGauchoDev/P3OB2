using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Presentacion.Models;
using Datos.Repositorios;
using Dominio.Entidades;

namespace MVC_Presentacion.Controllers
{
    public class LoginController : CommonController
    {
        // GET: Login
        public ActionResult Index()
        {
            // "Si se accede al login a través de un usuario previamente identificado se cerrará su sesión anterior"
            // normalmente el boton no está visible si un usuario està identificado, pero si un usuario identificado accede al login desde url, lo deslogeamos

            if (Session["tipoDeUsuario"] != null)
            {
                if (Session["tipoDeUsuario"].ToString() == TiposDeUsuario.E_Nav.Inversor.ToString())
                {
                    return RedirectToAction("Logout", "Common");
                }
                else if (Session["tipoDeUsuario"].ToString() == TiposDeUsuario.E_Nav.Solicitante.ToString())
                {
                    return RedirectToAction("Logout", "Common");
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDataModel pLoginData)
        {
            RepositorioSolicitante rS = new RepositorioSolicitante();
            RepositorioInversor rI = new RepositorioInversor();

            // TODOMDA: si un usuario solicitante accede al sitio y aun tiene la contraseña temporal, esta debe ser cambiada

            // TODOMDA: la navegacion de todo el sitio no debe permitr acceder a recurso que no sea valido para el tipo de usuario

            // "Se controlará que no puedan acceder a través de una URL a las funcionalidades no autorizadas. Si se accede al login
            // a través de un usuario previamente identificado se cerrará su sesión anterior"

            Inversor i = rI.LoginAttempt(pLoginData.NombreDeUsuario, pLoginData.Pass);
            Solicitante s = rS.LoginAttempt(pLoginData.NombreDeUsuario, pLoginData.Pass);
            if (s != null )
            {
                // ingresar como solicitante
                Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.Solicitante;
                Session["idUsuario"] = pLoginData.NombreDeUsuario;

                if (s.TienePassTemporal)
                {
                    return RedirectToAction("Index", "CambiarPass");
                }
                else
                {
                    return RedirectToAction("Index", "HomeSolicitante");
                }
            }
            else if (i != null)
            {
                // ingresar como inversor
                Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.Inversor;
                Session["idUsuario"] = pLoginData.NombreDeUsuario;
                return RedirectToAction("Index", "HomeInversor");
            }
            else
            {
                Session["tipoDeUsuario"] = TiposDeUsuario.E_Nav.NoRegistrado;
                ViewData["Mensaje"] = "Nombre de usuario y/o contraseña incorrectos.";
            }

            return View();
        }

    }
}