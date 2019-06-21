using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "The Comment must have atleast 3 characters.")]
        public string Content { get; set; }
        public string Username { get; set; }
        public string Topic { get; set; }
        //public int UserId { get; set; }
        //public int TopicId { get; set; }
    }
}
