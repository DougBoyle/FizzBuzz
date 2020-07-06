using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz {
    public class FizzBuzz : IEnumerable<string> {
        private string[] rules;
        private string[] custom;
        private int max;

        public FizzBuzz() {
            Console.Write("Enter rules to use (e.g. '3 5 11'): ");
            rules = Console.ReadLine().Split(' ');
            
            Console.Write("Enter own number-word pairs, will apply at end (e.g. 2-App 8-Bug): ");
            custom = Console.ReadLine().Split(' ');

            Console.Write("Enter upper limit: ");
            max = int.TryParse(Console.ReadLine(), out max) ? max : 100;
        }
        
        public string apply(int i) {
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
            }
            foreach (var s in custom) {
                try {
                    var numString = s.Split('-');
                    if (numString.Length == 2 && i % int.Parse(numString[0]) == 0) {
                        words.Add(numString[1]);
                    }
                }
                catch {} // int.Parse failed or attempted modulo 0
            }
            if (words.Count == 0) {
                return i.ToString();
            } else {
                return string.Join("", words);
            }
        }

        public IEnumerator<string> GetEnumerator() {
            for (var i = 0; i <= max; i++) {
                yield return apply(i);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public static void Main() {
           /* var fizzBuzz = new FizzBuzz();
            foreach (var s in fizzBuzz) {
                Console.WriteLine(s);
            }*/
           HorribleOneLiner();
        }

        public static void HorribleOneLiner() {
            Enumerable.Range(1, 100).ToList().Select(i => new KeyValuePair<int, List<string>>(i, new List<string>()))
                   .Select(p => new KeyValuePair<int, List<string>>(p.Key, p.Key % 3 == 0 ? p.Value.Append("Fizz").ToList() : p.Value))
                   .Select(p => new KeyValuePair<int, List<string>>(p.Key, p.Key % 5 == 0 ? p.Value.Append("Buzz").ToList() : p.Value))
                   .Select(p => new KeyValuePair<int, List<string>>(p.Key, p.Key % 7 == 0 ? p.Value.Append("Bang").ToList() : p.Value))
                   .Select(p => new KeyValuePair<int, List<string>>(p.Key, p.Key % 11 == 0 ? new List<string>() {"Bong"} : p.Value))
                   .Select(p => new KeyValuePair<int, List<string>>(p.Key, p.Key % 13 == 0 ? 
                       p.Value.Count > 0 && p.Value[0] == "Fizz" ? Enumerable.Concat(new List<string>(){"Fizz", "Fezz"}, p.Value.Skip(1)).ToList() :
                       Enumerable.Prepend(p.Value, "Fezz").ToList() : p.Value))
                   .Select(p => new KeyValuePair<int, List<string>>(p.Key, p.Key % 17 == 0 ? Enumerable.Reverse(p.Value).ToList() : p.Value))
                   .Select(p => p.Value.Count > 0 ? String.Join("",p.Value) : p.Key.ToString())
                   .ToList().ForEach(s => Console.WriteLine(s));
        }
    }
}