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
using projeto1.Helpers;
using projeto1.Interfaces;
using projeto1.Mappers;
using projeto1.Models;
using projeto1.Repositories;

namespace projeto1.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationDBContext context, IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //Select works the same as map in javascript
            var stocks = await _stockRepository.GetAllAsync(query);
            var stockDTO = stocks.Select(s => s.ToStockDTO());
            return Ok(stockDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null) return NotFound();

            return Ok(stock.ToStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDTO stockDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stockModel = stockDTO.ToStockFromCreatedDTO();
            await _stockRepository.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDTO());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDTO stockDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stockModel = await _stockRepository.UpdateAsync(id, stockDTO);
            if (stockModel == null) return NotFound();
            return Ok(stockModel.ToStockDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stockModel = await _stockRepository.DeleteAsync(id);
            if (stockModel == null) return NotFound();
            return NoContent();
        }
    }
}