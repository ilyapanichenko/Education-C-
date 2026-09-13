namespace HW_11_1.Core;
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    public int Subtract(int a, int b)
    {
        return a - b;
    }
    public int Multiply(int a, int b)
    {
        return a * b;
    }
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Division by zero is prohibited.");
        }

        return a / b;
    }
    public string GetCalculationSummary(int a, int b)
    {
        return $"{a} + {b} = {Add(a, b)}";
    }
    public List<int> GetBasicResults(int a, int b)
    {
        return new List<int>
        {
            Add(a, b),
            Subtract(a, b),
            Multiply(a, b)
        };
    }
}