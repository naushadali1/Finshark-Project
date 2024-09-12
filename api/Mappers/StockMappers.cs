using api.Models;
using api.Models.DTO;

namespace api.Mappers
{
    public static class StockMappers
    {
      public static StockDto ToStockDto (this Stock stock){
        return new StockDto {
        Id = stock.Id,
        CompanyName = stock.CompanyName,
        Symbol = stock.Symbol,
        Purchase = stock.Purchase,
        LastDiv = stock.LastDiv,
        MarcketCap = stock.MarcketCap,
        Comments = stock.Comments.Select(c => c.ToCommentDto()).ToList(),
        };
      }

      public static Stock ToStockFromStockCreateDto(this StockCreateRequestDto stockDto){
return new Stock {
   Symbol = stockDto.Symbol,
   CompanyName = stockDto.CompanyName,
   Purchase = stockDto.Purchase,
   LastDiv = stockDto.LastDiv,
   MarcketCap = stockDto.MarcketCap,
   Industry = stockDto.Industry,
   
};
      }
    }
}