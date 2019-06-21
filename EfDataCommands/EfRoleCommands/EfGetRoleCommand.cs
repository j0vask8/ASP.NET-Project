using Application.Commands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Searches;
using Application.Exceptions;

namespace EfDataCommands.EfRoleCommands
{
    public class EfGetRoleCommand : BaseEfCommand, IGetRoleCommand
    {
        public EfGetRoleCommand(ForumContext context) : base(context)
        {
        }

        public RoleDto Execute(int request)
        {
            var category = Context.Roles.Find(request);

            if (category == null)
            {
                throw new EntityNotFoundException();
            }

            return new RoleDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
