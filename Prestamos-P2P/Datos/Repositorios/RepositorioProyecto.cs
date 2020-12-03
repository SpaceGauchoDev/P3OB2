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
    }
}
