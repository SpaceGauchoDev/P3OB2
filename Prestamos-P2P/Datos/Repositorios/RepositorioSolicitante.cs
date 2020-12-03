using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entidades;

namespace Datos.Repositorios
{
    public class RepositorioSolicitante : IRepositorioUsuario<Solicitante>
    {
        public bool Add(Solicitante objeto)
        {
            if (objeto == null || !objeto.ValidarParaRepositorio()){
                return false;
            }

            try
            {
                using (Prestamos_P2P_Context db = new Prestamos_P2P_Context())
                {
                    db.Solicitantes.Add(objeto);
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

        public IEnumerable<Solicitante> FindAll()
        {
            using (Prestamos_P2P_Context db = new Prestamos_P2P_Context())
            {
                var sol = db.Solicitantes.ToList();
                return sol;
            }
        }

        public Solicitante FindById(int id)
        {
            try
            {
                using (Prestamos_P2P_Context db = new Prestamos_P2P_Context())
                {
                    return db.Solicitantes.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public bool ExistsByEmail(string email)
        {
            try
            {
                using (Prestamos_P2P_Context db = new Prestamos_P2P_Context())
                {
                    var existe = db.Solicitantes.Count(p => p.Email == email);

                    if (existe == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Remove(object id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Solicitante objeto)
        {
            throw new NotImplementedException();
        }
    }
}
