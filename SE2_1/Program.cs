using SE2_1;
using System;
using System.Diagnostics;


public class Program
{
    public static void Main()
    {
        CalcTests tests = new CalcTests();
        try
        {
            tests.Process_EmptyString_ReturnsZero();
            tests.Process_SingleNumber_ReturnsTheValue();
            tests.Process_TwoNumbersCommaDelimited_ReturnsSum();
            tests.Process_TwoNumbersNewlineDelimited_ReturnsSum();
            tests.Process_ThreeNumbersDelimited_ReturnsSum();
            tests.Process_NegativeNumbers_ThrowsException();
            tests.Process_NumberGreaterThan2000_IsIgnored();
            tests.Process_SingleCharacterDelimiter_ReturnsSum();
            tests.Process_MultiCharacterDelimiter_ReturnsSum();
            tests.Process_ManyDelimiters_ReturnsSum();
            tests.Process_IgnoreNumbersGreaterThan2000WithDelimiters();

            Console.WriteLine("All tests passed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Test failed: {ex.Message}");
        }
    }
}


