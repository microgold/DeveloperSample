using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {

        public static int GetFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Factorial is not defined for negative numbers.");

            // Base case: the factorial of 0 or 1 is 1
            if (n == 0 || n == 1)
                return 1;

            // Recursive case: n! = n * (n-1)!
            return n * GetFactorial(n - 1);
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
                return string.Empty;

            if (items.Length == 1)
                return items[0];

            if (items.Length == 2)
                return $"{items[0]} and {items[1]}";

            // Join all but the last item with a comma
            var allButLast = string.Join(", ", items.Take(items.Length - 1));

            // Add the last item with "and"
            return $"{allButLast} and {items[^1]}";
        }
    }
}