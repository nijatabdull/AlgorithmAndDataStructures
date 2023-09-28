namespace DataStructure.List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);


            list.Remove(7);

            list.Remove(8);

            list.Remove(1);

            list.Add(9);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}