using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos2
{
    internal class Validador
    {
        public static int PedirIntMenu(string mensaje, int min, int max)
        {

            int valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }

        public static int PedirIntMayor(string mensaje, int min)
        {

            int valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor mayor a " + min;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar dentro de lo solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!int.TryParse(Console.ReadLine(), out valor) || valor < min )
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }

        public static string PedirCaracterString(string mensaje, int min, int max)
        {
            string valor;
            bool valido = false;
            string mensajeMenu = "\n El número de caracteres a ingresar es entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar dentro del rango solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                valor = Console.ReadLine();


                if (valor.Length < min || valor.Length > max)
                {
                    Console.Clear();
                    Console.WriteLine(mensajeError);

                }
                else
                {

                    valido = true;

                }

            } while (!valido);


            return valor;

        }

        public static DateTime ValidarFechaIngresada(string mensaje,DateTime añoViejo,DateTime añoNuevo)
        {
            bool ingresoCorrecto;
            DateTime fechaValida;
            

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine("\n Ingrese un formato válido.");
                Console.WriteLine("\n El formato correcto es *dd/mm/aaaa*.");
                Console.WriteLine("\n También puede ser *dd/mm/aaaa hh:mm:ss*.");

                string ingresoNacimiento = Console.ReadLine();

                ingresoCorrecto = DateTime.TryParse(ingresoNacimiento, out fechaValida);

                if (!ingresoCorrecto)
                {
                    continue;
                }
                else if (fechaValida > añoNuevo)
                {
                    fechaValida = ValidarFechaIngresada(mensaje,añoViejo,añoNuevo);
                }
                else if (fechaValida < añoViejo)
                {
                    fechaValida = ValidarFechaIngresada(mensaje,añoViejo,añoNuevo);
                }

            } while (!ingresoCorrecto);

            return fechaValida;
        }

        public static void VolverMenu()
        {
            Console.WriteLine("\n Presione cualquier tecla para volver al Menú ");
            Console.ReadKey();
        }
    }
}
