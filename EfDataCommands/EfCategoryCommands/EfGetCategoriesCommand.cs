using Application.Commands;
using Application.DTO;
using Application.Searches;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfDataCommands
{
    public class EfGetCategoriesCommand : BaseEfCommand, IGetCategoriesCommand
    {
        public EfGetCategoriesCommand(ForumContext context) : base(context)
        {
        }

        public IEnumerable<CategoryDto> Execute(CategorySearch request)
        {
            var query = Context.Categories.AsQueryable();

            if(request.Keyword != null)
            {
                query = query.Where(c => c.Name
                .ToLower()
                .Contains(request.Keyword.ToLower()));
            }

            if (request.OnlyActive.HasValue)
            {
                query = query.Where(c => c.isDeleted != request.OnlyActive);
            }

            return query.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
