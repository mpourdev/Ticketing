namespace Ticketing.Core.Domain.Shared.Models;

public class PaginationModel
{
    private int _pageSize;
    public int PageIndex { get; set; }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value <= 0 ? 10 : value;
    }
}