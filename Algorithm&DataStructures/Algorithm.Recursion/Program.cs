namespace Algorithm.Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = Factorial(100000);

            Console.WriteLine(result);

            Console.ReadKey();
        }

        internal static int Factorial(int x)
        {
            // n! = n * (n -1)!

            // 5! = 1 * 2 * 3 * 4 * 5
            // 1 * 2 * 3 * 20

            if (x < 0)
                throw new InvalidOperationException("Value can not be negative.");

            if (x == 0)
                return 1;

            return Factorial(x - 1) * x;
        }
    }
}