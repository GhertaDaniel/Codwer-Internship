using System;
namespace _1
{
	public class Catalog
	{
		public List<Produs> Produse { get; set; }
		public DateTime? PerioadaStart { get; set; }
		public DateTime? PerioadaStop { get; set; }
		public List<Reducere> Reduceri { get; set; }
        public List<Client> ClientiAbonati { get; set; } = new();

        public Catalog(List<Produs> produse, DateTime? start, DateTime? stop, List<Reducere> reduceri) 
        {
            Produse = produse;
            PerioadaStart = start;
            PerioadaStop = stop;
            Reduceri = reduceri;
        }

        private Dictionary<Client, List<Produs>> abonati = new();

        public void AbonareClient(Client client)
        {
            ClientiAbonati.Add(client);
            abonati[client] = new List<Produs>();

            foreach(var produs in Produse)
            {
                if(client.ProduseFavorite.Contains(produs.Id))
                {
                    produs.PriceChanged += (oldPrice, newPrice, prod) =>
                    {
                        if (abonati.ContainsKey(client) && abonati[client].Contains(prod))
                        {
                            string mesaj = $"Produsul {prod.Nume} Pretul: {oldPrice} {prod.Pret.Moneda} -> {newPrice} {prod.Pret.Moneda}";
                            client.Notifica(mesaj);
                        }
                    };

                    abonati[client].Add(produs);
                }
            }
        }

        public void DezabonareClient(Client client)
        {
            if(ClientiAbonati.Contains(client))
            {
                foreach(var produs in abonati[client])
                {
                    produs.PriceChanged -= (oldPrice, newPrice, prod) =>
                    {
                        if(abonati.ContainsKey(client) && abonati[client].Contains(prod)) 
                        {
                            client.Notifica($"Produsul {prod.Nume} Pretul: {oldPrice} {prod.Pret.Moneda} -> {newPrice} {prod.Pret.Moneda}");
                        }
                    };
                }

                ClientiAbonati.Remove(client);
                abonati.Remove(client);
                client.Inbox.Clear();
            } else
            {
                throw new InvalidOperationException("Clientul nu este abonat");
            }
        }
    }
}

