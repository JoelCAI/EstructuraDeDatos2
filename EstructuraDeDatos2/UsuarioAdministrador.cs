using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EstructuraDeDatos2
{
	internal class UsuarioAdministrador : Usuario
	{
		protected List<Auto> _auto;

		public List<Auto> Auto
		{
			get { return this._auto; }
			set { this._auto = value; }
		}

		public UsuarioAdministrador(string nombre, List<Auto> auto) : base(nombre)
		{
			this._auto = auto;
		}

		public void MenuAdministrador(List<Auto> auto)
		{

			Auto = auto;

			int opcion;
			do
			{

				Console.Clear();
				Console.WriteLine(" Bienvenido Usuario: *" + Nombre + "* ");
				opcion = Validador.PedirIntMenu("\n Menú de Registro de nuevos Autos: " +
									   "\n [1] Crear Auto" +
									   "\n [2] Grabar Auto" +
									   "\n [3] Leer Auto" +
									   "\n [4] Salir del Sistema.", 1, 4);

				switch (opcion)
				{
					case 1:
						DarAltaAuto();
						break;
					case 2:
						GrabarAuto();
						break;
					case 3:
						LeerAuto();
						break;
					case 4:

						break;

				}
			} while (opcion != 4);
		}

		public int BuscarPersonaDocumento(string marca)
		{
			for (int i = 0; i < this._auto.Count; i++)
			{
				if (this._auto[i].Marca == marca)
				{
					return i;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}

		Dictionary<string, Auto> personaLista = new Dictionary<string, Auto>();

		DateTime añoViejo = new DateTime(1999, 12, 31);
		DateTime añoNuevo = new DateTime(2021, 12, 31);
		

		protected override void DarAltaAuto()
		{

			string marca;
			string modelo;
			DateTime año;
			decimal precio;

			

			string opcion;

			Console.Clear();
			marca = Validador.PedirCaracterString(" Ingrese la marca del Auto" +
											  "\n El documento debe estar entre este rango.", 0, 30);
			if (BuscarPersonaDocumento(marca) == -1)
			{
				VerPersona();
				Console.WriteLine("\n ¡En hora buena! Puede utilizar este Nombre para crear una Persona Nueva en su agenda");
				modelo = Validador.PedirCaracterString("\n Ingrese el modelo del Auto", 0, 30);
				Console.Clear();
				año = Validador.ValidarFechaIngresada("\n Ingrese el año del auto",añoViejo,añoNuevo);

				precio = Validador.PedirIntMayor("\n Ingrese el precio del Auto",1);

				opcion = ValidarSioNoPersonaNoCreada("\n Está seguro que desea crear este auto? ", marca, modelo);


				if (opcion == "SI")
				{
					Auto p = new Auto(marca, modelo, año, precio);
					AddPersona(p);
					personaLista.Add(marca, p);
					VerPersona();
					VerPersonaDiccionario();
					Console.WriteLine("\n Auto con Nombre *" + marca + "* agregado exitósamente");
					Validador.VolverMenu();
				}
				else
				{
					VerPersona();
					Console.WriteLine("\n Como puede verificar no se creo ningún Auto");
					Validador.VolverMenu();

				}

			}
			else
			{
				VerPersona();
				Console.WriteLine("\n Usted digitó la marca *" + marca + "*");
				Console.WriteLine("\n Ya existe un Auto con esa marca");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice correctamente");
				Validador.VolverMenu();

			}

		}

		public void AddPersona(Auto persona)
		{
			this._auto.Add(persona);
		}


		protected override void GrabarAuto()
		{
			using (var archivoLista = new FileStream("archivoLista.txt", FileMode.Create))
			{
				using (var archivoEscrituraAgenda = new StreamWriter(archivoLista))
				{
					foreach (var persona in personaLista.Values)
					{

						var linea =
									"\n Marca del Auto: " + persona.Marca +
									"\n Modelo del Auto: " + persona.Modelo +
									"\n Año del Auto: " + persona.Año +
									"\n Precio del Auto: " + persona.Precio;

						archivoEscrituraAgenda.WriteLine(linea);

					}

				}
			}
			VerPersona();
			Console.WriteLine("Se ha grabado los datos de los Autos correctamente");
			Validador.VolverMenu();

		}

		protected override void LeerAuto()
		{
			Console.Clear();
			Console.WriteLine("\nAutos: ");
			using (var archivoLista = new FileStream("archivoLista.txt", FileMode.Open))
			{
				using (var archivoLecturaAgenda = new StreamReader(archivoLista))
				{
					foreach (var persona in personaLista.Values)
					{


						Console.WriteLine(archivoLecturaAgenda.ReadToEnd());


					}

				}
			}
			Validador.VolverMenu();

		}


		protected string ValidarSioNoPersonaNoCreada(string mensaje, string marca, string modelo)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerPersona();

				Console.WriteLine(
								  "\n Marca del Auto a Crear: " + marca +
								  "\n Modelo del Auto a Crear: " + modelo );

				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					continue;

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}


		protected string ValidarStringNoVacioNombre(string mensaje)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Por favor ingrese el valor solicitado y que no sea vacio.";


			do
			{
				VerPersona();
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeValidador);

				opcion = Console.ReadLine().ToUpper();

				if (opcion == "")
				{

					Console.Clear();
					Console.WriteLine("\n");
					Console.WriteLine(mensajeValidador);

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		public void VerPersona()
		{
			Console.Clear();
			Console.WriteLine("\n Autos");
			Console.WriteLine(" #\t\tMarca.\t\tModelo.\t\tAño.");
			for (int i = 0; i < Auto.Count; i++)
			{
				Console.Write(" " + (i + 1));

				Console.Write("\t\t");
				Console.Write(Auto[i].Marca);
				Console.Write("\t\t");
				Console.Write(Auto[i].Modelo);
				Console.Write("\t\t");
				Console.Write(Auto[i].Año);
				Console.Write("\t\t");

				Console.Write("\n");
			}

		}

		public void VerPersonaDiccionario()
		{
			Console.WriteLine("\n Autos en el Diccionario");
			for (int i = 0; i < personaLista.Count; i++)
			{
				KeyValuePair<string, Auto> persona = personaLista.ElementAt(i);

				Console.WriteLine("\n Marca: " + persona.Key);
				Auto personaValor = persona.Value;


				Console.WriteLine(" Modelo del Auto: " + personaValor.Modelo);
				Console.WriteLine(" Año del Auto: " + personaValor.Año);
				Console.WriteLine(" Precio del Auto " + personaValor.Precio);


			}


		}



	}
}
