using System;
using Domain;
using System.Collections.Generic;
using Application.Exceptions;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Interfaces;
using EfDataAccess;

namespace EfDataCommands
{
    public class EfAddCategoryCommand : BaseEfCommand, IAddCategoryCommand
    {
        public EfAddCategoryCommand(ForumContext context) : base(context)
        {
        }

        public void Execute(CreateCategoryDto request)
        {
            if(Context.Categories.Any(c => c.Name == request.Name))
            {
                throw new EntityAlreadyExistsException();
            }

            Context.Add(new Category
            {
                Name = request.Name
            });

            Context.SaveChanges();

        }

    }

}
