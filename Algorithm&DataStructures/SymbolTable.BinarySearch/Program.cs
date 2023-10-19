using SymbolTable.BinarySearch.Model;

namespace SymbolTable.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchSt<int, string> binarySearchSt = new BinarySearchSt<int, string>();

            binarySearchSt.Add(1, "Nicat");
            binarySearchSt.Add(3, "Ruslan");
            binarySearchSt.Add(2, "Yusif");
            binarySearchSt.Add(4, "Yasin");
            binarySearchSt.Add(5, "Banan");
            binarySearchSt.Add(6, "Tural");
            binarySearchSt.Add(7, "Eli");
            binarySearchSt.Add(3, "Hesen");

            var zad = binarySearchSt.GetValueByKey(1);

            binarySearchSt.Remove(1);


            Console.ReadLine();
        }
    }
}