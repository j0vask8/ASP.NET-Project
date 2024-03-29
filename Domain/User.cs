﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Picture { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
