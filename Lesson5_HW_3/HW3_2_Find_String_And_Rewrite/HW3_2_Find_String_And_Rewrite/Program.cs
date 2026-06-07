namespace HW3_2_Find_String_And_Rewrite;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string inputPath = "../../../text.txt";
        string resultLeftStrPath = "../../../leftStr.txt";
        string resultRightStrPath = "../../../rightStr.txt";

        string searchText = "abc";

        Console.WriteLine(
            "Вас приветствует программа, которая находит в строке файла 'text.txt' текст 'abc' и записывает в разные переменные первую часть и вторую часть строки");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Ошибка! Файл 'text.txt' отсутствует!");
            return;
        }

        string input = File.ReadAllText(inputPath);

        int index = input.IndexOf(searchText);

        if (index == -1)
        {
            Console.WriteLine("Ошибка! Строка не содержит 'abc'!");
            return;
        }

        string leftStr = input.Substring(0, index);
        string rightStr = input.Substring(index + searchText.Length);

        Console.WriteLine($"Часть строки до 'abc': {leftStr}");
        Console.WriteLine($"Часть строки после 'abc': {rightStr}");

        File.WriteAllText(resultLeftStrPath, leftStr);
        File.WriteAllText(resultRightStrPath, rightStr);

        Console.WriteLine($"Часть строки до 'abc' записана в файл {resultLeftStrPath}");
        Console.WriteLine($"Часть строки после 'abc' записана в файл {resultRightStrPath}");
    }
}