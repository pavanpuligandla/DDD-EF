using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using System;

namespace ProjectAllocation.Tests.Controllers
{
    [TestClass]
    public class ProjectTypeControllerTest
    {
        private Mock<IProjectTypeService> _mockProjectTypeService;

        [TestInitialize]
        public void Initialize()
        {
           _mockProjectTypeService = new Mock<IProjectTypeService>();
        }

        [TestMethod]
        public void create_new_projecttype()
        {
            //Object creation
            ProjectType _projectType = new ProjectType()
            {
                ProjectTypeName = "MoqProject",
                ProjectTypeDescription = "New project type created with Effort and Moq packages",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            _mockProjectTypeService.Setup(m => m.Create(_projectType)).Verifiable("an error occured");
            //Assert
            //if(_mockProjectTypeService !=null)
            //_mockProjectTypeService.Verify(m => m.Create(_projectType), Times.Once, "An error occured");
        }
    }
}
