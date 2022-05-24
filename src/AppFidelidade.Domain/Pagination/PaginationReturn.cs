namespace AppFidelidade.Domain.Pagination;

public class  PaginationReturn<T>
{
    private int ReturnCountRemaining(float pagesRemaining, int pageNumber, int totalRecords, int pageSize)
    {
        var countPagesRemaining = pagesRemaining - pageNumber;
            
        if ((countPagesRemaining == 0) && (totalRecords != pageSize) && ((int)pagesRemaining != pageNumber))
            countPagesRemaining = 1;
            
        return (int) countPagesRemaining;
    }
       
    public PaginationReturn(int pageNumber, int pageSize, int totalRecords, object dataPagination, float pagesRemaining)
    {
        var countPagesRemaining = ReturnCountRemaining(pagesRemaining, pageNumber, totalRecords, pageSize);
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        DataPagination = dataPagination;
        PagesRemaining = countPagesRemaining <= 0 ? 0 : countPagesRemaining;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int PagesRemaining { get; set; } 
    public object DataPagination { get; set; }
}