namespace HW2_1_Array;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Random random = new Random();

        const int minValue = 1;
        const int maxValue = 50;

        int input;
        int size = random.Next(minValue, maxValue + 1);
        int[] array = new int[size];

        Console.WriteLine("Вас приветствует \"Создатель случайного массива целых чисел\"!");
        Console.WriteLine("Случайный массив целых чисел:");

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }

        Console.WriteLine();

        while (true)
        {
            Console.WriteLine($"Введите число от {minValue} до {maxValue} для поиска его в массиве:");

            string value = Console.ReadLine();
            bool isNumber = int.TryParse(value, out input);

            if (!isNumber)
            {
                Console.WriteLine("Вы ввели не число! Попробуйте снова.");
                continue;
            }

            if (input < minValue || input > maxValue)
            {
                Console.WriteLine($"Число {input} выходит за рамки числового диапазона массива.");
                continue;
            }

            int occurrencesCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == input)
                {
                    occurrencesCount++;
                }
            }

            if (occurrencesCount > 0)
            {
                Console.WriteLine($"Число {input} входит в массив и встречается {occurrencesCount} раз.");
            }
            else
            {
                Console.WriteLine($"Число {input} не входит в массив.");
            }

            break;
        }
    }
}