using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using _4._Entity_Framework_Core;
using _4._Entity_Framework_Core.Controller;
using Org.BouncyCastle.Asn1.X509;
using System;

//var host = Host.CreateDefaultBuilder(args).ConfigureServices(services => services.AddDbContext<MagazinContext>());

class Program
{
    public static void Main(string[] args)
    {

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services => services.AddDbContext<MagazinContext>()).Build();

        using(var magazinContext = new MagazinContext())
        {
            ProductController productController = new(magazinContext);
            PersonController personController = new(magazinContext);
            OrderController orderController = new(magazinContext);
            OrderProductsController orderProductsController = new(magazinContext);

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("=======================");
                Console.WriteLine("Alegeti optiunea");
                Console.WriteLine("1. Produse");
                Console.WriteLine("2. Persoane");
                Console.WriteLine("3. Comenzi");
                Console.WriteLine("4. Comenzi Produse");
                Console.WriteLine("*. Iesire");
                Console.WriteLine("=======================\n");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Alegeti optiunea");
                        Console.WriteLine("1. Afisarea Produselor");
                        Console.WriteLine("2. Afisarea unui singur produs");
                        Console.WriteLine("3. Adaugarea unui produs");
                        Console.WriteLine("4. Stergerea unui produs");
                        Console.WriteLine("5. Actualizarea unui produs");
                        Console.WriteLine("*. Iesire");
                        var produsOption = Console.ReadLine();
                        switch (produsOption)
                        {
                            case "1":
                                var products = productController.GetAllProducts();
                                Console.WriteLine($"Nr. de produse: {products.Count}");
                                foreach (var prod in products)
                                {
                                    Console.WriteLine($"Id: {prod.ProdusID}");
                                    Console.WriteLine($"Nume: {prod.NumeProdus}");
                                    Console.WriteLine($"Pret: {prod.Pret}");
                                }
                                break;
                            case "2":
                                Console.Write("Introduceti Id-ul produsului: ");
                                var produsId = Convert.ToInt32(Console.ReadLine());
                                var produsById = productController.GetProductById(produsId);
                                Console.WriteLine(produsById.ProdusID);
                                Console.WriteLine(produsById.NumeProdus);
                                Console.WriteLine(produsById.Pret);

                                break;
                            case "3":
                                Console.Write("Introdu numele produsului: ");
                                var numeProdus = Console.ReadLine();
                                Console.Write("Introdu pretul produsului: ");
                                var pretProdus = Convert.ToDecimal(Console.ReadLine());
                                Produs produsToAdd = new() { NumeProdus = numeProdus, Pret = pretProdus };
                                productController.AddProduct(produsToAdd);
                                break;
                            case "4":
                                Console.Write("Introdu id-ul produsului de modificat: ");
                                var prodId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Introdu numele nou: ");
                                var numeNouProdus = Console.ReadLine();
                                Console.Write("Introdu pretul nou: ");
                                var pretNouPret = Convert.ToDecimal(Console.ReadLine());
                                productController.UpdateProduct(prodId, numeNouProdus, pretNouPret);
                                break;
                            case "5":
                                Console.WriteLine("Introdu id-ul pentru stergere: ");
                                var produsDeleteId = Convert.ToInt32(Console.ReadLine());
                                productController.DeleteProductById(produsDeleteId);
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Alegeti optiunea");
                        Console.WriteLine("1. Afisarea persoanelor");
                        Console.WriteLine("2. Afisarea unei persoane");
                        Console.WriteLine("3. Adaugarea unei persoane");
                        Console.WriteLine("4. Actualizare unei persoane");
                        Console.WriteLine("5. Stergere unei persoane");
                        Console.WriteLine("*. Iesire");
                        var persoanaOptions = Console.ReadLine();
                        switch (persoanaOptions)
                        {
                            case "1":
                                    var persoane = personController.GetAllPersons();
                                    Console.WriteLine($"\nNr. de persoane: {persoane.Count}");
                                    foreach (var persoana in persoane)
                                    {
                                        Console.WriteLine($"Id: {persoana.PersoanaID}");
                                        Console.WriteLine($"Nume: {persoana.Nume}");
                                        Console.WriteLine($"Adresa: {persoana.Adresa}");
                                    }
                                break;
                            case "2":
                                Console.Write("Introdu id-ul persoanei: ");
                                var persoanaId = Convert.ToInt32(Console.ReadLine());
                                var persoanaById = personController.GetPersoanaById(persoanaId);
                                Console.WriteLine($"Id: {persoanaById.PersoanaID}");
                                Console.WriteLine($"Nume: {persoanaById.Nume}");
                                Console.WriteLine($"Adresa: {persoanaById.Adresa}");
                                break;
                            case "3":
                                Console.Write("Introdu numele persoanei: ");
                                string numePersoana = Console.ReadLine();
                                Console.Write("Introdu adresa persoanei: ");
                                string adresaPersoana = Console.ReadLine();
                                Persoana personToAdd = new Persoana() { Nume = numePersoana, Adresa = adresaPersoana };
                                personController.AddPerson(personToAdd);
                                break;
                            case "4":
                                Console.Write("Introdu id-ul persoanei de modificat: ");
                                var persId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Introdu numele nou: ");
                                var numeNou = Console.ReadLine();
                                Console.Write("Introdu pretul nou: ");
                                var adresaNoua = Console.ReadLine();
                                personController.UpdatePerson(persId, numeNou, adresaNoua);
                                break;
                            case "5":
                                Console.Write("Introdu id-ul pentru stergerea persoanei: ");
                                var persoanaDeleteId = Convert.ToInt32(Console.ReadLine());
                                personController.DeletePersonById(persoanaDeleteId);
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("Alegeti optiunea");
                        Console.WriteLine("1. Afisarea comenzilor");
                        Console.WriteLine("2. Afisarea unei comenzi");
                        Console.WriteLine("3. Adaugarea unei comenzi");
                        Console.WriteLine("4. Actualizare unei comenzi");
                        Console.WriteLine("4. Stergere unei comenzi");
                        Console.WriteLine("*. Iesire");
                        var comandaOptions = Console.ReadLine();
                        switch(comandaOptions)
                        {
                            case "1":
                                var orders = orderController.GetAllOrders();
                                Console.WriteLine($"\nNr. de comenzi: {orders.Count}");
                                foreach(var order in orders)
                                {
                                    Console.WriteLine($"Id-ul comenzii: {order.ComandaID}");
                                    Console.WriteLine($"Id-ul persoanei: {order.PersoanaID}");
                                    Console.WriteLine($"Descrierea: {order.Descriere}");
                                }
                                break;
                            case "2":
                                Console.Write("Introdu id-ul comenzii: ");
                                int orderId = Convert.ToInt32(Console.ReadLine());
                                var orderById = orderController.GetOrderById(orderId);
                                Console.WriteLine($"Id: {orderById.ComandaID}");
                                Console.WriteLine($"Id-ul persoanei: {orderById.PersoanaID}");
                                Console.WriteLine($"Descrierea: {orderById.Descriere}");
                                break;
                            case "3":
                                Console.Write("Introdu id-ul persoanei: ");
                                var persoanaId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Introdu descrierea: ");
                                var descriereComanda = Console.ReadLine();
                                Comanda orderToAdd = new Comanda() { PersoanaID = persoanaId, Descriere = descriereComanda };
                                orderController.AddOrder(orderToAdd);
                                break;
                            case "4":
                                Console.Write("Introdu id-ul comenzii de modificat: ");
                                var comandaId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Introdu id-ul persoanei: ");
                                var persId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Introdu descrierea noua: ");
                                var newDescr = Console.ReadLine();
                                orderController.UpdateProduct(comandaId, persId, newDescr);
                                break;
                            case "5":
                                Console.Write("Introdu id-ul pentru stergerea comenzii: ");
                                var orderDeleteId = Convert.ToInt32(Console.ReadLine());
                                orderController.DeleteOrderById(orderDeleteId);
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("Alegeti optiunea");
                        Console.WriteLine("1. Afisarea comenzilor cu produse");
                        Console.WriteLine("2. Afisarea unei comenzi cu produse");
                        Console.WriteLine("3. Adaugarea unei comenzi cu produse");
                        Console.WriteLine("4. Actualizarea unei comenzi cu produse");
                        Console.WriteLine("5. Stergerea unei comenzi cu produse");
                        Console.WriteLine("*. Iesire");
                        var comandaProduseOptions = Console.ReadLine();
                        switch(comandaProduseOptions)
                        {
                            case "1":
                                var ordersWithProducts = orderProductsController.GetAllOrdersWithProducts();
                                Console.WriteLine($"\nNr. de comenzi cu produse: {ordersWithProducts.Count}");
                                foreach (var order in ordersWithProducts)
                                {
                                    Console.WriteLine("ComandaId    ProdusId    Cantitate");
                                    Console.WriteLine("{0}          {1}         {2}", order.ComandaID, order.ProdusID, order.Cantitate);
                                }
                                break;
                            case "2":
                                Console.Write("Introdu id-ul comenzii: ");
                                int orderId = Convert.ToInt32(Console.ReadLine());
                                var orderById = orderProductsController.GetOrderWithProductsById(orderId);
                                Console.WriteLine($"Id-ul comenzii: {orderById.ComandaID}");
                                Console.WriteLine($"Id-ul persoanei: {orderById.ProdusID}");
                                Console.WriteLine($"Cantitate: {orderById.Cantitate}");
                                break;
                            case "3":
                                Console.Write("Introdu id-ul comenzii");
                                var comandaId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Introdu id-ul produsului: ");
                                var produsId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Introdu cantitatea: ");
                                var cantitate = Convert.ToInt32(Console.ReadLine());
                                ComandaProdus orderToAdd = new ComandaProdus() { ComandaID = comandaId, ProdusID = produsId, Cantitate= cantitate};
                                orderProductsController.AddOrderWithProducts(orderToAdd);
                                break;
                            case "4":
                                // Convert.ToInt32()
                                Console.Write("Introdu id-ul comenzii de modificat: ");
                                var orderModifyId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Introdu id-ul produsului de modificat: ");
                                var orderProdId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Introdu cantitatea modificata: ");
                                var newQuantity = Convert.ToInt32(Console.ReadLine());
                                orderProductsController.UpdateOrderWithProducts(orderModifyId, orderProdId, newQuantity);
                                break;
                            case "5":
                                Console.Write("Introdu id-ul comenzii pentru stergerea comenzii: ");
                                var orderDeleteId = Convert.ToInt32(Console.ReadLine());
                                orderProductsController.DeleteOrderWithProductsById(orderDeleteId);
                                break;
                        }
                        break;


                    case "*":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Nu exista asa comanda");
                        break;
                }
            }
        }

    }

}

class Startup
{
    public void ConfigureServices(IServiceCollection services) { }
}