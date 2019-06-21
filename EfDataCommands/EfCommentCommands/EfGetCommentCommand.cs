using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataCommands.EfCommentCommands
{
    public class EfGetCommentCommand : BaseEfCommand, IGetCommentCommand
    {
        public EfGetCommentCommand(ForumContext context) : base(context)
        {
        }

        public CommentDto Execute(int request)
        {
            var comment = Context.Comments.Find(request);
            if (comment == null)
            {
                throw new EntityNotFoundException();
            }

            var user = Context.Users.Find(comment.UserId);
            var topic = Context.Topics.Find(comment.TopicId);

            return new CommentDto
            {
                Username = user.Username,
                Topic = topic.Content,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
            };
        }
    }
}
