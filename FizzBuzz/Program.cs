using System;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static void Main( string[] args )
        {
            var first = (args.Length > 0 ? int.Parse(args[0]) : 1);
            var last = (args.Length > 1 ? int.Parse(args[1]) : 100);
            var fizzBuzzer = new FizzBuzzer.FizzBuzzer();
            fizzBuzzer.AddRule(3, "Fizz");
            fizzBuzzer.AddRule(5, "Buzz");
            fizzBuzzer.AddRule(30, "Moo");

            var range = fizzBuzzer.GetFizzBuzz(first, last).ToList();
            range.ForEach(x =>
                         {
                             if (!string.IsNullOrWhiteSpace(x))
                                 Console.WriteLine(x);
                         });

            Console.ReadLine();
        }
    }
}
