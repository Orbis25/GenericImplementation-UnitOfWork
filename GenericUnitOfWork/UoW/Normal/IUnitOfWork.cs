using GenericUnitOfWork.BussinesLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericUnitOfWork.UoW.Normal
{
    public interface IUnitOfWork
    {
        ITestOneService TestOneService { get; }
        ITestTwoService TestTwoService { get; }
        ITestThreeService TestThreeService { get; }
    }
}
