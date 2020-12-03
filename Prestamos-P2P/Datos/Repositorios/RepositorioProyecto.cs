using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entidades;

namespace Datos.Repositorios
{
    public class RepositorioProyecto : IRepositorioProyecto<Proyecto>
    {
        public bool Add(Proyecto objeto)
        {
            if (objeto == null || !objeto.ValidarParaRepositorio())
            {
                return false;
            }

            try
            {
                using (Prestamos_P2P_Context db = new Prestamos_P2P_Context())
                {
                    db.Proyectos.Add(objeto);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public IEnumerable<Proyecto> FindAll()
        {
            using (Prestamos_P2P_Context db = new Prestamos_P2P_Context())
            {
                var pro = db.Proyectos.ToList();
                return pro;
            }
        }

        public Proyecto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object objeto)
        {
            throw new NotImplementedException();
        }

        public bool Update(Proyecto objeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proyecto> Buscar(    DateTime? pFechaInicio,
                                                DateTime? pFechaFin,
                                                string pContieneEnTitulo,
                                                string pContieneEnDescripcion,
                                                string pEstado,
                                                decimal? pMontoMenorOIgualA,
                                                string pTipoDeUsuarioBuscador,
                                                int? pIdUsuario)
        {
            Prestamos_P2P_Context db = new Prestamos_P2P_Context();
            var proyectos = from p in db.Proyectos select p;
            if (pFechaInicio != null && pFechaFin != null)
            {
                proyectos = proyectos.Where(proy => proy.FechaDePresentacion >= pFechaInicio && proy.FechaDePresentacion <= pFechaFin);
            }
            if (!String.IsNullOrEmpty(pContieneEnTitulo))
            {
                proyectos = proyectos.Where(proy => proy.Titulo.Contains(pContieneEnTitulo));
            }
            if (!String.IsNullOrEmpty(pContieneEnDescripcion))
            {
                proyectos = proyectos.Where(proy => proy.Descripcion.Contains(pContieneEnDescripcion));
            }
            if (pMontoMenorOIgualA != null)
            {
                proyectos = proyectos.Where(proy => proy.MontoSolicitado <= pMontoMenorOIgualA);
            }
            if (!String.IsNullOrEmpty(pTipoDeUsuarioBuscador) && pIdUsuario != null)
            {
                if (pTipoDeUsuarioBuscador == "solicitante")
                {
                    proyectos = proyectos.Where(proy => proy.IdSolicitante == pIdUsuario);
                }
            }

            return proyectos.ToList();
        }

    }
}
