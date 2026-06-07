namespace HW2_4_Array_Sum;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Вас приветствует сумматор всех чисел двумерного массива");
        var minRangeValue = 0;
        var maxRangeValue = 100;
        var minArraySize = 1;
        var maxArraySize = 100;
        Random random = new Random();
        while (true)
        {
            Console.WriteLine("Введите количество строк в двумерном массиве от 1 до 100:");
            var isNumberI = int.TryParse(Console.ReadLine(), out int arraySizeRow);
            if (!isNumberI)
            {
                Console.WriteLine($"Ошибка ввода! Введите число в диапазоне от {minArraySize} до {maxArraySize} :");
                continue;
            }

            if (arraySizeRow < minArraySize || arraySizeRow > maxArraySize)
            {
                Console.WriteLine(
                    $"Вы ввели некорректное число! Введите число в диапазоне от {minArraySize} до {maxArraySize} :");
                continue;
            }

            Console.WriteLine("Введите количество столбцов в двумерном массиве от 1 до 100:");
            var isNumberJ = int.TryParse(Console.ReadLine(), out int arraySizeColumn);
            if (!isNumberJ)
            {
                Console.WriteLine($"Ошибка ввода! Введите число в диапазоне от {minArraySize} до {maxArraySize} :");
                continue;
            }

            if (arraySizeColumn < minArraySize || arraySizeColumn > maxArraySize)
            {
                Console.WriteLine(
                    $"Вы ввели некорректное число! Введите число в диапазоне от {minArraySize} до {maxArraySize} :");
                continue;
            }

            var array = CreateArray(arraySizeRow, arraySizeColumn, minRangeValue, maxRangeValue);
            int sum = GetArraySum(array);
            Console.WriteLine("Двумерный массив:");
            PrintArray(array);
            Console.WriteLine($"Сумма всех чисел в массиве: {sum}");
            Console.WriteLine("Для завершения нажмите End, для продолжения нажмите любую кнопку");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.End)
            {
                break;
            }
        }

        int[,] CreateArray(int arraySizeI, int arraySizeJ, int minRange, int maxRange)
        {
            int[,] array = new int[arraySizeI, arraySizeJ];
            for (int i = 0; i < arraySizeI; i++)
            {
                for (int j = 0; j < arraySizeJ; j++)
                {
                    array[i, j] = random.Next(minRange, maxRange);
                }
            }

            return array;
        }

        int GetArraySum(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
            }

            return sum;
        }

        void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}