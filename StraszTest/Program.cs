using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StraszTest.Business;
using StraszTest.Models;
using System;
using System.Collections.Generic;

namespace StraszTest {
    public class Program {
        static void Main(string[] args)
        {
            var testItems = new List<Item>();
            var testlet = new Testlet("Test Testlet", testItems);

            // create random 
            testItems = testlet.Randomize(6, 4);
            var jsonString = JsonConvert.SerializeObject(testItems);

            Console.WriteLine(JValue.Parse(jsonString).ToString(Formatting.Indented));
            Console.ReadKey();
        }
    }
}
