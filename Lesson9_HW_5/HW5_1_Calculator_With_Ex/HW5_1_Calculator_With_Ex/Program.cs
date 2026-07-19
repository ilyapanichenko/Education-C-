using System.Security.Cryptography.X509Certificates;

namespace HW5_1_Calculator_With_Ex;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Вас приветствует калькулятор!");
        while (true)
        {
            Console.WriteLine("введите выражение вида: 5 + 3, 10 / 2, 7 * 4, 15 - 8");
            string expression = Console.ReadLine();
            try
            {
                double result = Calculator.Calculate(expression);
                Console.WriteLine($"Результат выражения: {result}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Пустая строка");
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Неизвестная операция");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на ноль запрещено");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Слишком большое число");
            }
            catch (CalculationException)
            {
                Console.WriteLine("Ошибка вычисления");
            }
            Console.WriteLine("Нажмите End для завершения или любую клавишу для продолжения");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.End) break;
        }
    }
}