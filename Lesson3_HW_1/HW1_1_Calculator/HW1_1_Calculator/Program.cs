using System.Text;

namespace HW1_1_Calculator;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var rnd = new Random();
        var operand1 = rnd.Next(0, 1000);
        var operand2 = rnd.Next(0, 1000);
        Console.WriteLine("Вас приветствует \"Калькулятор v1\"!");
        Console.WriteLine(
            "Позволяет производить арифметическое действия\nс двумя случайными целыми переменными в диапазоне от 0 до 1000");
        Console.WriteLine($"Первая рандомная переменная: {operand1}");
        Console.WriteLine($"Вторая рандомная переменная: {operand2}");
        string sign;
        do
        {
            Console.WriteLine("Выберите действие (+, -, /, *):");
            sign = Console.ReadLine().Trim();
            if (sign != "-" && sign != "+" && sign != "*" && sign != "/")
                Console.WriteLine("Ошибка: введено неверное действие. Попробуйте снова.");
            else
                switch (sign)
                {
                    case "+":
                    {
                        Console.Write($"Результат сложения: {operand1 + operand2}");
                        break;
                    }
                    case "-":
                    {
                        Console.WriteLine($"Результат вычитания: {operand1 - operand2}");
                        break;
                    }
                    case "*":
                    {
                        Console.WriteLine($"Результат умножения: {operand1 * operand2}");
                        break;
                    }
                    case "/":
                    {
                        if (operand2 == 0)
                            Console.WriteLine("Ошибка! На ноль делить нельзя.");
                        else
                            Console.WriteLine($"Результат деления: {(double)operand1 / operand2}");

                        break;
                    }
                }
        } while (sign != "-" && sign != "+" && sign != "*" && sign != "/");
    }
}