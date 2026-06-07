namespace HW2_2_Array_del_number;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Вас приветствует \"Создатель случайного массива целых чисел\"!");
        Console.WriteLine("Случайный массив целых чисел:");
        Random random = new Random();
        var minValue = 1;
        var maxValue = 50;
        var value = 0;
        int [] array = CreateArray(random, minValue, maxValue);
        PrintArray(array);
        Console.WriteLine();
        while (true)
        {
            Console.WriteLine($"Введите число, которое необходимо удалить из массива от {minValue} до {maxValue}!:");
            var input = Console.ReadLine();
            var isNumber = int.TryParse(input, out value);
            if (!isNumber)
            {
                Console.WriteLine($"Ошибка! Введите число от {minValue} до {maxValue}:");
                continue;
            }

            if (value < minValue || value > maxValue)
            {
                Console.WriteLine($"Число не входит в диапазон от {minValue} до {maxValue}! ");
                continue;
            }
            int count = CountOccurrences(array, value);
            if (count == 0)
            {
                Console.WriteLine($"В массиве нет числа {value}");
                Console.WriteLine("Массив остался без изменений:");
                PrintArray(array);
                break;
            }
            else
            {
                int[] newArray = CreateArrayWithoutValue(array, value, count);
                Console.WriteLine($"Количество удалений: {count}");
                Console.WriteLine($"Новый массив без введенного числа {value}:");
                PrintArray(newArray);
                break;
            }
        }
    }

    static int [] CreateArray(Random random, int minValue, int maxValue)
    {
        int size = random.Next(minValue, maxValue + 1);
        int[] array = new int [size];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
        }
        return array;
    }

    static int[] CreateArrayWithoutValue(int [] array, int value, int count)
    {
        int newArrayIndex = 0;
        int [] newArray = new int [array.Length-count];
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != value)
            {
                newArray[newArrayIndex] = array[i];
                newArrayIndex++;
            }
        }
        return newArray;
    }
    static int CountOccurrences(int[] array, int value)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                count ++;
            }
        }
        return count;
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