using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Presentacion.Models;
using Dominio.Entidades;


namespace MVC_Presentacion.Controllers
{
    public class InversorRegistrationController : Controller
    {
        // GET: InversorRegistration
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(InversorRegistrationModel pRegistrationData)
        {
            Inversor inversor = new Inversor();
            Inversor.DatosValidacion datosIngresados = new Inversor.DatosValidacion();
            datosIngresados.Nombre = pRegistrationData.Nombre;
            datosIngresados.Apellido = pRegistrationData.Apellido;
            datosIngresados.Ci = pRegistrationData.NombreDeUsuario;
            datosIngresados.Email = pRegistrationData.Email;
            datosIngresados.Cell = pRegistrationData.Cell;
            datosIngresados.Pass = pRegistrationData.Pass;
            datosIngresados.FechaDeNacimiento = pRegistrationData.FechaDeNacimiento;

            Inversor.ResultadoValidacion resultadoValidacion = inversor.ValidarParaPresentacion(datosIngresados);

            if (resultadoValidacion.Resultado)
            {
                // TODOMDA: registrar datos en DB con el repositorio apropiado, volver a HomeSinRegistrar
                // TODOMDA: mensaje de exito ??
                //return RedirectToAction("Index", "VerHomeSinRegistrar");

                ViewData["Mensaje"] = "Validacion exitosa!";
            }
            else
            {
                ViewData["Mensaje"] = resultadoValidacion.Mensaje;
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