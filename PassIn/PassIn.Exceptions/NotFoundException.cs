namespace PassIn.Exceptions;
public class NotFoundException : PassInException
{
    public NotFoundException(string message) : base(message)
    {
    }
}