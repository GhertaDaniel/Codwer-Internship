struct Dimensiune
{
    public decimal lungime;
    public decimal latime;
    public decimal inaltime;
}

public enum TipAnimal
{
    Lup,
    Urs,
    Oaie,
    Veverita,
    Pisica,
    Vaca
}

abstract class Animal
{
    public string nume { get; set; }
    public decimal greutate { get; set; }
    public Dimensiune dimensiune;
    public decimal viteza { get; set; }

    protected List<Mancare> Stomac { get; set; } = new();

    public static int numar;

    public Animal(string nume, decimal greutate, Dimensiune dimensiune, decimal viteza)
    {
        this.dimensiune = dimensiune;
        this.nume = nume;
        this.greutate = greutate;
        this.viteza = viteza;

        numar++;
    }

    public void Mananca(Mancare m)
    {
        if((this is Carnivor && m is Carne) || (this is Erbivor && m is Planta) || (this is Omnivor && (m is Carne || m is Planta)))
        {
            if(m.greutate <= greutate / 8)
            {
                Stomac.Add(m);
                Console.WriteLine("Mananca");
            }
        } else
        {
            Console.WriteLine("Animalul nu poate consuma aceasta mancare");
        }
    }

    public abstract double Energie();

    public void Alearga(decimal distanta)
    {
        decimal timp = distanta / (viteza / (decimal)Energie());
        Console.WriteLine("{0} parcurge in secunde", timp.ToString("0.00"));
    }

    public override string ToString()
    {
        return $"Tip animal: {this.GetType().Name}\n" +
            $"Nume: {nume}\n" +
            $"Greutate: {greutate} kg\n" +
            $"Dimensiuni: {dimensiune.lungime} x {dimensiune.latime} x {dimensiune.inaltime}\n" +
            $"Viteza: {viteza} m/s\n";
    }
}

class Carnivor : Animal
{
    public Carnivor(string nume, decimal greutate, Dimensiune dimensiune, decimal viteza) : base(nume, greutate, dimensiune, viteza) { }

    public override double Energie()
    {
        double mediaGreutateMancare = 0;
        double sumaEnergieMancare = 0;
        if(Stomac.Count > 0)
        {
            foreach(var mancare in Stomac)
            {
                mediaGreutateMancare += (double)mancare.greutate;
                sumaEnergieMancare += (double)mancare.energie;
            }

            mediaGreutateMancare /= Stomac.Count;
        }

        return 0.2 - (0.2 * (mediaGreutateMancare + sumaEnergieMancare));
    }

}

class Erbivor : Animal
{
    public Erbivor(string nume, decimal greutate, Dimensiune dimensiune, decimal viteza) : base(nume, greutate, dimensiune, viteza) { }

    public override double Energie()
    {
        double mediaGreutateMancare = 0;
        double sumaEnergieMancare = 0;
        if (Stomac.Count > 0)
        {
            
            foreach (var mancare in Stomac)
            {
                
                mediaGreutateMancare += (double)mancare.greutate;
                sumaEnergieMancare += (double)mancare.energie;
            }

            mediaGreutateMancare /= Stomac.Count;
        };

        return 0.5 + (0.33 * (mediaGreutateMancare + sumaEnergieMancare));
    }
}

class Omnivor : Animal
{
    public Omnivor(string nume, decimal greutate, Dimensiune dimensiune, decimal viteza) : base(nume, greutate, dimensiune, viteza) { }

    public override double Energie()
    {
        double mediaGreutateMancare = 0;
        double sumaEnergieMancare = 0;
        double coefGreutate = 0;
        if (Stomac.Count > 0)
        {
            foreach (var mancare in Stomac)
            {
                if (mancare is Planta)
                {
                    coefGreutate += 0.5;
                } else if(mancare is Carne)
                {
                    coefGreutate -= 0.5;
                }
                mediaGreutateMancare += (double)mancare.greutate;
                sumaEnergieMancare += (double)mancare.energie;
            }

            mediaGreutateMancare /= Stomac.Count;
        }
        return 0.35 + coefGreutate * (mediaGreutateMancare + sumaEnergieMancare);
    }
}

abstract class Mancare
{
    public decimal greutate;
    public decimal energie;

    public decimal Energie
    {
        get { return energie; }
        set
        {
            Energie = (value >= 0 && value <= (decimal)0.05) ? value : throw new ArgumentException("Energia trebuie sa aiba valori intre 0 si 0.05");
        }
    }
}

class Carne : Mancare { }
class Planta : Mancare { }


