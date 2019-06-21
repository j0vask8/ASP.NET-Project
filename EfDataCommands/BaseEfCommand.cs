using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataCommands
{
    public abstract class BaseEfCommand
    {
        protected ForumContext Context { get; }
        protected BaseEfCommand(ForumContext context) => Context = context;
    }
}
