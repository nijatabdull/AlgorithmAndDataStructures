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
            // 11, 2, 3, 1, 6
            // 2, 11, 3, 1, 6
            // 2, 3, 11, 1, 6
            // 2, 3, 1, 11, 6
            // 2, 3, 1, 6, 11

            for (int i = nums.Length -1; i >= 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }

            return nums;
        }
    }
}