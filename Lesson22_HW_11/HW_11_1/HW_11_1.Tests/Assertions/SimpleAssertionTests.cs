using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using HW_11_1.Tests.Hooks;

namespace HW_11_1.Tests.Assertions;

[AllureEpic("Calculator")]
[AllureFeature("Arithmetic Operations")]
[AllureSuite("Simple Assertions")]
[Parallelizable(ParallelScope.Children)]
public class SimpleAssertionTests : BaseTest
{
    [AllureDescription("Checks that Calculator.Add returns the expected result.")]
    [TestCase(1, 2, 3)]
    [TestCase(-1, 4, 3)]
    [TestCase(5, -2, 3)]
    public void AddTest(int a, int b, int expected)
    {
        AllureApi.SetTestName($"Addition: {a} + {b} = {expected}");
        Logger.Debug($"[DATA] Add: a={a}, b={b}, expected={expected}");

        var result = AllureApi.Step($"Add {a} and {b}", () => Calculator.Add(a, b));

        Logger.Debug($"[RESULT] Add: actual={result}, expected={expected}");
        AllureApi.Step($"Verify result equals {expected}", () => Assert.That(result, Is.EqualTo(expected)));
    }

    [AllureDescription("Checks that Calculator.Subtract returns the expected result.")]
    [TestCase(1, 2, -1)]
    [TestCase(-1, 4, -5)]
    [TestCase(5, -2, 7)]
    public void SubtractTest(int a, int b, int expected)
    {
        AllureApi.SetTestName($"Subtraction: {a} - {b} = {expected}");
        Logger.Debug($"[DATA] Subtract: a={a}, b={b}, expected={expected}");

        var result = AllureApi.Step($"Subtract {b} from {a}", () => Calculator.Subtract(a, b));

        Logger.Debug($"[RESULT] Subtract: actual={result}, expected={expected}");
        AllureApi.Step($"Verify result equals {expected}", () => Assert.That(result, Is.EqualTo(expected)));
    }

    [AllureDescription("Checks that Calculator.Multiply returns the expected result.")]
    [TestCase(1, 2, 2)]
    [TestCase(-1, 4, -4)]
    [TestCase(5, -2, -10)]
    public void MultiplyTest(int a, int b, int expected)
    {
        AllureApi.SetTestName($"Multiplication: {a} * {b} = {expected}");
        Logger.Debug($"[DATA] Multiply: a={a}, b={b}, expected={expected}");

        var result = AllureApi.Step($"Multiply {a} by {b}", () => Calculator.Multiply(a, b));

        Logger.Debug($"[RESULT] Multiply: actual={result}, expected={expected}");
        AllureApi.Step($"Verify result equals {expected}", () => Assert.That(result, Is.EqualTo(expected)));
    }

    [AllureDescription("Checks that Calculator.Divide returns the expected result within the allowed tolerance.")]
    [TestCase(1, 2, 0.5)]
    [TestCase(-1, 4, -0.25)]
    [TestCase(5, -2, -2.5)]
    public void DivideTest(double a, double b, double expected)
    {
        AllureApi.SetTestName($"Division: {a} / {b} = {expected}");
        Logger.Debug($"[DATA] Divide: a={a}, b={b}, expected={expected}");

        var result = AllureApi.Step($"Divide {a} by {b}", () => Calculator.Divide(a, b));

        Logger.Debug($"[RESULT] Divide: actual={result}, expected={expected}");
        AllureApi.Step($"Verify result equals {expected}", () => Assert.That(result, Is.EqualTo(expected).Within(0.000001)));
    }
}