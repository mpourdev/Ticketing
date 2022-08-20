namespace Ticketing.Core.Domain.Shared.Exceptions;

public class WrongStatusException : Exception, IException
{
    public int Code => 701;

    public WrongStatusException()
        : base("Wrong Status.")
    {
    }
}