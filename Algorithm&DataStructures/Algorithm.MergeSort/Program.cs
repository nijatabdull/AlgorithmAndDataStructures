namespace Algorithm.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 11, 2, 3, 1, 6, -1, 4, 2, -2 };

            int[] sorted = MergeSort(ints);

            foreach (int i in sorted)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        private static int[] MergeSort(int[] arr)
        {
            //11, 2, 3, 1, 6, -1, 4, 2, -2 

            //11, 2, 3, 1, 6  | -1, 4, 2, -2 

            int leftArrLength = 0;
            int count = arr.Length;

            if (count % 2 == 0)
                leftArrLength = count / 2;
            else
                leftArrLength = count / 2 + 1;

            int rightArrLength = count - leftArrLength;

            int[] leftArr = new int[leftArrLength];

            if (count > 1 && leftArrLength >= 1)
            {
                Array.Copy(arr, 0, leftArr, 0, leftArrLength);
                leftArr = MergeSort(leftArr);
            }
            else if (leftArrLength > 0)
            {
                leftArr = arr;
            }

            int[] rightArr = new int[rightArrLength];

            if (count > 1 && rightArrLength >= 1)
            {
                Array.Copy(arr, rightArrLength + 1, rightArr, 0, rightArrLength);
                rightArr = MergeSort(rightArr);
            }
            else if(rightArrLength > 0)
            {
                rightArr = arr;
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                Swap(arr, i, i + 1);
            }

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
    }
}
