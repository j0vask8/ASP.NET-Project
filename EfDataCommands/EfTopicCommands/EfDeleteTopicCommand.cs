using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataCommands
{
    public class EfDeleteTopicCommand : BaseEfCommand, IDeleteTopicCommand
    {
        public EfDeleteTopicCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var topic = Context.Comments.Find(request);

            if (topic == null)
            {
                throw new EntityNotFoundException();
            }

            if (topic.isDeleted == true)
            {
                throw new EntityDeleted();
            }

            topic.isDeleted = true;

            Context.SaveChanges();
        }
    }
}
