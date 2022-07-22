using System;

namespace UnderStandingDeletegateApp 
{
    class Program
    {
        //delegate void calc(int num1, int num2);
        void Calculate(Action<int, int> c)
        {
            int num1, num2;
            Console.WriteLine("Please enter the First number");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Second number");
            num2 = Convert.ToInt32(Console.ReadLine());
            c(num1, num2);

        }
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Action<int, int> c1 = calculator.Multiply;
            c1 += calculator.Add;
            c1 += delegate (int n1, int n2)
            {
                Console.WriteLine($"The  result of dividing {n1} by {n2} is {(n1 / n2)}");
            };
            c1 += (n1, n2) => Console.WriteLine($"The result of subracting {n2} from {n1} is {(n1 - n2)}");
            //calc c1 = new calc(calculator.Multiply);
            //creating object to point to the method
            //c1 += new calc(calculator.Add);
            //c1 += new calc(calculator.Subract);
            //c1 += new calc(calculator.Divide);
            Program program = new Program();
            program.Calculate(c1);
            Console.ReadKey();
        }
    }

}
