using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static int maxRepeating(int[] arr, int n, int k)
        {
            for (int i = 0; i < n; i++)
                arr[(arr[i] % k)] += k;
            int max = arr[0], result = 0;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    result = i;
                }
            }
            return result;
        }
        public static void Main()
        {
            int[] arr = { 2, 3, 3, 5, 3, 4, 1, 7, 2, 10 };
            int n = arr.Length;
            int k = 11;
            Console.Write("Maximum repeating " + "element is: " + maxRepeating(arr, n, k));
        }
    }
}