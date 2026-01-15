using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projeto1.DTOs.Comment;
using projeto1.Interfaces;
using projeto1.Mappers;
using projeto1.Repositories;

namespace projeto1.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository repository)
        {
            _commentRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentsDTO = comments.Select(c => c.ToCommentDTO());
            return Ok(commentsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if(comment == null) return NotFound();
            return Ok(comment.ToCommentDTO());
        }

        // [HttpPost]
        // public async Task<IActionResult> Create([FromBody] CreateCommentRequestDTO commentDTO)
        // {
            
        // }
    }
}