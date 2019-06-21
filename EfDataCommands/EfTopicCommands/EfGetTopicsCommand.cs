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
    public class EfGetTopicsCommand : BaseEfCommand, IGetTopicsCommand
    {
        public EfGetTopicsCommand(ForumContext context) : base(context)
        {
        }

        public IEnumerable<TopicDto> Execute(TopicSearch request)
        {
            var query = Context.Topics.AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(c => c.Subject
                .ToLower()
                .Contains(request.Keyword.ToLower()));
            }

            if (request.OnlyActive.HasValue)
            {
                query = query.Where(c => c.isDeleted != request.OnlyActive);
            }

            return query.Select(c => new TopicDto
            {
                Id = c.Id,
                Subject = c.Subject,
            });
        }
    }
}
