using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.DTO
{
    public class CommentUpdateRequestDto
    {
         [Required]
        public string Title { get; set; } = string.Empty;
         [Required]
        public string Content { get; set; } = string.Empty;
    }
}