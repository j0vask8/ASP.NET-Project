﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Topic : BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
