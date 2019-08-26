using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TDD.Business;
using TDD.Models;
using System;
using System.Collections.Generic;

namespace TDD {
    public class Program {
        static void Main(string[] args)
        {
            var testlet = new Testlet("Test Testlet");

            // create random 
            List<Item>  testItems = testlet.Randomize(6, 4);
            var jsonString = JsonConvert.SerializeObject(testItems);

            Console.WriteLine(JValue.Parse(jsonString).ToString(Formatting.Indented));
            Console.ReadKey();
        }
    }
}
