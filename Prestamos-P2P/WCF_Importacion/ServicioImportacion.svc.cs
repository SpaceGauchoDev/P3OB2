using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Datos;
using Datos.Repositorios;
using Dominio.Entidades;
using System.IO;


namespace WCF_Importacion
{
    public class ServicioImportacion : IServicioImportacion
    {
        private RepositorioSolicitante rS = new RepositorioSolicitante();
        private RepositorioInversor rI = new RepositorioInversor();

        //TODOMDA: esto esta feo, lo mejor sería capturar el path desde el boton del MVC con un file upload, 
        // o mejor recibir el string entero desde el MVC como parametro de ImportarSolicitantes() y no tener que leer el txt aca
        private string hardCodedFullPath = "D:\\MyStuff\\ORT\\AP\\S50\\P3\\P3OB2\\Prestamos-P2P\\Datos\\Archivos\\usuarios.txt";

        public int ImportarProyectos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DtoSolicitante> ImportarSolicitantes()
        {
            try
            {
                using (StreamReader sr = new StreamReader(hardCodedFullPath))
                {
                    string linea = sr.ReadLine();
                    while (linea != null)
                    {
                        var lineaVec = linea.Split("|".ToCharArray());
                        // solo importamos usuarios solicitantes que no existan en la base de datos como inversores
                        if (lineaVec[2].ToString() == "S" && rI.FindById(int.Parse(lineaVec[0])) == null)
                        {
                            Solicitante sol = new Solicitante
                            {
                                // ejemplo de linea en el txt
                                // 31832575|Aa1234|S|Gordon|Gordoñez|1991-02-17 12:00:00 AM|gordon@gmail.com|099879997
                                IdUsuario = int.Parse(lineaVec[0]),
                                Pass = PassTemporal(lineaVec[3].ToString(), lineaVec[4].ToString(), lineaVec[0].ToString()),
                                Nombre = lineaVec[3].ToString(),
                                Apellido = lineaVec[4].ToString(),
                                FechaDeNacimiento = ConvertirAFecha(lineaVec[5].ToString()),
                                Email = lineaVec[6].ToString(),
                                Cell = lineaVec[7].ToString(),
                                TienePassTemporal = true
                            };

                            rS.Add(sol);
                        }
                        linea = sr.ReadLine();
                    }
                }
                return ObtenerTodosLosSolicitantes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ObtenerTodosLosSolicitantes();
            }
        }


        private DateTime ConvertirAFecha(string fechaString)
        {
            int anio = int.Parse(fechaString.Substring(0, 4));
            int mes = int.Parse(fechaString.Substring(5, 2));
            int dia = int.Parse(fechaString.Substring(8, 2));
            DateTime fechaDate = new DateTime(anio, mes, dia);

            return fechaDate;
        }

        private string PassTemporal(string nombre, string apellido, string CI)
        {
            /*
             Como la contraseña anterior no se lee, le será asignada automáticamente unanueva formada
             por la inicial de su nombre en minúscula, la inicial de su apellido en mayúscula y los dígitos de su cédula). 
             Por ejemplo, si su nombre es Antonia Gurméndezy tiene cédula 12345678 le asignaremos el string aG12345678 como nueva contraseña.
             */
            string pass = nombre.Substring(0, 1).ToLower();
            pass += apellido.Substring(0, 1).ToUpper();
            pass += CI;

            return pass;
        }

        private IEnumerable<DtoSolicitante> ObtenerTodosLosSolicitantes()
        {
            List<Solicitante> solicitantes = rS.FindAll().ToList();
            List<DtoSolicitante> listaDeDTOSolicitantes = new List<DtoSolicitante>();

            foreach (Solicitante s in solicitantes) {
                DtoSolicitante dtoSolicitante = new DtoSolicitante
                {
                    Nombre = s.Nombre,
                    Apellido = s.Apellido,
                    FechaDeNacimiento = s.FechaDeNacimiento,
                    Email = s.Email,
                    Cell = s.Cell
                };
                listaDeDTOSolicitantes.Add(dtoSolicitante); 
            }

            return listaDeDTOSolicitantes;
        }
    }
}
