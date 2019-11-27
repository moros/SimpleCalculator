using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SimpleCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var delimitorSpecified = Regex.Match(numbers, @"//.\n");
            var splitNumbers = ExtractNumbers(numbers, !delimitorSpecified.Success ? "," : numbers.Substring(2, 1));

            return splitNumbers.Sum();
        }

        private int[] ExtractNumbers(string input, string delimitor)
        {
            var indexOf = input.IndexOf($"//{delimitor}\n", StringComparison.Ordinal);
            input = indexOf != -1 ? input.Substring(4) : input;

            var hasNewlines = input.IndexOf("\n", StringComparison.Ordinal);
            input = hasNewlines != -1 ? input.Replace("\n", delimitor) : input;

            hasNewlines = input.IndexOf("\\n", StringComparison.Ordinal);
            input = hasNewlines != -1 ? input.Replace("\\n", delimitor) : input;

            var split = input.Split(delimitor);
            return split
                .Where(item => !string.IsNullOrEmpty(item))
                .Select(item => Convert.ToInt32(item))
                .ToArray();
        }
    }
}
