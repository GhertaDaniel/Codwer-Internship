using System;

class Program
{
    static void Main()
    {
        int n;
        float[] t;
        float min;
        Console.WriteLine("Numarul de numere pentru array: ");
        n = Convert.ToInt32(Console.ReadLine());
        t = new float[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"t[{i}]: ", "\n");
            t[i] = Convert.ToSingle(Console.ReadLine());
        }
    
        Console.WriteLine("Numerele intregi: ");
        for (int i = 0; i < t.Length; i++)
        {
            if(t[i] % 1 != 0) Console.Write(t[i] + " ");
        }
        Console.WriteLine("\n");
        min = t[0];
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] < min)
            {
                min = t[i];
            }
        }
    
        Console.WriteLine($"cel mai mic numar din array: {min}");
    }
}
