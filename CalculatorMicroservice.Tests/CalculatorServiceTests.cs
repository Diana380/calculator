using NUnit.Framework;
using CalculatorMicroservice;
using System;

namespace CalculatorMicroservice.Tests
{
    public class Tests
    {
        private Services.CalculatorService _calculatorService;
        [SetUp]
        public void Setup()
        {
            _calculatorService = new Services.CalculatorService();
        }

        [Test]
        public void AddStringNumbersCommaDelimited()
        {
            var testString = "1,2";
            var result = _calculatorService.Add(testString);
            Assert.AreEqual(3, result);
        }
        [Test]
        public void AddEmptyString()
        {
            var result = _calculatorService.Add(string.Empty);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void AddWithNewLineDelimiter()
        {
            var testString = "1\n2,3";
            var result = _calculatorService.Add(testString);
            Assert.AreEqual(6, result);
        }
        [Test]
        public void AddWithIncorrectineDelimiter()
        {
            try
            {
                var testString = "1,\n";
                var result = _calculatorService.Add(testString);
            }
            catch(Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Unrecognised delimiter format"));
            }

        }
        [Test]
        public void AddWithSingleDelimiters()
        {
            var testString = "//;\n1;2";
            var result = _calculatorService.Add(testString);
            Assert.AreEqual(3, result);
        }
        [Test]
        public void AddMultipleNegativeNumber()
        {
            var testString = "1, -2, -3";
            try
            {
                var result = _calculatorService.Add(testString);
            }
            catch(Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Negative numbers not allowed:-2 -3 "));
            }           
        }
        [Test]
        public void AddNumberHigherThanThousand()
        {
            var testString = "1, 2, 1001";
            var result = _calculatorService.Add(testString);
            Assert.AreEqual(3, result);
        }
        [Test]
        public void AddWithMultipleDelimiters()
        {
            var testString = "//*%\n1*2%3";
            var result = _calculatorService.Add(testString);
            Assert.AreEqual(6, result);
        }

    }
}