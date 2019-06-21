using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CommentCreateDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Comment must have atleast 3 characters.")]
        public string Content { get; set; }
        //public User User { get; set; }
        [Required]
        public int UserId { get; set; }
        //public Topic Topic { get; set; }
        [Required]
        public int TopicId { get; set; }
    }
}
