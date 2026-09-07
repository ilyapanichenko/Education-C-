using HW_11_1.Tests.Hooks;

namespace HW_11_1.Tests.Assertions;

[Parallelizable(ParallelScope.Children)]
public class ComplexAssertionsTests : BaseTest
{
    public static IEnumerable<TestCaseData> TestCasesAdd()
    {
        yield return new TestCaseData(1, 2, 3);
        yield return new TestCaseData(5, 5, 10);
        yield return new TestCaseData(10, 2, 12);
    }

    public static IEnumerable<TestCaseData> TestCasesSubtract()
    {
        yield return new TestCaseData(1, 2, -1);
        yield return new TestCaseData(-2, -3, 1);
        yield return new TestCaseData(-5, -6, 1);
    }

    public static IEnumerable<TestCaseData> TestCasesMultiply()
    {
        yield return new TestCaseData(1, 2, 2);
        yield return new TestCaseData(-2, -3, 6);
        yield return new TestCaseData(-5, -6, 30);
    }

    public static IEnumerable<TestCaseData> TestCasesDivide()
    {
        yield return new TestCaseData(10.0, 2.0, 5.0);
        yield return new TestCaseData(9.0, 3.0, 3.0);
        yield return new TestCaseData(5.0, 2.0, 2.5);
    }
    
    [TestCaseSource(nameof(TestCasesAdd))]
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

    [TestCaseSource(nameof(TestCasesSubtract))]
    public void SubtractTest(int a, int b, int expected)
    {
        var result = Calculator.Subtract(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(TestCasesMultiply))]
    public void MultiplyTest(int a, int b, int expected)
    {
        var result = Calculator.Multiply(a, b);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.Positive);
        }
    }

    [TestCaseSource(nameof(TestCasesDivide))]
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