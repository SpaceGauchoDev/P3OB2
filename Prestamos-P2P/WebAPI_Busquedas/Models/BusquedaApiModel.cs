using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Busquedas.Models
{
    public class BusquedaApiModel
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string ContieneEnTitulo { get; set; }
        public string ContieneEnDescripcion { get; set; }
        public string Estado { get; set; }
        public decimal? MontoMenorOIgualA { get; set; }
        public string TipoDeUsuarioBuscador { get; set; }
        public int? IdUsuario { get; set; }
    }
}