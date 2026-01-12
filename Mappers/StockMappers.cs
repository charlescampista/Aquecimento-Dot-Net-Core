using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto1.DTOs.Stock;
using projeto1.Models;

namespace projeto1.Mappers
{
    public static class StockMappers
    {
        //The keyword this means that the method ToStockDTO
        //can be called as if it were part of the Stock class.
        //In C# this is called extension method. (It make the code less verbose)
        public static StockDTO ToStockDTO(this Stock stockModel)
        {
            return new StockDTO
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap
            };
        }

        public static Stock ToStockFromCreatedDTO(this CreateStockRequestDTO stockDTO)
        {
            return new Stock
            {
                Symbol = stockDTO.Symbol,
                CompanyName = stockDTO.CompanyName,
                Purchase = stockDTO.Purchase,
                LastDiv = stockDTO.LastDiv,
                Industry = stockDTO.Industry,
                MarketCap = stockDTO.MarketCap
            };
        }
    }
}