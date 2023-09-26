using System;

class Program
{
    static void Main(string[] args)
    {
        int num;
        Console.WriteLine("Enter a number: ");
        while (true)
        {
            num = Convert.ToInt32(Console.ReadLine());
            if (Math.Floor(Math.Log10(num) + 1) < 3)
            {
                Console.WriteLine("Try another number that have at least 3 digits");
                continue;
            }
            else
            {
                Console.WriteLine($"Oglinditul numarului {num} este {ogl(num)} si el {isPerfectSquare(ogl(num))}");
                break;
            }
        }
    }

    public static int ogl(int n)
    {
        int r = 0;
        do
        {
            r = 10 * r + n % 10;
            n /= 10;
        } while (n != 0);

        return r;
    }

    public static string isPerfectSquare(int num)
    {
        double res = Math.Sqrt(num);
        if (res % 1 == 0)
        {
            return "este patrat perfect";
        } else return "eu este patrat perfect";
    }
}
