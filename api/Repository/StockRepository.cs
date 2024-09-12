using api.Data;
using api.Helper;
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

        public async Task<List<Stock>> GetAllStocksAsync(QuerableObject query)
        {
            var stocks = dBContext.Stock.Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(x => x.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(x => x.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("CompanyName", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.CompanyName) : stocks.OrderBy(s => s.CompanyName);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }



        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await dBContext.Stock.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> StockExistsAsync(int id)
        {
            return await dBContext.Stock.AnyAsync(e => e.Id == id);
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