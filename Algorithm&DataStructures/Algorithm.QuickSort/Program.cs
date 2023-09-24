namespace Algorithm.QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] ints = { 11, 2, 3, 1, 6, -1, 4, 2, -2 };   |  I guess, this is worst cases O(n^2)
            //int[] ints = GenerateNewArray(98);

            int[] ints = { 5, 1, 3, 11, 6, -1, 2, 0, 4 };

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
            int pivot = arr.Length - 1;

            arr = Recursive(arr, pivot);

            return arr;
        }

        private static int[] Recursive(int[] arr, int pivot)
        {
            int i = 0;
            int m = -1;

            while (i <= pivot)
            {
                if (arr[i] > arr[pivot])
                {
                    i++;
                    continue;
                }
                else
                {
                    m++;
                    if (i == m)
                        i++;
                    else if (i > m)
                    {
                        if(i == pivot)
                            pivot = m;

                        Swap(arr, i, m);
                    }
                        
                }
            }

            Recursive(arr, pivot);

            return arr;
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