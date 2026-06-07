using System.Text;

namespace HW3_4_Doc_Number;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string resultPath = "../../../result_text.txt";
        string inputPath = "../../../text.txt";
        Console.WriteLine("Вас приветствует программа, которая манипулирует с номером документа из файла 'text.txt'");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Ошибка! Файл 'text.txt' отсутствует!");
            return;
        }
        string text = File.ReadAllText(inputPath);
        Console.WriteLine($"Номер документа: {text}");
        string[] parts = text.Split('-');
        if (parts.Length != 5)
        {
            Console.WriteLine("Ошибка! Неверный формат номера документа.");
            return;
        }
        Console.WriteLine($"Два первых блока по 4 цифры: {parts[0] + parts[2]}");
        Console.WriteLine($"Замена первых 2 блока на ***: {parts[0] + "-***-" + parts[2] + "-***-" + parts[4]}");
        Console.Write("Одни буквы из номера документа в формате yyy/yyy/y/y: ");
        string letters = (parts[1] + "/" + parts[3] + "/" + parts[4][1] + "/" + parts[4][3]).ToLower();
        Console.WriteLine(letters);
        StringBuilder sb =  new StringBuilder();
        sb.Append("Letters:");
        sb.Append(parts[1]);
        sb.Append("/");
        sb.Append(parts[3]);
        sb.Append("/");
        sb.Append(parts[4][1]);
        sb.Append("/");
        sb.Append(parts[4][3]);
        Console.WriteLine($"Одни буквы из номера документа в формате yyy/yyy/y/y, реализация через ToString: {sb.ToString().ToUpper()}");
        bool containsAbc = text.Contains("abc", StringComparison.OrdinalIgnoreCase);
        Console.WriteLine(containsAbc ? "Документ содержит abc" : "Документ не содержит abc");
        bool contains555 = text.StartsWith("555");
        Console.WriteLine(contains555 ? "Документ начинается с 555" : "Документ не начинается с 555");
        
        StringBuilder sb2 = new StringBuilder();
        sb2.AppendLine($"Два первых блока по 4 цифры: {parts[0] + parts[2]}");
        sb2.AppendLine($"Замена первых 2 блока на ***: {parts[0] + "-***-" + parts[2] + "-***-" + parts[4]}");
        sb2.Append("Одни буквы из номера документа в формате yyy/yyy/y/y: ");
        sb2.AppendLine(letters);
        sb2.AppendLine($"Одни буквы из номера документа в формате yyy/yyy/y/y, реализация через ToString: {sb.ToString().ToUpper()}");
        sb2.AppendLine(containsAbc ? "Документ содержит abc" : "Документ не содержит abc");
        sb2.AppendLine(contains555 ? "Документ начинается с 555" : "Документ не начинается с 555");
        File.WriteAllText(resultPath, sb2.ToString());
        Console.WriteLine($"Результат записан в файл 'result_text.txt'");
    }
}