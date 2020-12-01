using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public abstract class Usuario
    {
        // properties usuario
        // ===================

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; } // CI

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Pass { get; set; }

        /*
        [StringLength(1)]
        [Required]
        public string Rol { get; set; } // check S || I
        */

        [Required]
        public DateTime FechaDeNacimiento { get; set; }

        [Required]
        public string Email { get; set; }

        public string Cell { get; set; }

        // metodos usuario 
        // ===============

        public virtual bool Validar()
        {
            bool result = false;

            result = ValidarNombreYApellido(Nombre, Apellido);
            result = ValidarCI(IdUsuario);
            result = ValidarEmail(Email);

            return result;
        }

        public virtual bool Validar(string pNombre, string pApellido, int pCi, string pEmail)
        {
            bool result = false;

            result = ValidarNombreYApellido(pNombre, pApellido);
            result = ValidarCI(pCi);
            result = ValidarEmail(pEmail);

            return result;
        }

        public virtual bool ValidarNombreYApellido(string pNom, string pApellido)
        {
            bool result = true;

            //TODO: verificar validacion de email

            // validamos que nombre y apellido no sean vacíos
            if (pNom == "" && pApellido == "")
            {
                result = false;
            }

            // validamos que nombre y apellido no se pasen del limite de caracteres en DB
            if (pNom.Length > 30 && pApellido.Length > 50)
            {
                result = false;
            }

            return result;
        }

        public virtual bool ValidarEmail(string pEmail)
        {
            bool result = false;

            // source https://www.rhyous.com/2010/06/15/csharp-email-regular-expression/
            string regexPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

            result = Regex.IsMatch(pEmail, regexPattern);
            return result;
        }

        public virtual bool ValidarCI(int pCI)
        {
            string CIString = pCI.ToString();

            // obtenemos el digito verificador
            var digitoVerificador = CIString[CIString.Length - 1];

            // obtenemos el numero
            var primerParte = CIString.Substring(0, CIString.Length - 1);

            // calculamos el digito verificador a partir del numero
            int digitoCalculado = CalcularDigitoVerificador(primerParte);

            // comparamos el digito verificador provisto con el digito verificador calculado
            return (Int32.Parse(digitoVerificador.ToString()) == digitoCalculado);
        }


        private int CalcularDigitoVerificador(string pCI)
        {
            // ????

            var a = 0;
            var i = 0;
            if (pCI.Length <= 6)
            {
                for (i = pCI.Length; i < 7; i++)
                {
                    pCI = '0' + pCI;
                }
            }
            for (i = 0; i < 7; i++)
            {
                a += (Int32.Parse("2987634"[i].ToString()) * Int32.Parse(pCI[i].ToString())) % 10;
            }
            if (a % 10 == 0)
            {
                return 0;
            }
            else
            {
                return 10 - a % 10;
            }

        }
    }
}
