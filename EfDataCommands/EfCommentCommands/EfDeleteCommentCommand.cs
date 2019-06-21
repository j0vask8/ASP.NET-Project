using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.Exceptions;
using EfDataAccess;

namespace EfDataCommands.EfCommentCommands
{
    public class EfDeleteCommentCommand : BaseEfCommand, IDeleteCommentCommand
    {
        public EfDeleteCommentCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var comment = Context.Comments.Find(request);

            if(comment == null)
            {
                throw new EntityNotFoundException();
            }

            if(comment.isDeleted == true)
            {
                throw new EntityDeleted();
            }

            comment.isDeleted = true;

            Context.SaveChanges();
        }
    }
}
