using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericUnitOfWork.UoW
{
    public interface IGenericUnitOfWork<TService, TContext>
        where TService : class
        where TContext : DbContext
    {
        /// <summary>
        /// For only one param where the dbcontext is a first param of service constructor
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <returns></returns>
        TService GetRepository<TClass>() where TClass : class;
        /// <summary>
        /// For many params where the dbcontext is a first param of service constructor
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        TService GetRepository<TClass>(List<object> parameters) where TClass : class;
    }
}
