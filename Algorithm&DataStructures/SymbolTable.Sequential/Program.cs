using SymbolTable.Sequential.Model;

namespace SymbolTable.Sequential
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinearSymbolTable<int, string> linearSymbolTable = new LinearSymbolTable<int, string>();

            linearSymbolTable.Add(1, "Nicat");
            linearSymbolTable.Add(2, "Ruslan");
            linearSymbolTable.Add(3, "Tofig");
            linearSymbolTable.Add(4, "Hesen");
            linearSymbolTable.Add(5, "Yusif");

            bool del = linearSymbolTable.Remove(3);

            string val = default;

            linearSymbolTable.TryGet(2, out val);

            Console.ReadKey();
        }
    }
}