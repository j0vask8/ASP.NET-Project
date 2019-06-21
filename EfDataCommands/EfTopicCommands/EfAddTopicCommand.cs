using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfDataCommands
{
    public class EfAddTopicCommand : BaseEfCommand, IAddTopicCommand
    {
        public EfAddTopicCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(CreateTopicDto request)
        {
            if(Context.Topics.Any(t => t.Subject == t.Subject))
            {
                throw new EntityAlreadyExistsException();
            }


            Context.Topics.Add(new Topic
            {
                Subject = request.Subject,
                Content = request.Content,
                UserId = request.UserId,
                CategoryId = request.CategoryId
            });

            Context.SaveChanges();
        }
    }
}
