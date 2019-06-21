using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataCommands
{
    public class EfGetUserCommand : BaseEfCommand, IGetUserCommand
    {
        public EfGetUserCommand(ForumContext context) : base(context)
        {
        }

        public UserDto Execute(int request)
        {
            var user = Context.Users.Find(request);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }

            var role = Context.Roles.Find(user.Id);

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                UserType = role.Name
            };
        }
    }
}
