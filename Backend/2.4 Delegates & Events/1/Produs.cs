using System;
namespace _1
{
	public class Produs
	{
		public Guid Id { get; set; }
		public string Nume { get; set; }
		private Pret pret { get; set; }
		public Pret Pret
		{
			get { return pret; }
			set
			{
				decimal oldPrice = pret.Valoare;
				pret = value;
                onPriceChange(oldPrice, pret.Valoare, this);
			}
		}

		private int stoc;

		public int Stoc
		{
			get { return stoc; }
			set
			{
				if(value > 0)
				{
					int oldStock = stoc;
					stoc = value;
					onStockChange(oldStock, stoc, this);
				}
				else
				{
					throw new ArgumentException("Stocul trebuie sa fie un numar pozitiv");
				}
			}
		}

		public Producator Producator { get; set; }

		public Produs(Guid id, string nume, Pret pret, int stoc, Producator producator)
		{
			Id = id;
			Nume = nume;
			this.pret = pret;
			this.stoc = stoc;
			Producator = producator;
		}

		public event ModificatorPretStoc<int, Produs> StockChanged;

		public event ModificatorPretStoc<decimal, Produs> PriceChanged;

		protected virtual void onStockChange(int oldStock, int newStock, Produs prod) 
		{ 
			StockChanged?.Invoke(oldStock, newStock, prod);
		}

		protected virtual void onPriceChange(decimal oldPrice, decimal  newPrice, Produs prod)
		{
			PriceChanged?.Invoke(oldPrice, newPrice, prod);
		}
	}
}

