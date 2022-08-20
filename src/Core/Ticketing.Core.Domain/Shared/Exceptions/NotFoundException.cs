namespace Ticketing.Core.Domain.Shared.Exceptions;

/// <summary>
/// Not Found Exception [Code=604]
/// </summary>
public class NotFoundException : Exception, IException
{
    public int Code => 604;

    public NotFoundException()
        : base("Could not find this item.")
    {
    }
}