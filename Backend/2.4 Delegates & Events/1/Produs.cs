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
				int oldStock = stoc;
				if(oldStock < 0)
				{
					throw new ArgumentException("Stocul nu poate fi negativ");
				}
				else if(oldStock == 0 && value > 0)
				{
					stoc = value;
					onStockChange(oldStock, stoc, this);
					NotifyClients();
				}
			}
		}

		public Producator Producator { get; set; }
		public List<Client> Clienti { get; set; } = new();

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

		public void RegisterClients(Client c)
		{
			Clienti.Add(c);
		}

		private void NotifyClients()
		{
			foreach(Client client in Clienti)
			{
				if(client.ProduseFavorite.Contains(Id))
				{
					client.Notifica($"Produsul {Nume} este din nou in stoc");
				}
			}
		}

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

