using System;

class Espressor
{
    private int waterLevel; // Nivelul de apă în boiler
    private bool heaterOn; // Starea încălzitorului
    private bool cupPresent; // Starea prezenței cănii
    private int sugar;

    public Espressor()
    {
        waterLevel = 0;
        heaterOn = false;
        cupPresent = false;
        sugar = 0;
    }

    public void Start()
    {
        // Funcție pentru a porni expresorul
        Console.WriteLine("Espressorul a fost pornit.");
    }

    public void Stop()
    {
        // Funcție pentru a opri expresorul
        Console.WriteLine("Espressorul a fost oprit.");
    }

    public void AddWater(int amount)
    {
        // Funcție pentru a adăuga apă în boiler
        waterLevel += amount;
        Console.WriteLine($"A fost adăugată apă în boiler. Nivelul actual de apă: {waterLevel} ml");
    }

    public void AddSugar(int amount)
    {
        sugar += amount;
        Console.WriteLine($"A-ti adaugat {sugar} cuburi de zahar");
    }

    public void PlaceCup()
    {
        // Funcție pentru a plasa cana
        if(cupPresent)
        {
            Console.WriteLine("Deja este o cana introdusa.");
        } else
        {
            cupPresent = true;
            Console.WriteLine("Cana a fost introdusa.");
        }
    }

    public void RemoveCup()
    {
        // Funcție pentru a scoate cana
        if(!cupPresent)
        {
            Console.WriteLine("Nu este nici o cana introdusa");
        } else
        {
            cupPresent = false;
            Console.WriteLine("Cana a fost scoasă din receptacul.");
        }
    }

    public void BrewEspresso()
    {
        // Funcție pentru a face un espresso
        if (cupPresent && waterLevel >= 30 && !heaterOn)
        {
            StartHeater();
            Console.WriteLine("Espresso se prepară...");
            waterLevel = -30;
            Console.WriteLine("Espresso gata! Poți lua cana.");
            StopHeater();
        }
        else
        {
            Console.WriteLine("Nu poți face espresso acum. Verifică starea canii, nivelul de apă și încălzitorul.");
        }
    }

    private void StartHeater()
    {
        // Funcție pentru a porni încălzitorul
        heaterOn = true;
        Console.WriteLine("Încălzitorul a fost pornit.");
    }

    private void StopHeater()
    {
        // Funcție pentru a opri încălzitorul
        heaterOn = false;
        Console.WriteLine("Încălzitorul a fost oprit.");
    }
}

class Program
{
    static void Main()
    {
        Espressor espressor = new();

        while(true)
        {
            Console.WriteLine("\nOptiuni disponibile:");
            Console.WriteLine("1. Adauga apa in boiler");
            Console.WriteLine("2. Adauga zahar");
            Console.WriteLine("3. Plaseaza cana");
            Console.WriteLine("4. Scoate cana");
            Console.WriteLine("5. Prepara espresso");
            Console.WriteLine("6. Opreste esspresorul");
            Console.WriteLine("7. Iesire");

            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.WriteLine("Introdu cantitatea de apa (ml): ");
                    int waterAmount = int.Parse(Console.ReadLine());
                    espressor.AddWater(waterAmount);
                    break;
                case "2":
                    espressor.PlaceCup();
                    break;
                case "3":
                    int sugarAmount = int.Parse(Console.ReadLine());
                    espressor.AddSugar(sugarAmount);
                case "3":
                    espressor.RemoveCup();
                    break;
                case "4":
                    espressor.BrewEspresso();
                    break;
                case "5":
                    espressor.Stop();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opțiune invalidă. Te rog selectează din nou.");
                    break;
            }
        }
    }
}

//public void Main(s)
//{
//    Espressor expresor = new Espressor();

//    while (true)
//    {
//        Console.WriteLine("\nOpțiuni disponibile:");
//        Console.WriteLine("1. Adaugă apă în boiler");
//        Console.WriteLine("2. Plasează cana");
//        Console.WriteLine("3. Scoate cana");
//        Console.WriteLine("4. Prepară espresso");
//        Console.WriteLine("5. Oprește expresorul");
//        Console.WriteLine("6. Ieșire");

//        string choice = Console.ReadLine();

//        switch (choice)
//        {
//            case "1":
//                Console.Write("Introdu cantitatea de apă (ml): ");
//                int amount = int.Parse(Console.ReadLine());
//                expresor.AddWater(amount);
//                break;
//            case "2":
//                expresor.PlaceCup();
//                break;
//            case "3":
//                expresor.RemoveCup();
//                break;
//            case "4":
//                expresor.BrewEspresso();
//                break;
//            case "5":
//                expresor.Stop();
//                break;
//            case "6":
//                return;
//            default:
//                Console.WriteLine("Opțiune invalidă. Te rog selectează din nou.");
//                break;
//        }
//    }
//}