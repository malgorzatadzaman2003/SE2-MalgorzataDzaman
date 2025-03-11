using SE2_1;
using System;
using System.Diagnostics;


public class Program
{
    public static void Main()
    {
        CalcTests tests = new CalcTests();
        int passedTests = 0;
        int totalTests = 11;

        void RunTest(Action testMethod, string testName)
        {
            try
            {
                testMethod();
                Console.WriteLine($"+ {testName} passed.");
                passedTests++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"- {testName} failed: {ex.Message}");
            }
        }

        RunTest(tests.Process_EmptyString_ReturnsZero, "Process_EmptyString_ReturnsZero");
        RunTest(tests.Process_SingleNumber_ReturnsTheValue, "Process_SingleNumber_ReturnsTheValue");
        RunTest(tests.Process_TwoNumbersCommaDelimited_ReturnsSum, "Process_TwoNumbersCommaDelimited_ReturnsSum");
        RunTest(tests.Process_TwoNumbersNewlineDelimited_ReturnsSum, "Process_TwoNumbersNewlineDelimited_ReturnsSum");
        RunTest(tests.Process_ThreeNumbersDelimited_ReturnsSum, "Process_ThreeNumbersDelimited_ReturnsSum");
        RunTest(tests.Process_NegativeNumbers_ThrowsException, "Process_NegativeNumbers_ThrowsException");
        RunTest(tests.Process_NumberGreaterThan2000_IsIgnored, "Process_NumberGreaterThan2000_IsIgnored");
        RunTest(tests.Process_SingleCharacterDelimiter_ReturnsSum, "Process_SingleCharacterDelimiter_ReturnsSum");
        RunTest(tests.Process_MultiCharacterDelimiter_ReturnsSum, "Process_MultiCharacterDelimiter_ReturnsSum");
        RunTest(tests.Process_ManyDelimiters_ReturnsSum, "Process_ManyDelimiters_ReturnsSum");
        RunTest(tests.Process_IgnoreNumbersGreaterThan2000WithDelimiters, "Process_IgnoreNumbersGreaterThan2000WithDelimiters");

        Console.WriteLine($"\nTest summary: {passedTests}/{totalTests} tests passed.");
    }
}


