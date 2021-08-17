using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace CalculatorMicroservice.Services
{
    public class CalculatorService
    {

        public int Add(string numbers)
        {
            var result = ValidateNumbers(numbers);
            if (result.Count > 1)
            {
                return Calculate(result);

            }

            else
            {
                return result.First();
            }

        }
        private static int Calculate(List<int> numbers)
        {
            int result = 0;
            foreach (var n in numbers)
            {
                if (n > 1000)
                {
                    continue;
                }

                result = result + n;


            }
            return result;
        }

        private static List<int> ValidateNumbers(string input)
        {
            List<int> results = new List<int>();
            string[] numbers;

            if (String.IsNullOrEmpty(input))
            {
                numbers = new string[] { "0" };
            }
            else if (input.Contains("//"))
            {
                var inputArray = Regex.Split(input, @"[\n]");
                var l = inputArray.First();
                var delimArray = l.ToCharArray();
                var delims = delimArray[2..delimArray.Length];


                var secondPart = inputArray.Last();
                numbers = secondPart.Split(delims);

            }
            else
            {
                numbers = Regex.Split(input, @"[,\n]");
            }
            
            foreach (var n in numbers)
            {
                if(string.IsNullOrEmpty(n))
                {
                    throw new Exception("Unrecognised delimiter format");
                }
            }
  

            var negativeNumbers = new List<int>();
            foreach (var n in numbers)
            {

                if (int.TryParse(n, out var result))
                {
                    if (result < 0)
                    {
                        negativeNumbers.Add(result);
                        continue;
                    }
                    results.Add(result);
                }
            }
            if (negativeNumbers.Count > 0)
            {
                var message = "Negative numbers not allowed:";
                foreach (var n in negativeNumbers)
                {
                    message = message + n.ToString() + " ";
                }

                throw new Exception(message);
            }
            return results;
        }

    }

}

