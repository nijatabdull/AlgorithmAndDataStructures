using DataStructure.Tree.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataStructure.Tree.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IndexController : ControllerBase
    {
        private readonly ILogger<IndexController> _logger;

        public IndexController(ILogger<IndexController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            BinarySearchTree<int> binarySearchTree = new();

            binarySearchTree.Insert(5);
            binarySearchTree.Insert(1);
            binarySearchTree.Insert(4);
            binarySearchTree.Insert(10);
            binarySearchTree.Insert(9);
            binarySearchTree.Insert(2);
            binarySearchTree.Insert(0);
            binarySearchTree.Insert(11);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(12);

            TreeNode<int> min = binarySearchTree.Min();
            TreeNode<int> max = binarySearchTree.Max();

            TreeNode<int> get = binarySearchTree.Get(4);

            foreach (var item in binarySearchTree.TraverseInOrder())
            {
                Debug.WriteLine(item);
            }

            binarySearchTree.Remove(10);

            return Ok();
        }
    }
}