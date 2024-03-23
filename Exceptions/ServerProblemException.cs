namespace InPay__CuriousCat_BackEnd.Exceptions;

public class ServerProblemException : Exception
{
    public ServerProblemException()
    {
    }

    public ServerProblemException(string message)
        : base(message)
    {
    }

    public ServerProblemException(string message, Exception inner)
        : base(message, inner)
    {
    }
}