using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SE2_1
{
    public class Calculator
    {
        public int Process(string input)
        {
            // 1. Empty string returns 0
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            // 2. Single number returns the value
            if (int.TryParse(input, out int singleNumber))
            {
                if(singleNumber < 0)
                {
                    throw new ArgumentException($"Negative numbers not allowed: {singleNumber}");
                }
                if(singleNumber > 2000)
                {
                    return 0;
                }
                return singleNumber;
            }

            ///8. A single char delimeter can be defined on the fist line (e.. //# for a '#' as the delimiter),
            List<string> customDelimiters = new List<string>();

            if (input.StartsWith("//"))
            {
                int newlineIndex = input.IndexOf('\n');
                if (newlineIndex > 2) // Ensure there's a delimiter defined
                {
                    string delimiterPart = input.Substring(2, newlineIndex - 2);
                    // Handling multi-character delimiters wrapped in []
                    if (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
                    {
                        var matches = Regex.Matches(delimiterPart, @"\[(.*?)\]");
                        foreach (Match match in matches)
                        {
                            customDelimiters.Add(match.Groups[1].Value);
                        }
                    }
                    else
                    {
                        // Single character delimiter (e.g., //# for '#')
                        customDelimiters.Add(delimiterPart);
                    }

                    input = input.Substring(newlineIndex + 1); // Remove the first line
                }
            }

            List<char> delimiters = new List<char> { ',', '\n' };
            // Add custom multi-character delimiters
            if (customDelimiters.Count > 0)
            {
                foreach (var delimiter in customDelimiters)
                {
                    input = input.Replace(delimiter, ","); // Replace custom delimiter with a comma
                }
            }


            // 3. Two numbers (comma separated) return the sum
            // 4. Two numbers (newline separated) return the sum
            // 5. Three numbers (comma or newline separated) return the sum

            string[] numbers = input.Split(delimiters.ToArray());
            int sum = 0;
            List<int> negativeNumbers = new List<int>();


            foreach (string num in numbers)
            {
                if (int.TryParse(num, out int value))
                {
                    if(value < 0)
                    {
                        negativeNumbers.Add(value);
                    }
                    else if(value <= 2000)
                    {
                        sum += value;
                    }
                }
            }

            if (negativeNumbers.Count > 0)
            {
                throw new ArgumentException($"Negative numbers not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return sum;

            
        }
    }
}
