using DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAllocation.Tests.Repositories
{
    [TestClass]
    public class ProjectRepositoryTestWithDB
    {
        ProjectAllocation.Tests.Context.TestContext databaseContext;
        ProjectTypeRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            databaseContext = new ProjectAllocation.Tests.Context.TestContext();
            objRepo = new ProjectTypeRepository(databaseContext);
        }

        [TestMethod]
        public void Can_Get_All_ProjectTypes_FromDB()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
