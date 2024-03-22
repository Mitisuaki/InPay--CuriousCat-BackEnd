namespace InPay__CuriousCat_BackEnd.Exceptions;

public class InvalidSymmetricKeyException : Exception
{
    public InvalidSymmetricKeyException()
    {
    }

    public InvalidSymmetricKeyException(string message)
        : base(message)
    {
    }

    public InvalidSymmetricKeyException(string message, Exception inner)
        : base(message, inner)
    {
    }
}