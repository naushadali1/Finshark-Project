
using api.Models;
using api.Models.DTO;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllStocksAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, StockUpdateRequestDto stockUpdateRequestDto);
        Task<Stock?> DeleteAsync(int id);
    }
}