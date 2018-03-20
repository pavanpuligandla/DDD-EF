using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using DataAccess.Repositories;

namespace ProjectAllocation.Tests.Repositories
{
    [TestClass]
    public class ProjectTypeRepositoryTest
    {
        DbConnection connection;
        ProjectAllocation.Tests.Context.TestContext databaseContext;
        ProjectTypeRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new ProjectAllocation.Tests.Context.TestContext(connection);
            objRepo = new ProjectTypeRepository(databaseContext);

        }

        [TestMethod]
        public void Can_Get_All_ProjectTypes()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
