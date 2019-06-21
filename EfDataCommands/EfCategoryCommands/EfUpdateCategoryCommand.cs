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
    public class EfUpdateCategoryCommand : BaseEfCommand, IUpdateCategoryCommand
    {
        public EfUpdateCategoryCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {
            var category = Context.Categories.Find(request.Id);

            if(category == null)
            {
                throw new EntityNotFoundException();
            }

            if (category.isDeleted)
            {
                throw new EntityDeleted();
            }

            if(category.Name != request.Name)
            {
                if (Context.Categories.Any(c => c.Name == request.Name))
                {
                    throw new EntityAlreadyExistsException();
                }

                category.Name = request.Name;

                Context.SaveChanges();
            }
        }
    }
}
