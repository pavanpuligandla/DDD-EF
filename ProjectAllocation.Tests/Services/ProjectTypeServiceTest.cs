using DataAccess.Abstraction;
using DataAccess.Repositories;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAllocation.Tests.Services
{
   [TestClass]
    public class ProjectTypeServiceTest
    {
        private Mock<IProjectTypeRepository> _mockRepository;
        private IProjectTypeService _service;
        Mock<IUnitOfWork> _mockUnitWork;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IProjectTypeRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new ProjectTypeService(_mockUnitWork.Object, _mockRepository.Object);
        }

        [TestMethod]
        public void Can_Add_ProjectType()
        {
            //Arrange
            //long Id = 3;
            ProjectType _projecttypeObj = new ProjectType()
            {
                ProjectTypeName = "MoqProject Test",
                ProjectTypeDescription = "New project type created with Effort and Moq packages",
                //CreatedDate = DateTime.Now,
                //ModifiedDate = DateTime.Now
            };
            //_mockRepository.Setup(m => m.Add(_projecttypeObj)).Returns((ProjectType p) =>
            //{
            //    p.Id = Id;
            //    return p;
            //});


            //Act
            _service.Create(_projecttypeObj);

            //Assert
            //Assert.AreEqual(Id, _projecttypeObj.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }
    }
}
