using System;

namespace ruff2;

class Program
{
    void Divide()
    {
        int num1, num2;
        double result = 0;
        Console.WriteLine("Please enter the first number");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter the second number");
        num2 = Convert.ToInt32(Console.ReadLine());
        try
        {
            result = num1 / num2;
        }
        catch (DivideByZeroException dbz)
        {
            Console.WriteLine("Denominator cannot be zero");
        }
        Console.WriteLine($"The result is {result}");
    }
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Divide();
        Console.ReadKey();
    }
}