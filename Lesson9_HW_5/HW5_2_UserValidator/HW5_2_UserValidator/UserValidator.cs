namespace HW5_2_UserValidator;

public static class UserValidator
{
    public static bool ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Пустое значение");
        }

        if (email.Length <= 5)
        {
            throw new FormatException("Email должен быть длиннее 5 символов");
        }

        if (email.Contains(" "))
        {
            throw new FormatException("Email не может содержать пробел");
        }

        int atIndex = email.IndexOf('@');

        if (atIndex == -1)
        {
            throw new FormatException("Email должен содержать '@'");
        }

        if (email.IndexOf('@', atIndex + 1) != -1)
        {
            throw new FormatException("Email не может содержать несколько '@'");
        }

        int dotAfterAtIndex = email.IndexOf('.', atIndex + 1);

        if (dotAfterAtIndex == -1)
        {
            throw new FormatException("Email должен содержать '.' после '@'");
        }

        return true;
    }

    public static bool ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Пустое значение");
        }

        if (password.Length < 8)
        {
            throw new WeakPasswordException("Пароль должен содержать минимум 8 символов");
        }

        bool hasUpper = false;
        bool hasDigit = false;
        bool hasSpecialSymbol = false;

        string specialSymbols = "!@#$%^&*";

        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                hasUpper = true;
            }

            if (char.IsDigit(c))
            {
                hasDigit = true;
            }

            if (specialSymbols.Contains(c))
            {
                hasSpecialSymbol = true;
            }
        }

        if (!hasUpper)
        {
            throw new WeakPasswordException("Пароль должен содержать хотя бы одну заглавную букву");
        }

        if (!hasDigit)
        {
            throw new WeakPasswordException("Пароль должен содержать хотя бы одну цифру");
        }

        if (!hasSpecialSymbol)
        {
            throw new WeakPasswordException("Пароль должен содержать хотя бы один специальный символ: !@#$%^&*");
        }

        return true;
    }
}