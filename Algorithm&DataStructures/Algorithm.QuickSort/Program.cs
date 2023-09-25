namespace Algorithm.QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 11, 2, 3, 1, 6, -1, 4, 2, -2 };
            //int[] ints = GenerateNewArray(9999);

            //int[] ints = { 5, 1, 3, 11, 6, -1, 2, 0, 4 };

            int[] sorted = QuickSort(ints);

            foreach (int i in sorted)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        private static int[] QuickSort(int[] arr)
        {
            //5, 1, 3, 11, 6, -1, 2, 0, 4        {9}

            Recursive(arr, 0, arr.Length - 1);

            return arr;
        }

        private static void Recursive(int[] arr, int low, int high)
        {
            int i = low;
            int m = low - 1;
            int pivot = high;

            while (i <= pivot)
            {
                if (i == pivot && i != ++m)
                {
                    pivot = m;
                    Swap(arr, i, m);
                }
                else if (arr[i] <= arr[pivot])
                {
                    m++;

                    if (i > m)
                    {
                        Swap(arr, i, m);
                    }
                }
                i++;
            }

            if (low < pivot - 1)
                Recursive(arr, low, pivot - 1);

            if (high > pivot + 1)
                Recursive(arr, pivot + 1, high);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            if (i != j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        private static int[] GenerateNewArray(int n)
        {
            // Define an array of values we wish to return and populate it
            int[] baseValues = Enumerable.Range(1, n).ToArray();
            Random rnd = new Random();
            // Shuffle the array randomly using Linq
            return baseValues.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}