namespace HW2_5_Array_Diagoale;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var minRangeValue = 0;
        var maxRangeValue = 100;
        var minArraySize = 1;
        var maxArraySize = 100;
        Random random = new Random();
        while (true)
        {
            Console.WriteLine("Введите размер двумерного массива от 1 до 100:");
            var isNumberI = int.TryParse(Console.ReadLine(), out int arraySize);
            if (!isNumberI)
            {
                Console.WriteLine($"Ошибка ввода! Введите число в диапазоне от {minArraySize} до {maxArraySize} :");
                continue;
            }

            if (arraySize < minArraySize || arraySize > maxArraySize)
            {
                Console.WriteLine(
                    $"Вы ввели некорректное число! Введите число в диапазоне от {minArraySize} до {maxArraySize} :");
                continue;
            }

            var array = CreateArray(arraySize, minRangeValue, maxRangeValue);
            Console.WriteLine("Двумерный массив:");
            PrintArray(array);
            PrintArrayMainDiagonal(array);
            PrintArraySecondaryDiagonal(array);
            Console.WriteLine("Для завершения нажмите End, для продолжения нажмите любую кнопку");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.End)
            {
                break;
            }
        }

        int[,] CreateArray(int arraySize, int minRange, int maxRange)
        {
            int[,] array = new int[arraySize, arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    array[i, j] = random.Next(minRange, maxRange);
                }
            }

            return array;
        }

        void PrintArrayMainDiagonal(int[,] array)
        {
            Console.WriteLine("Главная диагональ:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[i, i] + " ");
            }

            Console.WriteLine();
        }

        void PrintArraySecondaryDiagonal(int[,] array)
        {
            Console.WriteLine("Побочная диагональ:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[i, array.GetLength(0) - 1 - i] + " ");
            }

            Console.WriteLine();
        }

        void PrintArray(int[,] array)
        {
            const int cellWidth = 3;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j],cellWidth}");
                }
                Console.WriteLine();
            }
        }
    }
}