namespace Algorithm.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new[] { 6, 3, 12, 1, 4, 8, 2, 9, 7, 11, 5, 10 };

            Array.Sort(arr);

            // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12

            //int index2 = FindIndexByBinarySearch(arr, 9);


            for (int i = 0; i < arr.Length; i++)
            {
                int index = FindIndexByBinarySearch(arr, arr[i]);
                Console.WriteLine($"Index: {index}");
            }

            Console.WriteLine("End");

            Console.ReadLine();
        }

        private static int FindIndexByBinarySearch(int[] array, int num)
        {
            int index = 0;

            int left = 0;
            int right = array.Length;

            while (right > left)
            {
                int mid = (left + right) / 2;

                if (array[mid] == num)
                {
                    index = mid; break;
                }
                else if (array[mid] > num) //left
                {
                    right = mid;
                }
                else //right
                {
                    left = mid + 1;
                }
            }

            return index;
        }
    }
}