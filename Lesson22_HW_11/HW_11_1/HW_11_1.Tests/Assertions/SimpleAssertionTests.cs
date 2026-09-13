using HW_11_1.Tests.Hooks;

namespace HW_11_1.Tests.Assertions;

[Parallelizable(ParallelScope.Children)]
public class SimpleAssertionTests : BaseTest
{
    [TestCase(1, 2, 3)]
    [TestCase(-1, 4, 3)]
    [TestCase(5, -2, 3)]
    public void AddTest(int a, int b, int expected)
    {
        var result = Calculator.Add(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1, 2, -1)]
    [TestCase(-1, 4, -5)]
    [TestCase(5, -2, 7)]
    public void SubtractTest(int a, int b, int expected)
    {
        var result = Calculator.Subtract(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1, 2, 2)]
    [TestCase(-1, 4, -4)]
    [TestCase(5, -2, -10)]
    public void MultiplyTest(int a, int b, int expected)
    {
        var result = Calculator.Multiply(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(1, 2, 0.5)]
    [TestCase(-1, 4, -0.25)]
    [TestCase(5, -2, -2.5)]
    public void DivideTest(double a, double b, double expected)
    {
        var result = Calculator.Divide(a, b);

        Assert.That(result, Is.EqualTo(expected).Within(0.000001));
    }
}