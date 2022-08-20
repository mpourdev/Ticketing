namespace Ticketing.Core.Domain.Shared.Exceptions;

public interface IException
{
    public int Code { get; }
    public string Message { get; }
}