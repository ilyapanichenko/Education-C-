using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using HW_11_1.Tests.Hooks;
using HW_11_1.Tests.TestData;

namespace HW_11_1.Tests.Assertions;

[AllureEpic("Calculator")]
[AllureFeature("Arithmetic Operations")]
[AllureSuite("Complex Assertions")]
[Parallelizable(ParallelScope.Children)]
public class ComplexAssertionsTests : BaseTest
{
    [AllureDescription("Checks the addition result and verifies that it is positive and non-zero.")]
    [TestCaseSource(typeof(CalculatorTestCases), nameof(CalculatorTestCases.AddCases))]
    public void AddTest(int a, int b, int expected)
    {
        AllureApi.SetTestName($"Addition with multiple assertions: {a} + {b} = {expected}");
        Logger.Debug($"[DATA] Add: a={a}, b={b}, expected={expected}");

        var result = AllureApi.Step($"Add {a} and {b}", () => Calculator.Add(a, b));

        Logger.Debug($"[RESULT] Add: actual={result}, expected={expected}");

        AllureApi.Step("Verify addition result", () =>
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.EqualTo(expected));
                Assert.That(result, Is.Positive);
                Assert.That(result, Is.Not.Zero);
            }
        });
    }

    [AllureDescription("Checks that Calculator.Subtract returns the expected result.")]
    [TestCaseSource(typeof(CalculatorTestCases), nameof(CalculatorTestCases.SubtractCases))]
    public void SubtractTest(int a, int b, int expected)
    {
        AllureApi.SetTestName($"Subtraction: {a} - {b} = {expected}");
        Logger.Debug($"[DATA] Subtract: a={a}, b={b}, expected={expected}");

        var result = AllureApi.Step($"Subtract {b} from {a}", () => Calculator.Subtract(a, b));

        Logger.Debug($"[RESULT] Subtract: actual={result}, expected={expected}");
        AllureApi.Step($"Verify result equals {expected}", () => Assert.That(result, Is.EqualTo(expected)));
    }

    [AllureDescription("Checks the multiplication result and verifies that it is positive.")]
    [TestCaseSource(typeof(CalculatorTestCases), nameof(CalculatorTestCases.MultiplyCases))]
    public void MultiplyTest(int a, int b, int expected)
    {
        AllureApi.SetTestName($"Multiplication with multiple assertions: {a} * {b} = {expected}");
        Logger.Debug($"[DATA] Multiply: a={a}, b={b}, expected={expected}");

        var result = AllureApi.Step($"Multiply {a} by {b}", () => Calculator.Multiply(a, b));

        Logger.Debug($"[RESULT] Multiply: actual={result}, expected={expected}");

        AllureApi.Step("Verify multiplication result", () =>
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.EqualTo(expected));
                Assert.That(result, Is.Positive);
            }
        });
    }

    [AllureDescription("Checks the division result within tolerance and verifies that it is positive.")]
    [TestCaseSource(typeof(CalculatorTestCases), nameof(CalculatorTestCases.DivideCases))]
    public void DivideTest(double a, double b, double expected)
    {
        AllureApi.SetTestName($"Division with multiple assertions: {a} / {b} = {expected}");
        Logger.Debug($"[DATA] Divide: a={a}, b={b}, expected={expected}");

        var result = AllureApi.Step($"Divide {a} by {b}", () => Calculator.Divide(a, b));

        Logger.Debug($"[RESULT] Divide: actual={result}, expected={expected}");

        AllureApi.Step("Verify division result", () =>
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.EqualTo(expected).Within(0.000001));
                Assert.That(result, Is.Positive);
            }
        });
    }

    [AllureName("Calculation summary")]
    [AllureDescription("Checks the format and result of the calculation summary.")]
    [Test]
    public void CalculationSummaryTest()
    {
        const int a = 5;
        const int b = 8;

        Logger.Debug($"[DATA] CalculationSummary: a={a}, b={b}");

        var result = AllureApi.Step($"Generate calculation summary for {a} and {b}", () => Calculator.GetCalculationSummary(a, b));

        Logger.Debug($"[RESULT] CalculationSummary: actual=\"{result}\"");

        AllureApi.Step("Verify calculation summary", () =>
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.StartWith("5"));
                Assert.That(result, Does.Contain("+"));
                Assert.That(result, Does.EndWith("13"));
            }
        });
    }

    [AllureName("Basic calculation results")]
    [AllureDescription("Checks the number, contents and order of basic calculator results.")]
    [Test]
    public void BasicResultsTest()
    {
        const int a = 5;
        const int b = 2;

        Logger.Debug($"[DATA] BasicResults: a={a}, b={b}");

        var result = AllureApi.Step($"Get basic results for {a} and {b}", () => Calculator.GetBasicResults(a, b));

        Logger.Debug($"[RESULT] BasicResults: actual=[{string.Join(", ", result)}]");

        AllureApi.Step("Verify basic results", () =>
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Has.Count.EqualTo(3));
                Assert.That(result, Does.Contain(7));
                Assert.That(result, Is.EqualTo(new[] { 7, 3, 10 }));
            }
        });
    }

    [AllureName("Division by zero")]
    [AllureDescription("Checks that division by zero throws DivideByZeroException.")]
    [Test]
    public void DivideByZeroTest()
    {
        const double a = 10;
        const double b = 0;

        Logger.Debug($"[DATA] DivideByZero: a={a}, b={b}, expectedException={nameof(DivideByZeroException)}");

        var exception = AllureApi.Step($"Divide {a} by zero and verify exception", () => Assert.Throws<DivideByZeroException>(() => Calculator.Divide(a, b)));

        Logger.Debug($"[RESULT] DivideByZero: exception={exception.GetType().Name}, message=\"{exception.Message}\"");
    }
}