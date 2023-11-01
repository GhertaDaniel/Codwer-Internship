using _1;

public enum Moneda
{
    LEU,
    EUR,
    USD
}

public delegate void ModificatorPretStoc<T, TResponse>(T old, T neww, TResponse obj);

public static class DateTimeExtensions
{
    public static bool IsInRange(this DateTime date, DateTime startDate, DateTime endDate)
    {
        return date >= startDate && date <= endDate;
    }
}

class Program
{
    static void Main()
    {
        List<Reducere> reduceri1 = new()
        {
            new Reducere("Reducere1", DateTime.Parse("2023-10-01")),
            new Reducere("Reducere2", DateTime.Parse("2023-10-15")),
            new Reducere("Reducere3", DateTime.Parse("2023-11-05")),
        };

        List<Reducere> reduceri2 = new()
        {
            new Reducere("Discount1", DateTime.Parse("2023-09-20")),
            new Reducere("Discount2", DateTime.Parse("2023-10-10")),
            new Reducere("Discount3", DateTime.Parse("2023-10-30")),
        };

        List<Reducere> reduceri3 = new()
        {
            new Reducere("Oferta1", DateTime.Parse("2023-11-01")),
            new Reducere("Oferta2", DateTime.Parse("2023-11-15")),
            new Reducere("Oferta3", DateTime.Parse("2023-12-05")),
        };

        List<Reducere> reduceri = reduceri1.Concat(reduceri2).Concat(reduceri3).ToList();

        Pret.Curs = new Dictionary<Moneda, decimal>
        {
            { Moneda.EUR, 19.13m },
            { Moneda.LEU, 1.0m },
            { Moneda.USD, 18.16m },
        };

        List<Producator> producatori = new()
        {
            new Producator("Samsung", reduceri1),
            new Producator("Apple", reduceri2),
            new Producator("Phillips", reduceri3),
        };

        Produs produs1 = new(Guid.NewGuid(), "Telefon", new Pret(250, Moneda.EUR), 0, producatori[0]);
        Produs produs2 = new(Guid.NewGuid(), "Televizor", new Pret(16000, Moneda.LEU), 0, producatori[2]);
        Produs produs3 = new(Guid.NewGuid(), "Masina", new Pret(16500, Moneda.EUR), 23, producatori[2]);
        Produs produs4 = new(Guid.NewGuid(), "Tableta", new Pret(800, Moneda.EUR), 21, producatori[1]);

        List<Produs> Produse = new() { produs1, produs2, produs3, produs4 };

        Catalog catalog = new(Produse, DateTime.Now.AddDays(14), DateTime.Now.AddDays(34), new List<Reducere>()
        {
            new Reducere("Reducere1", DateTime.Parse("2023-11-11")),
            new Reducere("Reducere2", DateTime.Parse("2023-11-28"))
        });

        #if DEBUG
            catalog.AplicaReduceri(reducere => reducere.Nume == "Oferta2");
        #else
            catalog.AplicaReduceri();
        #endif

        List<Client> clienti = new()
        {
            new Client { Email="example1@gmail.com", Moneda=Moneda.EUR, ProduseFavorite=new List<object>{ produs1.Id, produs2.Id } },
            new Client { Email="example2@gmail.com", Moneda=Moneda.USD, ProduseFavorite=new List<object> { produs1.Id , produs2.Id } },
            new Client { Email="example3@gmail.com", Moneda=Moneda.LEU, ProduseFavorite=new List<object> { produs3.Id, produs2.Id } },
            new Client { Email="example4@gmail.com", Moneda=Moneda.USD, ProduseFavorite=new List<object> { produs1.Id ,produs3.Id, produs4.Id } },
        };

        catalog.AbonareClient(clienti[0]);
        catalog.AbonareClient(clienti[1]);

        produs1.Pret = new Pret(350, Moneda.EUR);
        produs2.Pret = new Pret(18000, Moneda.LEU);
        produs4.Pret = new Pret(1200, Moneda.EUR);

        produs1.Stoc = 200;
        produs2.Stoc = 500;

        Console.WriteLine(produs1.Stoc);

        foreach (string msg in clienti[0].Inbox)
        {
            Console.WriteLine(msg);
        }

        catalog.DezabonareClient(clienti[0]);


        //produs1.Pret = new Pret(250, Moneda.EUR);
        foreach(string msg in clienti[0].Inbox)
        {
            Console.WriteLine(msg);
        }

        Console.WriteLine("=============Inainte de reducere aplicata=============");

        foreach (Produs produs in catalog.Produse)
        {
            Console.WriteLine($"{produs.Nume} - {produs.Pret.Valoare} {produs.Pret.Moneda}");
        }

        IEnumerable<Produs> AplicaReducere()
        {
            if (catalog.PerioadaStart == null || catalog.PerioadaStop == null)
            {
                throw new ArgumentNullException("perioada pentru reduceri nu poate fi nula");
            }

            foreach(Produs produs in catalog.Produse)
            {
                DateTime perioadaStart = (DateTime)catalog.PerioadaStart;
                DateTime perioadaStop = (DateTime)catalog.PerioadaStop;

                List<Reducere> reduceriProducator = produs.Producator.Reduceri.Where(reducere =>
                    reducere.Data.IsInRange(perioadaStart, perioadaStop)).ToList();

                List<Reducere> reduceriVanzator = catalog.Reduceri.Where(reducere =>
                    reducere.Data.IsInRange(perioadaStart, perioadaStop)).ToList();

                reduceriProducator.Sort();
                reduceriVanzator.Sort();

                foreach(Reducere reducere in reduceriProducator)
                {
                    reducere.Aplica(produs);
                }

                foreach(Reducere reducere in reduceriVanzator)
                {
                    reducere.Aplica(produs);
                }

                yield return produs;
            }
        }

        Console.WriteLine("=============Dupa Reducere aplicata=============");

        foreach(Produs prod in AplicaReducere())
        {
            Console.WriteLine($"{prod.Nume} - {prod.Pret.Valoare} {prod.Pret.Moneda}");
        }

        // 8. Itereaza pe lista de client si afiseaza informatii despre fiecare in felul urmator.

        Console.WriteLine("=============Iterarea clientilor=============\n");

        foreach (Client client in clienti)
        {
            var produseFavorite = new List<Produs>();
            foreach(var produs in catalog.Produse)
            if(client.ProduseFavorite.Contains(produs.Id))
            {
                produseFavorite.Add(produs);
            }
            Console.WriteLine("Email: {0}", client.Email);
            foreach(var produs in produseFavorite)
            {
                Console.WriteLine(produs.Nume);
            }

            for(int i = 0; i < client.Inbox.Count; i++)
            {
                Console.WriteLine($"{i + 1} {client.Inbox[i]}");
            }
            //foreach(string mes in client.Inbox)
            //{
            //    Console.WriteLine("");
            //}
        }
    }
}

