using System.Text;

namespace HW1_3_Translator;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Вас приветствует \"Русско-английский переводчик\"");
        Console.WriteLine("Программа знает 10 слов:");
        Console.WriteLine("Ветрено;");
        Console.WriteLine("Жарко;");
        Console.WriteLine("Холодно;");
        Console.WriteLine("Солнечно;");
        Console.WriteLine("Дождь;");
        Console.WriteLine("Снег;");
        Console.WriteLine("Град;");
        Console.WriteLine("Душно;");
        Console.WriteLine("Ураган;");
        Console.WriteLine("Засуха");
        while (true)
        {
            Console.WriteLine("Введите слово, перевод которого необходим:");
            var input = Console.ReadLine().Trim().ToLower();
            switch (input)
            {
                case "ветрено":
                {
                    Console.WriteLine($"{input} = Windy");
                    break;
                }

                case "жарко":
                {
                    Console.WriteLine($"{input} = Hot");
                    break;
                }

                case "холодно":
                {
                    Console.WriteLine($"{input} = Cold");
                    break;
                }

                case "солнечно":
                {
                    Console.WriteLine($"{input} = Sunny");
                    break;
                }

                case "дождь":
                {
                    Console.WriteLine($"{input} = Rain");
                    break;
                }

                case "снег":
                {
                    Console.WriteLine($"{input} = Snow");
                    break;
                }

                case "град":
                {
                    Console.WriteLine($"{input} = Hail");
                    break;
                }

                case "душно":
                {
                    Console.WriteLine($"{input} = Stuffy");
                    break;
                }

                case "ураган":
                {
                    Console.WriteLine($"{input} = Hurricane");
                    break;
                }

                case "засуха":
                {
                    Console.WriteLine($"{input} = Drought");
                    break;
                }

                default:
                {
                    Console.WriteLine("Такого слова нет.");
                    break;
                }
            }

            Console.WriteLine("Для выхода из программы нажмите End, для продолжения переводов любую клавишу.");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.End) break;
        }
    }
}