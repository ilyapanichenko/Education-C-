namespace HW5_2_UserValidator;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Вас приветствует UserValidator, который проверяет корректность email и пароля");
        while (true)
        {
            Console.WriteLine("Введите email");
            string email = Console.ReadLine();

            try
            {
                UserValidator.ValidateEmail(email);
                Console.WriteLine("Email корректный");
                break;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        while (true)
        {
            Console.WriteLine("Введите password");
            string password = Console.ReadLine();

            try
            {
                UserValidator.ValidatePassword(password);
                Console.WriteLine("Password корректный");
                break;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (WeakPasswordException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}