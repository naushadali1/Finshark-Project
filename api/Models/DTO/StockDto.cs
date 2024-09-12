namespace api.Models.DTO
{
    public class StockDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarcketCap { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();

    }
}