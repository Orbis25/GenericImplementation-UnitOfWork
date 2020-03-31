using GenericUnitOfWork.BussinesLogic.Services;
using GenericUnitOfWork.Data;
using GenericUnitOfWork.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericUnitOfWork.UoW.Normal
{
    public class UnitOfWork : IUnitOfWork
    {
        #region services
        private TestOneService _testOneService;
        private TestTwoService _testTwoService;
        private TestThreeService _testThreeService;

        #endregion

        private readonly ApplicationDbContext _db;
        private readonly IOptions<Test> _options;
        public UnitOfWork(ApplicationDbContext db, IOptions<Test> options)
        {
            _db = db;
            _options = options;
        }
        public ITestOneService TestOneService => _testOneService ?? (_testOneService = new TestOneService(_db));

        public ITestTwoService TestTwoService => _testTwoService ?? (_testTwoService = new TestTwoService(_db, _options));
        public ITestThreeService TestThreeService => _testThreeService ?? (_testThreeService = new TestThreeService(_db));
    }
}
