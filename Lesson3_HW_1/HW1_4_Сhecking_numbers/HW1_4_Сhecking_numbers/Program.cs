namespace HW1_4_Сhecking_numbers;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Вас приветствует программа для проверки чисел на четность двумя разными методами");
        int inputValue;
        while (true)
        {
            Console.WriteLine("Введите целое число для проверки:");
            var inputStr = Console.ReadLine();
            var isNumber = int.TryParse(inputStr, out inputValue);
            if (!isNumber)
            {
                Console.WriteLine("Ошибка ввода, необходимо ввести целое число!");
                continue;
            }

            Console.WriteLine(inputValue % 2 == 0
                ? $"Метод 1: {inputValue} - четное число"
                : $"Метод 1: {inputValue} - нечетное число");
            Console.WriteLine((inputValue & 1) == 0
                ? $"Метод 2: {inputValue} - четное число"
                : $"Метод 2: {inputValue} - нечетное число");

            Console.WriteLine("Нажмите End для завершения или любую клавишу для продолжения");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.End) break;
        }
    }
}