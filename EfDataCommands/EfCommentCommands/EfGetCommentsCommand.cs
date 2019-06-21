using Application.Commands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfDataCommands.EfCommentCommands
{
    public class EfGetCommentsCommand : BaseEfCommand, IGetCommentsCommand
    {
        public EfGetCommentsCommand(ForumContext context) : base(context)
        {
        }

        public IEnumerable<CommentDto> Execute(CommentSearch request)
        {
            var query = Context.Comments.AsQueryable();

            if (request.Comment != null)
            {
                query = query.Where(c => c.Content.ToLower().Contains(request.Comment.ToLower()));
            }

            return query.Select(c => new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
            });
        }
    }
}
