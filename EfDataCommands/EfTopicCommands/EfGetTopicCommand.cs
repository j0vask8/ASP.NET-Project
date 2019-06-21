using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataCommands
{
    public class EfGetTopicCommand : BaseEfCommand, IGetTopicCommand
    {
        public EfGetTopicCommand(ForumContext context) : base(context)
        {
        }

        public TopicDto Execute(int request)
        {
            var topic = Context.Topics.Find(request);

            if (topic == null)
            {
                throw new EntityNotFoundException();
            }

            var user = Context.Users.Find(topic.UserId);
            var category = Context.Categories.Find(topic.CategoryId);

            return new TopicDto
            {
                Id = topic.Id,
                Subject = topic.Subject,
                Content = topic.Content,
                Username = user.Username,
                CategoryName = category.Name,
            };
        }
    }
}
