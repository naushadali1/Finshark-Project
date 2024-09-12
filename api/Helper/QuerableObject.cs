namespace api.Helper
{
    public class QuerableObject
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? SortBy { get; set; } = null;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool IsDescending { get; set; } = false;
    }
}