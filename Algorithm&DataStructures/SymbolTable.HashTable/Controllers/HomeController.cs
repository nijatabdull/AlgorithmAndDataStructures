using Microsoft.AspNetCore.Mvc;
using SymbolTable.HashTable.Model;
using System.Diagnostics;

namespace SymbolTable.HashTable.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController : ControllerBase
{
    public HomeController()
    {

    }

    [HttpGet]
    public IActionResult TestEquality()
    {
        PhoneNumber phoneNumber = new PhoneNumber() { Country = "AZE", Number = "517552617", Prefix = "+994" };
        PhoneNumber phoneNumber2 = new PhoneNumber() { Country = "AZE", Number = "517552617", Prefix = "+994" };

        bool equalityRef = phoneNumber == phoneNumber2;
        bool equalityMeth = phoneNumber.Equals(phoneNumber2);

        Debug.WriteLine($"equalityRef: {equalityRef}");
        Debug.WriteLine($"equalityMeth: {equalityMeth}");

        Person person = new() { Id = 1 };

        Dictionary<PhoneNumber, Person> keyValuePairs = new Dictionary<PhoneNumber, Person>();

        keyValuePairs.Add(phoneNumber, person);

        PhoneNumber phoneNumber3 = new PhoneNumber() { Country = "AZE", Number = "517552617", Prefix = "+994" };

        bool contains = keyValuePairs.ContainsKey(phoneNumber3);

        Debug.WriteLine($"contains: {contains}");

        return Ok();
    }

    [HttpGet]
    public IActionResult TestComparison()
    {
        // Make string from char[] to ensure it's not already interned
        string s1 = new string(new[] { 'H', 'e', 'l', 'l', 'o' });

        string zad = string.IsInterned(s1);

        string i1 = string.Intern(s1);

        string za2d = string.IsInterned(s1);

        bool result1 = object.ReferenceEquals(s1, i1);

        string s2 = new string(new[] { 'H', 'e', 'l', 'l', 'o' });
        string i2 = string.Intern(s2);
        bool result2 = object.ReferenceEquals(s2, i2);
        bool result23 = object.ReferenceEquals(i1, i2);

        bool asd = s2 == i2;
        bool asd2 = i1 == i2;

        return Ok();
    }

    [HttpGet]
    public IActionResult TestComparison2()
    {
        string s1 = "test";
        string s2 = "test";
        string s3 = "test1".Remove(4);
        object s4 = s3;  // Notice: set to object variable!

        Debug.WriteLine($"{object.ReferenceEquals(s1, s2)} {s1 == s2} {s1.Equals(s2)}");
        Debug.WriteLine($"{object.ReferenceEquals(s1, s3)} {s1 == s3} {s1.Equals(s3)}");
        Debug.WriteLine($"{object.ReferenceEquals(s1, s4)} {s1 == s4} {s4.Equals(s1)}");

        return Ok();
    }
}
