namespace Algorithm.ShellSort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] ints = { 11, 2, 3, 1, 6, -1, 4, 2, -2 };

            //int[] ints2 = GenerateNewArray(1000);

            int[] sorted = ShellSort(ints);

            foreach (int i in sorted)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        public static int[] ShellSort(int[] arr)
        {
            //11, 2, 3, 1, 6, -1, 4, 2, -2

            int gap = 1;

            while (gap < arr.Length / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    for (int j = i; j >= gap && arr[j] < arr[j - gap]; j -= gap)
                    {
                        Swap(arr, j, j - gap);
                    }
                }

                gap /= 2;
            }

            return arr;
        }

        public static int[] ShellSortWithRecursion(int[] arr)
        {
            //11, 2, 3, 1, 6, -1, 4, 2, -2
            //6, 2, 3, 1, 11, -1, 4, 2, -2
            //11, -1, 3, 1, 6, 2, 4, 2, -2
            //11, -1, 3, 1, -2, 2, 4, 2, 6
            //-2, -1, 3, 1, 11, 2, 4, 2, 6

            int gap = 1;

            while (gap < arr.Length / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    int left = i;
                    int right = i + gap;

                    Recursion(arr, left, right, gap);
                }

                gap /= 2;
            }

            return arr;
        }

        private static void Recursion(int[] arr, int left, int right, int gap)
        {
            if (left < 0)
                return;

            if (right >= arr.Length)
                return;

            if (arr[left] > arr[right])
            {
                Swap(arr, left, right);

                Recursion(arr, left - gap, right - gap, gap);
            }

            return;
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