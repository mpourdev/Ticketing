namespace Ticketing.Core.Domain.Shared.Exceptions;

/// <summary>
/// General Exception [Code=600]
/// </summary>
public class GeneralException : Exception, IException
{
    public const int CODE = 600;

    public int Code => CODE;

    public GeneralException(string message)
        : base(message)
    {

    }

    public GeneralException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}