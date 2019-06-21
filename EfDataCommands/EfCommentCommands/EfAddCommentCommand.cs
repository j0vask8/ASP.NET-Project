using Application.Commands.CommentCommands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfDataCommands.EfCommentCommands
{
    public class EfAddCommentCommand : BaseEfCommand, IAddCommentCommand
    {
        public EfAddCommentCommand(ForumContext context) : base(context)
        {
        }


        public void Execute(CommentCreateDto request)
        {

            if(!Context.Topics.Any(t => t.Id == request.TopicId))
            {
                throw new EntityNotFoundException("Topic");
            }

            if(!Context.Users.Any(u => u.Id == request.UserId))
            {
                throw new EntityNotFoundException("User");
            }

            Context.Comments.Add(new Comment {
                Content = request.Content,
                TopicId = request.TopicId,
                UserId = request.UserId
            });

            Context.SaveChanges();
        }
    }
}
