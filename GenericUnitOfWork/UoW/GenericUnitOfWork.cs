using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericUnitOfWork.UoW
{
    public class GenericUnitOfWork<TService, TContext> : IUnitOfWork<TService, TContext>
        where TContext : DbContext
        where TService : class
    {
        private readonly TContext _context;
        public GenericUnitOfWork(TContext context) => _context = context;

        public TService GetRepository<TClass>() where TClass : class
        {
            var result = (TService)Activator.CreateInstance(typeof(TClass), _context);
            return result ?? null;
        }

        public TService GetRepository<TClass>(List<object> parameters) where TClass : class
        {
            parameters.Insert(0, _context);
            var obj = parameters.Select(x => x).ToArray();
            var result = (TService)Activator.CreateInstance(typeof(TClass), obj);
            return result ?? null;
        }
    }

  
}
