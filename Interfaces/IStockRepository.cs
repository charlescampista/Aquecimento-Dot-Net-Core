using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto1.DTOs.Stock;
using projeto1.Models;

namespace projeto1.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDTO stockDTO);
        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExistsAsync(int id);

    }
}