namespace HW5_1_Calculator_With_Ex;

public static class Calculator
{
    public static double Calculate(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
        {
            throw new ArgumentException("Пустая строка");
        }

        var parts = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 3)
        {
            throw new FormatException("Строка должна содержать 3 аргумента");
        }

        double left = double.Parse(parts[0]);
        double right = double.Parse(parts[2]);
        string operation = parts[1];
        if (operation == "/" && right == 0)
        {
            throw new DivideByZeroException("Деление на ноль запрещено");
        }

        double result;
        switch (operation)
        {
            case "+":
                result = left + right;
                break;
            case "-":
                result = left - right;
                break;
            case "*":
                result = left * right;
                break;
            case "/":
                result = left / right;
                break;
            default:
                throw new NotSupportedException("Неизвестная операция");
        }

        if (double.IsInfinity(result))
        {
            throw new OverflowException("Слишком большое число");
        }

        if (double.IsNaN(result))
        {
            throw new CalculationException("Ошибка вычисления");
        }

        return result;
    }
}