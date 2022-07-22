using System;

namespace ruffwork1
{
    class Program
    {
        double Divide()
        {
            int num1, num2;
            double result = 0;
            try
            {

                Console.WriteLine("Please enter the first number");
                num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the second number");
                num2 = Convert.ToInt32(Console.ReadLine());
                result = num1 / num2;
                return result;
            }
            catch (DivideByZeroException dbz)
            {
                Console.WriteLine("Denominator cannot be zero");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid entry for number");
            }
            catch (Exception e)
            {
                Console.WriteLine("oops something went wrong!!!!");
            }
            finally
            {
                Console.WriteLine("Will execute always");
            }
            Console.WriteLine($"The result is {result}");
            return 0;
        }
        static void Main(string[] args)
        {

            Program program = new Program();
            program.Divide();
            Console.ReadKey();
        }
    }

}