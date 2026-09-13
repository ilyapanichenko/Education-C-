using NUnit.Framework;

namespace HW_11_1.Tests.TestData;

public static class CalculatorTestCases
{
    public static IEnumerable<TestCaseData> AddCases()
    {
        yield return new TestCaseData(1, 2, 3);
        yield return new TestCaseData(5, 5, 10);
        yield return new TestCaseData(10, 2, 12);
    }

    public static IEnumerable<TestCaseData> SubtractCases()
    {
        yield return new TestCaseData(1, 2, -1);
        yield return new TestCaseData(-2, -3, 1);
        yield return new TestCaseData(-5, -6, 1);
    }

    public static IEnumerable<TestCaseData> MultiplyCases()
    {
        yield return new TestCaseData(1, 2, 2);
        yield return new TestCaseData(-2, -3, 6);
        yield return new TestCaseData(-5, -6, 30);
    }

    public static IEnumerable<TestCaseData> DivideCases()
    {
        yield return new TestCaseData(10.0, 2.0, 5.0);
        yield return new TestCaseData(9.0, 3.0, 3.0);
        yield return new TestCaseData(5.0, 2.0, 2.5);
    }
}