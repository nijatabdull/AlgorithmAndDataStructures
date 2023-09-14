namespace Algorithm.InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 11, 2, 3, 1, 6, -1, 4, 2, 7 };

            int[] sorted = InsertionSort(ints);

            foreach (int i in sorted)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        public static int[] InsertionSort(int[] arr)
        {
            // 11, 2, 3, 1, 6
            // 11, 11, 3, 1, 6
            // 2, 11, 3, 1, 6
            // 2, 11, 11, 1, 6

            // 2, 3, 11, 1, 6
            // 2, 3, 11, 11, 6
            // 2, 3, 3, 11, 6
            // 2, 2, 3, 11, 6
            // 1, 2, 3, 11, 6
            // 1, 2, 3, 11, 11
            // 1, 2, 3, 6, 11

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int selectedValue = arr[i + 1];
                int j = 0;

                for (j = i; j >= 0 && arr[j] > selectedValue; j--)
                {
                    arr[j + 1] = arr[j];
                }

                arr[j + 1] = selectedValue;
            }

            return arr;
        }
    }
}