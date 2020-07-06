using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz {
    internal class Program {
        public static void Main() {
            Console.Write("Enter rules to use (e.g. '3 5 11'): ");
            var rules = Console.ReadLine().Split(' ');
            int max;
            Console.Write("Enter upper limit: ");
            max = int.TryParse(Console.ReadLine(), out max) ? max : 100;
            for (var i = 1; i <= max; i++) {
                var words = new List<string>();
                if (i % 3 == 0 && rules.Contains("3")) {
                     words.Add("Fizz");
                } if (i % 5 == 0 && rules.Contains("5")) {
                     words.Add("Buzz");
                } if (i % 7 == 0 && rules.Contains("7")) {
                    words.Add("Bang");
                } if (i % 11 == 0 && rules.Contains("11")) { // no fizz/buzz/bang
                     words = new List<string>() {"Bong"};
                } if (i % 13 == 0 && rules.Contains("13")) { // Fezz before first word starting with 'B'
                     if (words.Count > 0 && words[0] == "Fizz") {
                         words.Insert(1, "Fezz");
                     } else {
                         words.Insert(0, "Fezz");
                     }
                } if (i % 17 == 0 && rules.Contains("17")) {
                     words.Reverse();
                } if (words.Count == 0) {
                    Console.WriteLine(i);
                } else {
                    Console.WriteLine(string.Join("", words));
                }
            }
        }
    }
}