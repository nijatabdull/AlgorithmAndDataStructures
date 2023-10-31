using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Algorithm.SieveOfEretosthenes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Test()
        {
            foreach (var item in GetPrimeNumber(100))
            {
                Debug.WriteLine(item);
            }

            return Ok();
        }

        private IEnumerable<int> GetPrimeNumber(int max)
        {
            bool[] consumptions = new bool[max + 1];

            for (int i = 2; i <=max; i++)
            {
                if (consumptions[i]) continue;

                yield return i;

                for (int j = i; j <= max; j += i) consumptions[j] = true;
            }
        }
    }
}