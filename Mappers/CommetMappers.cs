using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto1.DTOs.Comment;
using projeto1.Models;

namespace projeto1.Mappers
{
    public static class CommetMappers
    {
        //The keyword this means that the method ToCommentDTO
        //can be called as if it were part of the Comment class.
        //In C# this is called extension method. (It make the code less verbose)
        public static CommentDTO ToCommentDTO(this Comment comment)
        {
            return new CommentDTO {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId
            };
        }
    }
}