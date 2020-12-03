using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entidades;

namespace Datos.Repositorios
{
    public class RepositorioInversor : IRepositorioUsuario<Inversor>
    {
        public bool Add(Inversor objeto)
        {
            if (objeto == null || !objeto.ValidarParaRepositorio())
            {
                return false;
            }

            try
            {
                using (Prestamos_P2P_Context db = new Prestamos_P2P_Context())
                {
                    db.Inversores.Add(objeto);
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

        public IEnumerable<Inversor> FindAll()
        {
            throw new NotImplementedException();
        }

        public Inversor FindById(int id)
        {
            try
            {
                using (Prestamos_P2P_Context db = new Prestamos_P2P_Context())
                {
                    return db.Inversores.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool Remove(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Inversor objeto)
        {
            throw new NotImplementedException();
        }
    }
}
