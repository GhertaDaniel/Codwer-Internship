using System;
namespace _1
{
	public class Producator
	{
		public string Nume { get; set; }
		public List<Reducere> Reduceri { get; set; }

		public Producator(string nume, List<Reducere> reduceri) 
		{ 
			Nume = nume;
			Reduceri = reduceri;
		}
	}
}

