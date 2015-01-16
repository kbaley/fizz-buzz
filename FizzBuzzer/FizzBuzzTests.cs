using System;
using System.Linq;
using Faker;
using NUnit.Framework;

namespace FizzBuzzer
{
    public class FizzBuzzTests
    {

        private FizzBuzzer Get3By5Sut( )
        {
            var sut = new FizzBuzzer();
            sut.AddRule(3, "Fizz");
            sut.AddRule(5, "Buzz");

            return sut;
        }

        [Test]
        public void return_Fizz_if_divisible_by_3([Range(0, 99, 3)] int number)
        {
            // GIVEN
            var sut = Get3By5Sut();

            // WHEN
            var result = sut.GetFizzBuzz(number);

            // THEN
            StringAssert.StartsWith("Fizz", result);
        }

        [Test]
        public void return_Buzz_if_divisible_by_5([Range(0, 100, 5)] int number)
        {
            // GIVEN
            var sut = Get3By5Sut();

            // WHEN
            var result = sut.GetFizzBuzz(number);

            // THEN
            StringAssert.EndsWith("Buzz", result);
        }

        [Test]
        public void return_number_if_not_divisible_by_3_or_5([Range(1,100)] int number)
        {
            // GIVEN
            var sut = Get3By5Sut();
            if (number%3 == 0) return;
            if (number%5 == 0) return;

            // WHEN
            var result = sut.GetFizzBuzz(number);

            // THEN
            Assert.AreEqual(number.ToString(), result);
        }

        [Test]
        public void incorporate_arbitrary_rule([Range(1,25)] int number) {
            // GIVEN
            var sut = new FizzBuzzer();
            sut.AddRule(number, "Moo");

            // WHEN
            var result = sut.GetFizzBuzz(1, 1000);

            // THEN
            for (var i = 1; i <= 1000; i++)
            {
                var expectedResult = (i%number == 0 ? "Moo" : i.ToString());
                Assert.AreEqual(expectedResult, result.ElementAt(i-1));
            }
        }

        [Test]
        public void should_allow_multiple_rules()
        {
            // GIVEN
            var sut = new FizzBuzzer();
            sut.AddRule(4, "Four");
            sut.AddRule(7, "Seven");
            sut.AddRule(10, "Ten");

            // WHEN
            var result = sut.GetFizzBuzz(1, 1000);

            // THEN
            Assert.AreEqual("Four", result.ElementAt(3));
            Assert.AreEqual("Seven", result.ElementAt(6));
            Assert.AreEqual("9", result.ElementAt(8));
            Assert.AreEqual("Four", result.ElementAt(7));
            Assert.AreEqual("FourSeven", result.ElementAt(27));
            Assert.AreEqual("Ten", result.ElementAt(29));
            Assert.AreEqual("SevenTen", result.ElementAt(209));
            Assert.AreEqual("FourSevenTen", result.ElementAt(139));
            Assert.AreEqual("555", result.ElementAt(554));
        }

        [Test]
        public void can_override_rule()
        {
            // GIVEN
            var sut = Get3By5Sut();
            sut.AddRule(5, "Moo");

            // THEN
            Assert.AreEqual("Moo", sut.GetFizzBuzz(20));
            Assert.AreEqual("FizzMoo", sut.GetFizzBuzz(30));
        }
    }
}