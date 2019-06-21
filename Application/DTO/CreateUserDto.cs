using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CreateUserDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Username must have atleast 2 characters.")]
        [MaxLength(25)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }

    }
}
