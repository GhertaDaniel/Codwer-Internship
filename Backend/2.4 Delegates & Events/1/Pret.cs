using System;
namespace _1
{
	public class Pret
	{
		public static Dictionary<Moneda, decimal> Curs { get; set; } = new Dictionary<Moneda, decimal>();
		public decimal Valoare { get; set; }
		public Moneda Moneda { get; set; }

		public Pret(decimal valoare, Moneda moneda) 
		{
			Valoare = valoare;
			Moneda = moneda;
		}

		public decimal ValoareCurs(Moneda moneda)
		{
			if(Curs.ContainsKey(moneda))
			{
				return Curs[Moneda];
			} else
			{
				throw new ArgumentException($"Cursul valutar pentru {moneda} nu este definit.");
			}
		}
	}
}

