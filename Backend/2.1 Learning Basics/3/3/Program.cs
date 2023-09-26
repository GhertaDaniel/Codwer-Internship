string[] nume = new string[3] { "", "", ""};

// Citirea celor 3 nume de la tastatură
for (int i = 0; i < 3; i++)
{
    Console.Write("Introduceți numele {0}: ", i + 1);
    nume[i] = Console.ReadLine();
}

string toateNumele = string.Join("", nume).ToLower();

Dictionary<char, int> caracterCount = new Dictionary<char, int>();

foreach (char caracter in toateNumele)
{
    if (char.IsLetter(caracter))
    {
        if (caracterCount.ContainsKey(caracter))
        {
            caracterCount[caracter]++;
        }
        else
        {
            caracterCount[caracter] = 1;
        }
    }
}

Console.WriteLine("Caracterele comune și numărul lor de apariții în toate numele:");
foreach (var kvp in caracterCount)
{
    Console.WriteLine("Caracterul '{0}' apare de {1} ori.", kvp.Key, kvp.Value);
}
