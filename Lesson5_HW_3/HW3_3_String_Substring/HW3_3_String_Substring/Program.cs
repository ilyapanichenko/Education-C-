namespace HW3_3_String_Substring;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string inputPath = "../../../text.txt";
        string resultPath = "../../../replace_text.txt";

        string findStr = "Плохой";
        string insertStr = "Хороший";
        string signs = "!!!!!!!!!";

        Console.WriteLine("Вас приветствует программа, которая заменяет подстроку 'Плохой день' на 'Хороший день!!!!!!!!!' и заменяет последний ! на ?");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Ошибка! Файл 'text.txt' отсутствует!");
            return;
        }

        string text = File.ReadAllText(inputPath);

        Console.WriteLine($"Исходный текст: {text}");

        int index = text.IndexOf(findStr, StringComparison.OrdinalIgnoreCase);
        if (index == -1)
        {
            Console.WriteLine($"Ошибка! В тексте нет слова '{findStr}'.");
            return;
        }

        string leftPart = text.Substring(0, index);
        string rightPart = text.Substring(index + findStr.Length);

        string textWithoutBadWord = leftPart + rightPart;

        string result = textWithoutBadWord.Insert(index, insertStr);

        result = result.TrimEnd('.');

        result += signs;

        int lastSignIndex = result.LastIndexOf("!");

        if (lastSignIndex != -1)
        {
            result = result.Remove(lastSignIndex, 1).Insert(lastSignIndex, "?");
        }

        Console.WriteLine($"Итоговый текст: {result}");

        File.WriteAllText(resultPath, result);

        Console.WriteLine("Результат сохранён в файл 'replace_text.txt'");
    }
}