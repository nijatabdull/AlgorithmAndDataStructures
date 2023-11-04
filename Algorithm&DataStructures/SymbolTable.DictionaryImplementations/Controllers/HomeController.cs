using Microsoft.AspNetCore.Mvc;
using SymbolTable.DictionaryImplementations.Models;

namespace SymbolTable.DictionaryImplementations.Controllers
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
        public IActionResult TestSeparateChaining()
        {
            ChainDictionary<int, string> keyValuePairs = new ChainDictionary<int, string>();

            for (int i = 0; i < 60; i++)
            {
                keyValuePairs.Add(i, $"test{i}");
            }

            keyValuePairs.TryGetValue(0, out var keyValue);

            keyValuePairs.Remove(0);

            keyValuePairs.TryGetValue(0, out var valuess);

            return Ok();
        }

        [HttpGet]
        public IActionResult TestLinearProbing()
        {
            LinearDictionary<int, string> keyValuePairs = new LinearDictionary<int, string>();

            for (int i = 0; i < 60; i++)
            {
                keyValuePairs.Add(i, $"test{i}");
            }

            return Ok();
        }
    }
}