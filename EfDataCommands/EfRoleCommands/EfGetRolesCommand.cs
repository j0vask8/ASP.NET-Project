using Application.Commands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfDataCommands.EfRoleCommands
{
    public class EfGetRolesCommand : BaseEfCommand, IGetRolesCommand
    {
        public EfGetRolesCommand(ForumContext context) : base(context)
        {
        }

        public IEnumerable<RoleDto> Execute(RoleSearch request)
        {
            var query = Context.Roles.AsQueryable();

            if (request.Name != null)
            {
                query = query.Where(c => c.Name
                .ToLower()
                .Contains(request.Name.ToLower()));
            }

            if (request.OnlyActive.HasValue)
            {
                query = query.Where(c => c.isDeleted != request.OnlyActive);
            }

            return query.Select(c => new RoleDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
