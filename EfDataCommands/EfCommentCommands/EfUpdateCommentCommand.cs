using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataCommands.EfCommentCommands
{
    public class EfUpdateCommentCommand : BaseEfCommand, IUpdateCommentCommand
    {
        public EfUpdateCommentCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(CommentDto request)
        {
            var comment = Context.Comments.Find(request.Id);

            if(comment == null)
            {
                throw new EntityNotFoundException();
            }

            if(comment.Content != request.Content)
            {
                comment.ModifiedAt = DateTime.Now;
                comment.Content = request.Content;
            }

            Context.SaveChanges();
        }
    }
}
