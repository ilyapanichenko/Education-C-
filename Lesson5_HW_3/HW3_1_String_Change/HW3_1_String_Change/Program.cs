namespace HW3_1_String_Change;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Вас приветствует программа, которая заменяет в строке файла все вхождения 'test' на 'testing' и удаляет из текста цифры");
        Console.WriteLine("Текст сохранен в файле 'text.txt'");

        string inputPath = "../../../text.txt";
        string resultPath = "../../../result.txt";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Файл text.txt не найден.");
            return;
        }

        string inputStr = File.ReadAllText(inputPath);

        Console.WriteLine($"Текст в файле: {inputStr}");

        inputStr = inputStr.Replace("test", "testing");

        Console.WriteLine($"Текст после замены: {inputStr}");

        string stringResult = "";

        foreach (char symbol in inputStr)
        {
            if (!char.IsDigit(symbol))
            {
                stringResult += symbol;
            }
        }

        Console.WriteLine($"Текст после удаления цифр: {stringResult}");

        File.WriteAllText(resultPath, stringResult);

        Console.WriteLine("Результат сохранен в новый файл 'result.txt'");
    }
}