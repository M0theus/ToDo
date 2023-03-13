namespace ToDo.Application.DTO.Paged;

public class PagedDto<T>
{
    public PagedDto()
    {
        Itens = new List<T>();
    }
    public List<T> Itens { get; set; }
    public int Page { get; set; }
    public int Total { get; set; }
    public int PerPage { get; set; }
    public int PageCount { get; set; }
}