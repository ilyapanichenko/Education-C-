namespace HW5_1_Calculator_With_Ex;

[Serializable]
public class CalculationException : Exception
{
    public CalculationException(string message) : base(message)
    {
    }

    public CalculationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}