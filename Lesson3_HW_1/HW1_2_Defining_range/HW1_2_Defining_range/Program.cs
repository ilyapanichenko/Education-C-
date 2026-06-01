using System.Text;

namespace HW1_2_Defining_range;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Вас приветствует \"Определятор диапазона\" v1");
        int value;
        while (true)
        {
            Console.WriteLine("Введите число от 0 до 100:");
            var input = Console.ReadLine();
            var isNumber = int.TryParse(input, out value);
            if (!isNumber)
            {
                Console.WriteLine("Вы ввели не число! Попробуйте снова:");
                continue;
            }

            if (value < 0 || value > 100)
            {
                Console.WriteLine("Ошибка! Число не входит ни в один из имеющихся промежутков.");
                continue;
            }

            if (value <= 14)
                Console.WriteLine($"Число {value} попадает в числовой промежуток [0 - 14]");
            else if (value <= 35)
                Console.WriteLine($"Число {value} попадает в числовой промежуток [15 - 35]");
            else if (value <= 50)
                Console.WriteLine($"Число {value} попадает в числовой промежуток [36 - 50]");
            else
                Console.WriteLine($"Число {value} попадает в числовой промежуток [51 - 100]");
            break;
        }
    }
}