namespace Algorithm.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] ints = { 11, 2, 3, 1, 6, -1, 4, 2, -2 };
            int[] ints = GenerateNewArray(98);

            //11, 2, 3, 1, 6, -1, 4, 2, -2 

            int[] sorted = MergeSort(ints);

            foreach (int i in sorted)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        private static int[] MergeSort(int[] arr)
        {
            int count = arr.Length;
            int leftArrLength;

            if (count % 2 == 0)
                leftArrLength = count / 2;
            else
                leftArrLength = count / 2 + 1;

            if (count == 1 && leftArrLength == 1)
                return arr;

            int[] leftArr = new int[leftArrLength];

            Array.Copy(arr, 0, leftArr, 0, leftArrLength);
            leftArr = MergeSort(leftArr);

            int rightArrLength = count - leftArrLength;

            int[] rightArr = new int[rightArrLength];

            Array.Copy(arr, leftArrLength, rightArr, 0, rightArrLength);
            rightArr = MergeSort(rightArr);

            int[] resultArr = new int[leftArrLength + rightArrLength];

            int i = 0, j = 0;

            while (i + j < leftArrLength + rightArrLength)
            {
                if (j >= rightArrLength)
                    resultArr[i + j] = leftArr[i++];
                else if (i >= leftArrLength)
                    resultArr[i + j] = rightArr[j++];
                else if (leftArr[i] <= rightArr[j])
                    resultArr[i + j] = leftArr[i++];
                else if (leftArr[i] > rightArr[j])
                    resultArr[i + j] = rightArr[j++];
            }

            return resultArr;
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
