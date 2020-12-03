using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Datos.Repositorios;
using Dominio.Entidades;

namespace WebAPI_Busquedas.Controllers
{
    [RoutePrefix("api/Proyectos")]
    public class ProyectosController : ApiController
    {
        private RepositorioProyecto rP = new RepositorioProyecto();

        /*
        // GET: api/Proyectos
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Proyectos/5
        [Route("{id:int}", Name = "GetById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Proyectos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Proyectos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Proyectos/5
        public void Delete(int id)
        {
        }
        */

        /*
        [HttpGet]
        [Route("busqueda")]
        public IHttpActionResult Buscar([FromUri] Models.BusquedaApiModel datos)
        {
            //Búsqueda por refinaciones sucesivas (AND)
            var resultado = rP.Buscar(  datos.FechaInicio, 
                                        datos.FechaFin, 
                                        datos.ContieneEnTitulo, 
                                        datos.ContieneEnDescripcion, 
                                        datos.Estado, 
                                        datos.MontoMenorOIgualA, 
                                        datos.TipoDeUsuarioBuscador, 
                                        datos.IdUsuario);
            if (resultado != null)
            {
                return Ok(resultado.Select(p => new Models.ArticuloModel
                {
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Id = p.Id,
                    CategoriaAsociada = p.CategoriaAsociada,
                    Votantes =
                        p.Votantes
                        .Select(v => new Models.VotanteModel
                        {
                            Nombre = v.Nombre,
                            Id = v.Id
                        })
                }).ToList());
            }

            else
                return NotFound();
        }

        */
    }
}
