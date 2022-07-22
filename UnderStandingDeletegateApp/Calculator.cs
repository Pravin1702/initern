using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderStandingDeletegateApp
{
    class Calculator
    {
        public void Add(int n1, int n2)
        {
            Console.WriteLine($"The sum of {n1} and {n2} is {(n1 + n2)}");
        }
        public void Subract(int n1, int n2)
        {
            Console.WriteLine($"The result of subracting {n2} from {n1} is {(n1 - n2)}");
        }
        
        public void Multiply(int n1, int n2)
        {
            Console.WriteLine($"The product of {n1} and {n2} is {(n1 * n2)}");
        }
        public void Divide(int n1, int n2)
        {
            Console.WriteLine($"The  result of dividing {n1} by {n2} is {(n1 / n2)}");
        }
    }
}
