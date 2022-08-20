namespace Ticketing.Core.Domain.Shared.Dtos;

public class PagedListDto<TDto>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public long Total { get; set; }
    public List<TDto> List { get; set; }
}