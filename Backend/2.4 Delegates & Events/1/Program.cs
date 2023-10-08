using _1;

public enum Moneda
{
    LEU,
    EUR,
    USD
}

//public delegate void changeValue<T, TResponse>(T old, T neww, TResponse obj);

class Program
{
    static void Main()
    {
        List<Reducere> reduceri1 = new()
        {
            new Reducere { Name = "Reducere1", Data = DateTime.Parse("2023-10-01"), Aplica = produs => Console.WriteLine($"Reducere1 aplicata pentru produsul {produs.Nume}") },
            new Reducere { Name = "Reducere2", Data = DateTime.Parse("2023-10-15"), Aplica = produs => Console.WriteLine($"Reducere2 aplicata pentru produsul {produs.Nume}") },
            new Reducere { Name = "Reducere3", Data = DateTime.Parse("2023-11-05"), Aplica = produs => Console.WriteLine($"Reducere3 aplicata pentru produsul {produs.Nume}") }
        };

        List<Reducere> reduceri2 = new()
        {
            new Reducere { Name = "Discount1", Data = DateTime.Parse("2023-09-20"), Aplica = produs => Console.WriteLine($"Discount1 aplicata pentru produsul {produs.Nume}") },
            new Reducere { Name = "Discount2", Data = DateTime.Parse("2023-10-10"), Aplica = produs => Console.WriteLine($"Discount2 aplicata pentru produsul {produs.Nume}") },
            new Reducere { Name = "Discount3", Data = DateTime.Parse("2023-10-30"), Aplica = produs => Console.WriteLine($"Discount3 aplicata pentru produsul {produs.Nume}") }
        };

        List<Reducere> reduceri3 = new()
        {
            new Reducere { Name = "Oferta1", Data = DateTime.Parse("2023-11-01"), Aplica = produs => Console.WriteLine($"Oferta1 aplicata pentru produsul {produs.Nume}") },
            new Reducere { Name = "Oferta2", Data = DateTime.Parse("2023-11-15"), Aplica = produs => Console.WriteLine($"Oferta2 aplicata pentru produsul {produs.Nume}") },
            new Reducere { Name = "Oferta3", Data = DateTime.Parse("2023-12-05"), Aplica = produs => Console.WriteLine($"Oferta3 aplicata pentru produsul {produs.Nume}") }
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
            new Producator() { Nume = "Samsung", Reduceri = reduceri1 },

            new Producator() { Nume = "Phillips", Reduceri = reduceri2 },

            new Producator() { Nume="Apple", Reduceri = reduceri3 }
        };

        Catalog catalog = new()
        {
            PerioadaStart = DateTime.Parse("2023-10-01"),
            PerioadaStop = DateTime.Parse("2024-10-01"),
            Reduceri = reduceri,
            Produse = new List<Produs>()
            {
                new Produs()
                {
                    Id = Guid.NewGuid(),
                    Nume="Telefon",
                    Pret=new() { Moneda=Moneda.EUR, Valoare=250 },
                    Producator=producatori[0],
                    Stoc=10
                },
                new Produs()
                {
                    Id = Guid.NewGuid(),
                    Nume="Televizor",
                    Pret=new() { Moneda=Moneda.LEU, Valoare=16000 },
                    Producator=producatori[0],
                    Stoc=5
                },
                new Produs()
                {
                    Id = Guid.NewGuid(),
                    Nume="Radio",
                    Pret=new() { Moneda=Moneda.USD, Valoare=75 },
                    Producator=producatori[2],
                    Stoc=15
                },
                new Produs()
                {
                    Id = Guid.NewGuid(),
                    Nume="Tableta",
                    Pret=new() { Moneda=Moneda.EUR, Valoare=800 },
                    Producator=producatori[1],
                    Stoc=21
                },
                new Produs()
                {
                    Id = Guid.NewGuid(),
                    Nume="Masina",
                    Pret=new() { Moneda=Moneda.EUR, Valoare=16500 },
                    Producator=producatori[1],
                    Stoc=23
                },
                new Produs()
                {
                    Id = Guid.NewGuid(),
                    Nume="Bicicleta",
                    Pret=new() { Moneda=Moneda.LEU, Valoare=12000 },
                    Producator=producatori[2],
                    Stoc=26
                },
            }
        };

        List<Client> clienti = new()
        {
            new Client { Email="example1@gmail.com", Moneda=Moneda.EUR, ProduseFavorite= new List<bool>
                {
                    true, false, true
                }
            },
            new Client { Email="example2@gmail.com", Moneda=Moneda.USD, ProduseFavorite=new List<bool>
                {
                    false, true, false
                }
            },
            new Client { Email="example3@gmail.com", Moneda=Moneda.LEU, ProduseFavorite=new List<bool>
                {
                    true, true, true
                }
            },
            new Client { Email="example4@gmail.com", Moneda=Moneda.USD, ProduseFavorite=new List<bool>
                {
                    false, false, true
                }
            },
        };

        Client Andrew = clienti[0];

        var clientFavoriteItems = catalog.ProduseFavorite(Andrew);

        foreach(var item in clientFavoriteItems)
        {
            catalog.AbonareSchimbarePret(item.Nume, Product_PriceChanged);
            //catalog.PriceChanged += Product_PriceChanged;
        }

        catalog.UpdateProductPrice("Telefon", 210);

        catalog.UpdateProductPrice("Radio", 250);

        catalog.DezabonareSchimbarePret("Telefon", Product_PriceChanged);

        catalog.UpdateProductPrice("Telefon", 320);

        static void Product_PriceChanged(string numeProdus, decimal newPrice)
        {
            Console.WriteLine($"Pretul la {numeProdus} sa schimbat in {newPrice:C}");
        }


        //catalog.UpdateProductPrice(catalog.Produse[0], 210);

        //Action TelefonSubscription = catalog.SubscribeToCatalog("Telefon");

        //Action TabletaSubscription = catalog.SubscribeToCatalog("Tableta");

        //catalog.UpdateProductPrice("Telefon", 499, Moneda.EUR);

        //catalog.UnsubscribeFromCatalog(TelefonSubscription);

        //catalog.UnsubscribeFromCatalog(TabletaSubscription);

        //catalog.UpdateProductPrice("Telefon", 300, Moneda.EUR);

        //catalog.SubscribeToCatalog("Telefon");

        //catalog.UpdateProductPrice("Telefon", 550, Moneda.EUR);

        static void Price_ProcessCompleted(object sender, Produs produs)
        {
            Console.WriteLine($"Pretul nou: {produs.Pret.Valoare}");
        }

        static void Stoc_ProcessCompleted(object sender, Produs produs)
        {
            Console.WriteLine($"Valoarea noua a stocului: {produs.Stoc}");
        }
    }
}

