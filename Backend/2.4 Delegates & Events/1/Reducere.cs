using System;
namespace _1
{
	public class Reducere
	{
		public string Nume { get; set; }
		public DateTime Data { get; set; }
		public Reducere(string nume, DateTime data)
		{
			Nume = nume;
			Data = data;
		}

		public Action<Produs> Aplica = (produs) => 
		{ 
			produs.Pret.Valoare -= produs.Pret.Valoare * 0.31m;
		};
	}
}

