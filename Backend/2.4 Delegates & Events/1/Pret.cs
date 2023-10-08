using System;
namespace _1
{
	public class Pret
	{
		public static Dictionary<Moneda, decimal> Curs { get; set; }
		public decimal Valoare { get; set; }
		public Moneda Moneda { get; set; }

		public decimal ValoareCurs(Moneda moneda)
		{
			if(Curs.ContainsKey(moneda))
			{
				return Valoare * Curs[Moneda];
			} else
			{
				throw new ArgumentException($"Cursul valutar pentru moneda {moneda} nu este definit.");
			}
		}

		public event EventHandler<Produs> PriceChanged;

		public void startPriceChanging(decimal newPrice, Produs produs)
		{
			try
			{
				decimal oldValue = produs.Pret.Valoare;
				Console.WriteLine($"Pretul vechi: {oldValue}");
				produs.Pret.Valoare = newPrice;

				onPriceChange(produs);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Eroare: {ex.Message}");
			}
		}

		protected virtual void onPriceChange(Produs produs)
		{
			PriceChanged?.Invoke(this, produs);
		}
	}
}

