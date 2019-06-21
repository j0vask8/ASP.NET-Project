using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CreateTopicDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Subject must have atleast 3 characters.")]
        public string Subject { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Content must have atleast 3 characters.")]
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
