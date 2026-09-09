using HW_11_1.Tests.Hooks;
using HW_11_1.Tests.TestData;

namespace HW_11_1.Tests.Assertions;

[Parallelizable(ParallelScope.Children)]
public class ComplexAssertionsTests : BaseTest
{
    [TestCaseSource(typeof(CalculatorTestCases), nameof(CalculatorTestCases.AddCases))]
    public void AddTest(int a, int b, int expected)
    {
        var result = Calculator.Add(a, b);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.Not.Zero);
        }
    }

    [TestCaseSource(typeof(CalculatorTestCases), nameof(CalculatorTestCases.SubtractCases))]
    public void SubtractTest(int a, int b, int expected)
    {
        var result = Calculator.Subtract(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCaseSource(typeof(CalculatorTestCases), nameof(CalculatorTestCases.MultiplyCases))]
    public void MultiplyTest(int a, int b, int expected)
    {
        var result = Calculator.Multiply(a, b);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.Positive);
        }
    }

    [TestCaseSource(typeof(CalculatorTestCases), nameof(CalculatorTestCases.DivideCases))]
    public void DivideTest(double a, double b, double expected)
    {
        var result = Calculator.Divide(a, b);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(
                result,
                Is.EqualTo(expected).Within(0.000001));

            Assert.That(result, Is.Positive);
        }
    }

    [Test]
    public void CalculationSummaryTest()
    {
        var result = Calculator.GetCalculationSummary(5, 8);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Does.StartWith("5"));
            Assert.That(result, Does.Contain("+"));
            Assert.That(result, Does.EndWith("13"));
        }
    }

    [Test]
    public void BasicResultsTest()
    {
        var result = Calculator.GetBasicResults(5, 2);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.EqualTo(new[] { 7, 3, 10 }));
        }
    }

    [Test]
    public void DivideByZeroTest()
    {
        Assert.Throws<DivideByZeroException>(() =>
            Calculator.Divide(10, 0));
    }
}