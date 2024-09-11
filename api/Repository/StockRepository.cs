using api.Data;
using api.Interfaces;
using api.Models;
using api.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext dBContext;

        public StockRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await dBContext.Stock.AddAsync(stockModel);
            await dBContext.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await dBContext.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            dBContext.Stock.Remove(stock);
            await dBContext.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllStocksAsync()
        {
            return await dBContext.Stock.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await dBContext.Stock.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsync(int id, StockUpdateRequestDto stockUpdateRequestDto)
        {
            var stock = await dBContext.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            stock.Symbol = stockUpdateRequestDto.Symbol;
            stock.CompanyName = stockUpdateRequestDto.CompanyName;
            stock.Purchase = stockUpdateRequestDto.Purchase;
            stock.LastDiv = stockUpdateRequestDto.LastDiv;
            stock.Industry = stockUpdateRequestDto.Industry;
            stock.MarcketCap = stockUpdateRequestDto.MarcketCap;
            await dBContext.SaveChangesAsync();
            return stock;
        }
    }
}