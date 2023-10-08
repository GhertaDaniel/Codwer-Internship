using System;
namespace _1
{
	public class Catalog
	{
		public List<Produs> Produse { get; set; }
		public DateTime? PerioadaStart { get; set; }
		public DateTime? PerioadaStop { get; set; }
		public List<Reducere> Reduceri { get; set; }

        public event Action<string, decimal> PriceChanged;

		public void UpdateProductPrice(string numeProdus, decimal newPrice)
		{
            Produs productToChange = FindProductByName(numeProdus);

            if (productToChange != null)
			{
				decimal oldPrice = productToChange.Pret.Valoare;
                productToChange.Pret.Valoare = newPrice;

                if(oldPrice != newPrice)
                {
				    onPriceChanged(productToChange.Nume, newPrice);
                }
			}
			else
			{
				Console.WriteLine($"Produsul cu numele {productToChange.Nume} nu a fost gasit");
			}

		}

        public Produs FindProductByName(string name)
        {
            return Produse.Find(prod => prod.Nume.ToLower() == name.ToLower());
        }

        public List<Produs> ProduseFavorite(Client client)
        {
            var favoriteItems = new List<Produs>();

            for (int i = 0; i < client.ProduseFavorite.Count; i++)
            {
                if (client.ProduseFavorite[i])
                {
                    favoriteItems.Add(Produse[i]);
                }
            }

            return favoriteItems;
        }

        public void AbonareSchimbarePret(string nume, Action<string, decimal> eventHandler)
        {
            Action<string, decimal> handler = (string numeProdus, decimal newPrice) =>
            {
                if (numeProdus == nume)
                {
                    eventHandler(numeProdus, newPrice);
                }
            };

            PriceChanged += handler;
        }

        
        public void DezabonareSchimbarePret(string nume, Action<string, decimal> eventHandler)
        {
            Action<string, decimal> handler = (string numeProdus, decimal newPrice) =>
            {
                if (numeProdus == nume)
                {
                    eventHandler(numeProdus, newPrice);
                }
            };

           PriceChanged -= handler;
        }

        private void onPriceChanged(string numeProdus, decimal newPrice)
        {
            if (PriceChanged != null)
            {
                PriceChanged(numeProdus, newPrice);
            }
        }

        //public void UpdateProductPrice(string numeProdus, decimal newPrice, Moneda moneda)
        //{
        //	Produs? productToChange = Produse.Find(prod => prod.Nume.ToLower() == numeProdus.ToLower());

        //	if(productToChange != null)
        //	{
        //		decimal oldPrice = productToChange.Pret.Valoare;
        //		productToChange.Pret.Valoare = newPrice;
        //		onPriceChanged(numeProdus, oldPrice, newPrice, moneda);
        //	}
        //	else
        //	{
        //              Console.WriteLine($"Produsul cu numele {numeProdus} nu a fost gasit");
        //          }

        //}

        //public Action SubscribeToCatalog(string numeProdus)
        //{
        //	Action<string, decimal, decimal, Moneda> subscription = (productName, oldPrice, newPrice, moneda) =>
        //	{
        //		if (productName.ToLower() == numeProdus.ToLower())
        //		{
        //			Console.WriteLine($"Pretul produsului {numeProdus} s-a schimbat de la {oldPrice} la {newPrice} ({moneda})");
        //		}
        //	};

        //	PriceChanged += subscription;

        //	Action unsubscribe = () =>
        //	{
        //		if(PriceChanged != null)
        //		{
        //			Console.WriteLine("Dezabonat");
        //			PriceChanged -= subscription;
        //		} else
        //		{
        //			throw new InvalidOperationException("Vati dezabonat deja");
        //		}
        //	};

        //	return unsubscribe;

        //}

        //      public void UnsubscribeFromCatalog(Action? unsubscribe)
        //{
        //	if(unsubscribe != null) 
        //	{
        //		unsubscribe?.Invoke();
        //	} 
        //}

        //private void onPriceChanged(string numeProdus, decimal oldPrice, decimal newPrice, Moneda moneda)
        //{
        //	if (PriceChanged != null)
        //	{
        //		PriceChanged(numeProdus, oldPrice, newPrice, moneda);
        //	}
        //}

    }
}

