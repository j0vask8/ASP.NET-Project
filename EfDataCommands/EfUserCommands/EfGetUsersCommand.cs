using Application.Commands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfDataCommands
{
    public class EfGetUsersCommand : BaseEfCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(ForumContext context) : base(context)
        {
        }
        public IEnumerable<UserDto> Execute(UserSearch request)
        {
            var query = Context.Users.AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(c => c.Username.ToLower().Contains(request.Keyword.ToLower()));
            }

            return query.Select(c => new UserDto
            {
                Id = c.Id,
                Username = c.Username,
                Email = c.Email
            });
        }
    }
}
