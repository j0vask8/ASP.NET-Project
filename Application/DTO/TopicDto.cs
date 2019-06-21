using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class TopicDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Subject must have atleast 3 characters.") ]
        public string Subject { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Content must have atleast 3 characters.")]
        public string Content { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "CategoryName must have atleast 3 characters.")]
        public string Username { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "CategoryName must have atleast 3 characters.")]
        public string CategoryName { get; set; }
    }
}
