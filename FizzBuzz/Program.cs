using System;
using System.Collections.Generic;

namespace FizzBuzz {
    internal class Program {
        public static void Main() {
            int max;
            max = int.TryParse(Console.ReadLine(), out max) ? max : 100;
            for (var i = 1; i <= max; i++) {
                var words = new List<string>();
                if (i % 3 == 0) {
                     words.Add("Fizz");
                } if (i % 5 == 0) {
                     words.Add("Buzz");
                } if (i % 7 == 0) {
                    words.Add("Bang");
                } if (i % 11 == 0) {
                     words = new List<string>();
                     words.Add("Bong");
                } if (i % 13 == 0) {
                     if (words.Count > 0 && words[0] == "Fizz") {
                         words.Insert(1, "Fezz");
                     } else {
                         words.Insert(0, "Fezz");
                     }
                } if (i % 17 == 0) {
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