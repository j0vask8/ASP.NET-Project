using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfDataCommands
{
    public class EfAddUserCommand : BaseEfCommand, IAddUserCommand
    {
        public EfAddUserCommand(ForumContext context) : base(context)
        {
        }
        public void Execute(CreateUserDto request)
        {
            if (Context.Users.Any(u => u.Username == request.Username))
            {
                throw new EntityAlreadyExistsException();
            }

            if (Context.Users.Any(u => u.Email == request.Email))
            {
                throw new EntityAlreadyExistsException();
            }

            Context.Users.Add(new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                RoleId = request.RoleId,
            });

            Context.SaveChanges();
        }
    }
}
