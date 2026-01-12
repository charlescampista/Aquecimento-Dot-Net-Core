using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using projeto1.Data;
using projeto1.DTOs.Stock;
using projeto1.Mappers;
using projeto1.Models;

namespace projeto1.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Select works the same as map in javascript
            var stocks = await _context.Stocks.ToListAsync();
            var stockDTO = stocks.Select(s => s.ToStockDTO());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null) return NotFound();

            return Ok(stock.ToStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDTO stockDTO)
        {
            var stockModel = stockDTO.ToStockFromCreatedDTO();
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDTO stockDTO)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null) return NotFound();

            stockModel.Symbol = stockDTO.Symbol;
            stockModel.CompanyName = stockDTO.CompanyName;
            stockModel.Purchase = stockDTO.Purchase;
            stockModel.LastDiv = stockDTO.LastDiv;
            stockModel.Industry = stockDTO.Industry;
            stockModel.MarketCap = stockDTO.MarketCap;

            await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id); 

            if (stockModel == null) return NotFound();

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            
            return NoContent();          
        }
    }
}