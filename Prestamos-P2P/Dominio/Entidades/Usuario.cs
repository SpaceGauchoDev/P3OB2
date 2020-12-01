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

        //TODOMDA: Hacer celular un dato requerido, data-migrations, re hacer database 
        public string Cell { get; set; }

        // metodos usuario 
        // ===============

        /*
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
        */

        public struct DatosValidacion
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Ci { get; set; }
            public string Email { get; set; }
            public string Cell { get; set; }
            public string Pass { get; set; }
            public DateTime FechaDeNacimiento { get; set; }
        }

        public struct ResultadoValidacion
        {
            public string Mensaje { get; set; }
            public bool Resultado { get; set; }
        }

        public virtual ResultadoValidacion Validar(DatosValidacion pDatosValidacion)
        {
            ResultadoValidacion result = new ResultadoValidacion();
            bool registroValido = true;
            string mensaje = "";

            if (!ValidarCI(pDatosValidacion.Ci))
            {
                mensaje += "CI invalida";
                registroValido = false;
            }

            if (!ValidarNombreYApellido(pDatosValidacion.Nombre, pDatosValidacion.Apellido))
            {
                if (registroValido)
                {
                    mensaje += "Nombre y/o Apellido invalidos";
                }
                else
                {
                    mensaje += ", nombre y/o Apellido invalidos";
                }
                registroValido = false;
            }

            if (!ValidarEmail(pDatosValidacion.Email))
            {
                if (registroValido)
                {
                    mensaje += "Email invalido";
                }
                else
                {
                    mensaje += ", email invalido";
                }
                registroValido = false;
            }

            if (!ValidarCelular(pDatosValidacion.Cell))
            {
                if (registroValido)
                {
                    mensaje += "Celular invalido";
                }
                else
                {
                    mensaje += ", celular invalido";
                }
                registroValido = false;
            }

            if (!ValidarEdad(pDatosValidacion.FechaDeNacimiento))
            {
                if (registroValido)
                {
                    mensaje += "Edad invalida";
                }
                else
                {
                    mensaje += ", edad invalida";
                }
                registroValido = false;
            }

            result.Mensaje = mensaje;
            result.Resultado = registroValido;

            return result;
        }

        public virtual bool ValidarContrasenia(string pPass)
        {
            bool result = false;
            // mínimo 6 dígitos, incluirá al menos una mayúscula, una minúscula, y un dígito
            
            // source https://regexlib.com/REDetails.aspx?regexp_id=31
            string regexPattern = "^(?=.*[0-1])(?=.*[a-z])(?=.*[A-Z]).{6,}$";

            result = Regex.IsMatch(pPass, regexPattern);
            return result;
        }

        public virtual bool ValidarCelular(string pCell)
        {
            // formato 09X YYYYYY , siendo X un dígito entre 1 y 9, y los Y son dígitos cualesquiera
            bool result = true;

            if (result && pCell.Length != 9)
            {
                result = false;
            }

            if (result &&  pCell.Substring(0, 2) != "09")
            {
                result = false;
            }

            if (result)
            {
                string segundaParte = pCell.Substring(2, 7);
                string regexPattern = "[^0-9]";
                result = !Regex.IsMatch(segundaParte, regexPattern);
            }

            return result;
        }

        public virtual bool ValidarNombreYApellido(string pNom, string pApellido)
        {
            bool result = true;

            // validamos que nombre y apellido no sean vacíos
            if (pNom == "" && pApellido == "")
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

        /*
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
        */

        public virtual bool ValidarEdad(DateTime pFechaDeNacimiento)
        {
            // solicitantes: "Para solicitar un préstamo debe tener al menos 21 años"
            // inversores: "Ingresará su fecha de nacimiento - ellos también deben tener al menos 21 años"

            DateTime today = DateTime.Today;
            int age = today.Year - pFechaDeNacimiento.Year;

            return age >= 21;
        }

        public virtual bool ValidarCI(string pCI)
        {
            // obtenemos el digito verificador
            var digitoVerificador = pCI[pCI.Length - 1];

            // obtenemos el numero
            var primerParte = pCI.Substring(0, pCI.Length - 1);

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
