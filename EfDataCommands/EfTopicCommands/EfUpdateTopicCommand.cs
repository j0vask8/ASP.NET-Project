using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataCommands
{
    public class EfUpdateTopicCommand : BaseEfCommand, IUpdateTopicCommand
    {
        public EfUpdateTopicCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(TopicDto request)
        {
            var topic = Context.Topics.Find(request.Id);

            if (topic == null)
            {
                throw new EntityNotFoundException();
            }

            if (topic.Subject != request.Subject)
            {
                throw new EntityAlreadyExistsException();
            }

            var user = Context.Users.Find(topic.UserId);
            var category = Context.Categories.Find(topic.CategoryId);
            
            topic.ModifiedAt = DateTime.Now;
            topic.Subject = request.Subject;
            topic.Content = request.Content;
            topic.CategoryId = category.Id;
            topic.UserId = user.Id;

            Context.SaveChanges();
        }
    }
}
