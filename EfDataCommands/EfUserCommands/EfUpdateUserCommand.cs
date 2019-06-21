using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfDataCommands
{
    public class EfUpdateUserCommand : BaseEfCommand, IUpdateUserCommand
    {
        public EfUpdateUserCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(CreateUserDto request)
        {
            var user = Context.Users.Find(request.Id);

            if (user.Username != request.Username)
            {
                if (Context.Users.Any(c => c.Username == request.Username))
                {
                    throw new EntityAlreadyExistsException();
                }
                user.Username = request.Username;

            }
            if (user.Email != request.Email)
            {
                if (Context.Users.Any(c => c.Email == request.Email))
                {
                    throw new EntityAlreadyExistsException();
                }
                user.Email = request.Email;

            }

            if (user.Password != request.Password)
            {
                if (Context.Users.Any(c => c.Password == request.Password))
                {
                    throw new EntityAlreadyExistsException();
                }
                user.Password = request.Password;

            }

            user.ModifiedAt = DateTime.Now;

            Context.SaveChanges();
        }
    }
}
