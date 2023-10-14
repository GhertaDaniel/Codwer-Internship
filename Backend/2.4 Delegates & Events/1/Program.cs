using _1;

public enum Moneda
{
    LEU,
    EUR,
    USD
}

public delegate void ModificatorPretStoc<T, TResponse>(T old, T neww, TResponse obj);

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

        Produs produs1 = new(Guid.NewGuid(), "Telefon", new Pret(250, Moneda.EUR), 10, producatori[0]);
        Produs produs2 = new(Guid.NewGuid(), "Televizor", new Pret(16000, Moneda.LEU), 5, producatori[2]);
        Produs produs3 = new(Guid.NewGuid(), "Masina", new Pret(16500, Moneda.EUR), 23, producatori[2]);
        Produs produs4 = new(Guid.NewGuid(), "Tableta", new Pret(800, Moneda.EUR), 21, producatori[1]);

        List<Produs> Produse = new() { produs1, produs2, produs3, produs4 };

        Catalog catalog = new(Produse, DateTime.Now.AddDays(14), null, new List<Reducere>()
        {
            new Reducere("Reducere1", DateTime.Parse("2023-10-01")),
            new Reducere("Reducere2", DateTime.Parse("2023-10-15"))
        });

        List<Client> clienti = new()
        {
            new Client { Email="example1@gmail.com", Moneda=Moneda.EUR, ProduseFavorite=new List<object>{ produs1.Id  } },
            new Client { Email="example2@gmail.com", Moneda=Moneda.USD, ProduseFavorite=new List<object> { produs1.Id , produs2.Id } },
            new Client { Email="example3@gmail.com", Moneda=Moneda.LEU, ProduseFavorite=new List<object> { produs3.Id, produs2.Id } },
            new Client { Email="example4@gmail.com", Moneda=Moneda.USD, ProduseFavorite=new List<object> { produs1.Id ,produs3.Id, produs4.Id } },
        };

        catalog.AbonareClient(clienti[0]);
        catalog.AbonareClient(clienti[1]);

        produs1.Pret = new Pret(350, Moneda.EUR);
        produs2.Pret = new Pret(18000, Moneda.LEU);
        produs4.Pret = new Pret(1200, Moneda.EUR);

        foreach (string mess in clienti[0].Inbox)
        {
            Console.WriteLine(mess);
        }

        catalog.DezabonareClient(clienti[0]);


        produs1.Pret = new Pret(250, Moneda.EUR);
        foreach(string mes in clienti[0].Inbox)
        {
            Console.WriteLine(mes);
        }

        Console.ReadLine();
    }
}

