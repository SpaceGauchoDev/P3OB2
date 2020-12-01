using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ProbarValidarCelular("099879995");
            ProbarValidarCelular("0998799aa");
            ProbarValidarCelular("109987aa95");
            ProbarValidarCelular("0aa9000000000005");
            ProbarValidarCelular("00000000000000000");
            */

            /*
            ProbarValidarContrasenia("Aa1234");
            ProbarValidarContrasenia("Aa12345");
            ProbarValidarContrasenia("Aa123456");
            ProbarValidarContrasenia("Aa1234567");

            ProbarValidarContrasenia("A12345");
            ProbarValidarContrasenia("a12345");
            ProbarValidarContrasenia("AAAAAA");
            ProbarValidarContrasenia("123456");
            */

            /*
            DateTime e1 = new DateTime(1990, 2, 15);
            ProbarValidarEdad(e1);
            DateTime e2 = new DateTime(2000, 4, 10);
            ProbarValidarEdad(e2);
            DateTime e3 = new DateTime(2010, 7, 22);
            ProbarValidarEdad(e3);
            DateTime e4 = new DateTime(1999, 3, 17);
            ProbarValidarEdad(e4);
            */

            Console.WriteLine("End");
            Console.ReadLine();
        }


        public static void ProbarValidarCelular(string pCell)
        {
            Inversor u = new Inversor();
            Console.WriteLine(pCell + " " + u.ValidarCelular(pCell));
        }

        public static void ProbarValidarContrasenia(string pPass)
        {
            Inversor u = new Inversor();
            Console.WriteLine(pPass + " " + u.ValidarContrasenia(pPass));
        }


        public static void ProbarValidarEdad(DateTime pEdad)
        {
            Inversor u = new Inversor();
            Console.WriteLine(pEdad.ToString("yyyyMMdd") + " " + u.ValidarEdad(pEdad));
        }


    }
}
