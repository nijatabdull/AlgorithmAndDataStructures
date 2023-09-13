namespace Algorithm.SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 11, 2, 3, 1, 6, -1, 4, 2, 7 };

            int[] sorted = SelectionSort(ints);

            foreach (int i in sorted)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        public static int[] SelectionSort(int[] arr)
        {
            // 11, 2, 3, 1, 6
            // 1, 2, 3, 6, 11
            // 1, 2, 3, 6, 11

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int selected = 0;
                for (int j = 0; j < i; j++)
                {
                    if (arr[selected] < arr[j + 1])
                    {
                        selected = j + 1;
                    }
                }

                if (arr[i] < arr[selected])
                {
                    int temp = arr[selected];
                    arr[selected] = arr[i];
                    arr[i] = temp;
                }
            }

            return arr;
        }
    }
}