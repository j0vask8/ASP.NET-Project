using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataCommands
{
    public class EfDeleteUserCommand : BaseEfCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);

            if(user == null)
            {
                throw new EntityNotFoundException();
            }

            if(user.isDeleted == true)
            {
                throw new EntityDeleted();
            }

            user.isDeleted = true;
            Context.SaveChanges();
        }
    }
}
