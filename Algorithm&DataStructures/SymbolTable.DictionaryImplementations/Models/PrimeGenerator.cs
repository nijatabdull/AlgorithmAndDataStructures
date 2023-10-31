namespace SymbolTable.DictionaryImplementations.Models
{
    public class PrimeGenerator
    {
        public IEnumerable<int> GetPrimes(int max)
        {
            bool[] consumptions = new bool[max + 1];

            for (int i = 2; i <= max; i++)
            {
                if (consumptions[i]) continue;

                yield return i;

                for (int j = i; j <= max; j += i) consumptions[j] = true;
            }
        }
    }
}
