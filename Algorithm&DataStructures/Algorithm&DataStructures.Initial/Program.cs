namespace Algorithm_DataStructures.Initial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Array array = Array.CreateInstance(typeof(int), 10);

            array.SetValue(1, 0);

            Console.ReadLine();
        }

        static void MultiDimensionArray()
        {
            int[,] arr = new int[2, 1] { { 1 }, { 1 } };


        }

        static void JaggedArray()
        {
            int[][] arr = new int[4][];

            arr[0] = new int[1];
            arr[1] = new int[2];
            arr[2] = new int[3];
            arr[3] = new int[4];

            //1
            //2 3
            //4 5 6
            //7 8 9 10
        }
    }
}