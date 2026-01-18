using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projeto1.DTOs.Comment
{
    public class CreateCommentDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Titlie must be 5 characteres")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 characteres")]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [MinLength(5, ErrorMessage = "Titlie must be 5 characteres")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 characteres")]
        public string Content { get; set; } = string.Empty;

    }
}