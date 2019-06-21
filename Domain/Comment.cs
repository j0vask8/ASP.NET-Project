using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Topic Topic { get; set; }
        public int TopicId { get; set; }
    }
}
