using ToDo.Domain.Contracts;
using ToDo.Domain.Models;

namespace ToDo.Infra.Paged;

public class PagedResult<T> : IPagedResult<T> where T : Base, new()
{
    public PagedResult()
    {
        Items = new List<T>();
    }
    
    public List<T> Items { get; set; }
    public int Total { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int PageCount { get; set; }
}