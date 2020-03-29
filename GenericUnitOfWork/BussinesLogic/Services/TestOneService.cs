using GenericUnitOfWork.Data;
using GenericUnitOfWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericUnitOfWork.BussinesLogic.Services
{

    /// <summary>
    /// This code is for example , not impement this, is a bad practice
    /// </summary>
    public interface ITestOneService
    {
        Task<string> GetUserName();
    }

    public class TestOneService : ITestOneService
    {
        private readonly ApplicationDbContext _db;
        public TestOneService(ApplicationDbContext db) => _db = db;

        public async Task<string> GetUserName()
        {
            var result = await _db.Users.FirstOrDefaultAsync();
            return result.UserName;
        }
    }

    public interface ITestTwoService 
    {
        Task<string> GetUserName();
    }

    public class TestTwoService : ITestTwoService
    {
        private readonly ApplicationDbContext _db;
        private Test _test;
        public TestTwoService(ApplicationDbContext db,IOptions<Test> secoundParam)
        {
            _db = db;
            _test = secoundParam.Value;
        }

        public async Task<string> GetUserName()
        {
            var result = await _db.Users.FirstOrDefaultAsync();
            return $"{_test.Grettings} {result.UserName}";
        }
    }


}