class Program
{
    static void Main()
    {
        Carnivor lup = new("lup", 65.21m, new Dimensiune { lungime = 1.6m, latime = 0.3m, inaltime = 0.5m }, 18.5m);
        Erbivor oaie = new("oaie", 81.38m, new Dimensiune { lungime = 1.84m, latime = 0.65m, inaltime = 0.74m }, 13.21m);
        Omnivor urs = new("urs", 134.27m, new Dimensiune { lungime = 2.3m, latime = 1.4m, inaltime = 1.73m }, 15.5m);

        Planta salata = new();
        salata.greutate = 0.250m;
        salata.energie = 0.03m;

        Carne sunca = new();
        sunca.greutate = 0.350m;
        sunca.energie = 0.05m;

        //lup.Mananca(sunca);
        //lup.Mananca(sunca);

        //oaie.Mananca(salata);
        //oaie.Mananca(salata);
        //oaie.Mananca(salata);

        //urs.Mananca(sunca);
        //urs.Mananca(salata);
        //urs.Mananca(salata);
        //urs.Mananca(salata);

        //lup.Alearga(200);
        //oaie.Alearga(200);
        //urs.Alearga(200);

        List<Animal> animale = new();

        for (int i = 1; i <= 10; i++)
        {
            int randomIndex = new Random().Next(Enum.GetValues(typeof(TipAnimal)).Length);
            TipAnimal tipRandom = (TipAnimal)randomIndex;

            decimal randomGreutate = Math.Round(Convert.ToDecimal(new Random().NextDouble() * 100), 2);
            Dimensiune randomDimensiune = new()
            {
                lungime = Math.Round(Convert.ToDecimal(new Random().NextDouble() * 5), 2),
                latime = Math.Round(Convert.ToDecimal(new Random().NextDouble() * 5), 2),
                inaltime = Math.Round(Convert.ToDecimal(new Random().NextDouble() * 5), 2),
            };

            decimal randomViteza = Math.Round(Convert.ToDecimal(new Random().NextDouble() * 100), 2);

            Animal animal = CreazaAnimal(tipRandom, "Animal", randomGreutate, randomDimensiune, randomViteza);

            animale.Add(animal);
        }


        foreach(Animal animal in animale)
        {
            if(animal is Carnivor)
            {
                animal.Mananca(sunca);
            } else if(animal is Erbivor)
            {
                animal.Mananca(salata);
            } else if(animal is Omnivor)
            {
                animal.Mananca(sunca);
                animal.Mananca(salata);
            }
        }

        List<Animal> animaleErbivore = animale.Where(a => a is Erbivor).ToList();
        List<Animal> animaleCarnivore = animale.Where(a => a is Carnivor).ToList();
        List<Animal> animaleOmnivore = animale.Where(a => a is Omnivor).ToList();

        Console.WriteLine($"{animaleOmnivore.Count} animale mananca mancare");
        Console.WriteLine($"{animaleErbivore.Count} animale mananca plante");
        Console.WriteLine($"{animaleCarnivore.Count} animale mananca carne");
    }

    public static Animal CreazaAnimal(TipAnimal tip, string nume, decimal greutate, Dimensiune dimensiune, decimal viteza)
    {
        //var animal = new Animal(nume, greutate, dimensiune.lungime,dimensiune.latime,dimensiune.inaltime,viteza);
        switch(tip)
        {
            case TipAnimal.Lup:
                return new Carnivor(nume, greutate, new Dimensiune { lungime=dimensiune.lungime, latime=dimensiune.latime, inaltime=dimensiune.inaltime }, viteza);
            case TipAnimal.Urs:
                return new Omnivor(nume, greutate, new Dimensiune { lungime = dimensiune.lungime, latime = dimensiune.latime, inaltime = dimensiune.inaltime }, viteza);
            case TipAnimal.Oaie:
                return new Erbivor(nume, greutate, new Dimensiune { lungime = dimensiune.lungime, latime = dimensiune.latime, inaltime = dimensiune.inaltime }, viteza);
            case TipAnimal.Veverita:
                return new Omnivor(nume, greutate, new Dimensiune { lungime = dimensiune.lungime, latime = dimensiune.latime, inaltime = dimensiune.inaltime }, viteza);
            case TipAnimal.Pisica:
                return new Carnivor(nume, greutate, new Dimensiune { lungime = dimensiune.lungime, latime = dimensiune.latime, inaltime = dimensiune.inaltime }, viteza);
            case TipAnimal.Vaca:
                return new Erbivor(nume, greutate, new Dimensiune { lungime = dimensiune.lungime, latime = dimensiune.latime, inaltime = dimensiune.inaltime }, viteza);
            default:
                throw new ArgumentException("Nu este asa tip de animal");
        }
    }
}