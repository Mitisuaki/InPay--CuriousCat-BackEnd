namespace InPay__CuriousCat_BackEnd.Exceptions;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException()
    {
    }

    public AlreadyExistsException(string message)
        : base(message)
    {
    }

    public AlreadyExistsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}