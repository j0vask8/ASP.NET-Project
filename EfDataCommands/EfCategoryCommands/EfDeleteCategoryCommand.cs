using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataCommands
{
    public class EfDeleteCategoryCommand : BaseEfCommand, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var category = Context.Categories.Find(request);
            if(category == null)
            {
                throw new EntityNotFoundException();
            }

            if(category.isDeleted == true)
            {
                throw new EntityDeleted();
            }

            category.isDeleted = true;

            Context.SaveChanges();
        }
    }
}
