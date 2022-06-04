using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos2
{
    internal class Auto
    {
		private string _marca;
		private string _modelo;
		private DateTime _año;
		private decimal _precio;

		public string Marca
		{
			get { return this._marca; }
			set { this._marca = value; }
		}

		public string Modelo
		{
			get { return this._modelo; }
			set { this._modelo = value; }
		}

		public DateTime Año
		{
			get { return this._año; }
			set { this._año = value; }
		}
		public decimal Precio
		{
			get { return this._precio; }
			set { this._precio = value; }
		}



		public Auto(string marca, string modelo, DateTime año, decimal precio)
		{

			this._marca = marca;
			this._modelo = modelo;
			this._año = año;
			this._precio = precio;

		}
	}
}
