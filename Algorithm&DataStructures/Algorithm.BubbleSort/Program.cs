namespace Algorithm.BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 11, 2, 3, 1, 6 };

            int[] sorted = BubbleSort(ints);

            foreach (int i in sorted)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        internal static int[] BubbleSort(int[] nums)
        {
            return nums;
        }
    }
}