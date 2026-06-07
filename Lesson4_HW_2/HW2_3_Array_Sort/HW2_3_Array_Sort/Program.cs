namespace HW2_3_Array_Sort;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Вас приветствует программа, которая создает массив случайных чисел заданного размера!");
        while (true)
        {
            Console.WriteLine("Введите размер массива:");
            var input = Console.ReadLine();
            var isNumber = int.TryParse(input, out var number);
            int size = number;
            var maxArraySize = 100;
            var minArraySize = 1;
            var minValueRnd = 1;
            var maxValueRnd = 100;
            if (!isNumber)
            {
                Console.WriteLine($"Вы ввели: {input}, ведите число:");
                continue;
            }

            if (size < minArraySize || size > maxArraySize)
            {
                Console.WriteLine(
                    $"Вы ввели неподходящий размер массива. Введите число от {minArraySize} до {maxArraySize}:");
                continue;
            }

            int[] array = CreateNewArray(size, minValueRnd, maxValueRnd);
            Console.WriteLine("Массив:");
            PrintArray(array);
            int[] sortedArray = SortArray(array);
            Console.WriteLine("Отсортированный массив:");
            PrintArray(sortedArray);

            Console.WriteLine($"Минимальное значение в массиве:{sortedArray[0]}");
            Console.WriteLine($"Максимальное значение в массиве:{sortedArray[sortedArray.Length - 1]}");
            if (sortedArray.Length % 2 == 0)
            {
                Console.WriteLine(
                    $"Средние значения в массиве(так как размер массива четный):{sortedArray[sortedArray.Length / 2 - 1]} и {sortedArray[sortedArray.Length / 2]} ");
            }
            else
            {
                Console.WriteLine($"Среднее значение в массиве:{sortedArray[sortedArray.Length / 2]} ");
            }

            Console.WriteLine("Нажмите End для выхода или любую другую клавишу для продолжения.");
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.End)
            {
                break;
            }
        }

        static int[] CreateNewArray(int size, int minValueRnd, int maxValueRnd)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                int value = random.Next(minValueRnd, maxValueRnd);
                array[i] = value;
            }

            return array;
        }

        static int[] SortArray(int[] array)
        {
            Array.Sort(array);
            return array;
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
        }
    }
}