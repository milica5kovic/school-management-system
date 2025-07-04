public class PagedList<T> : List<T>
{
    public int PageIndex { get; }
    public int TotalPages { get; }
    public int TotalItems { get; }

    public PagedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalItems = count;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
}
