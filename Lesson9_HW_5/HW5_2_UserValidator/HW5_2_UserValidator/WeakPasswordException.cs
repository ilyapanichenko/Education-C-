namespace HW5_2_UserValidator;

[Serializable]
public class WeakPasswordException : Exception
{
    public WeakPasswordException(string message) : base(message)
    {
    }
}