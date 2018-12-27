using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using EMI.Departments.Users.Controller;
using System.Threading.Tasks;
using EMI.Departments.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using EMI.Departments.Domain.Models;

namespace EMI.Departments.Users.UnitTest
{
  
   public class DepartmentDetailsControllerTests
    {
        private  readonly Mock<IDepartmentService> mock;
        public DepartmentDetailsControllerTests()
        {
            mock = new Mock<IDepartmentService>();
        }
        [Fact]
        public async Task GetDepartments_IsPresent_ReturnsOkResult()
        {
            mock.Setup(x => x.GetDepartments()).Returns(Task.FromResult(DepartmentDetailsControllerObjectMock.GetDepartmentDetails()));
            var departmentsController = new DepartmentDetailsController(mock.Object);
            var resultToCheck = await departmentsController.GetDepartments();
            Assert.IsType<OkObjectResult>(resultToCheck);

        }
        [Fact]
        public async Task GetDepartments_ISNotPresent_ReturnsNotFound()
        {
            mock.Setup(x => x.GetDepartments()).Returns(Task.FromResult(DepartmentDetailsControllerObjectMock.GetDepartmentDetailsNull()));
            var departmentsController = new DepartmentDetailsController(mock.Object);
            var resultToCheck = await departmentsController.GetDepartments();
            Assert.IsType<NotFoundResult>(resultToCheck);

        }
        [Fact]
        public async Task AddDepartment_IsNotNull_ReturnsOK()
        {
            mock.Setup(x => x.add(It.IsAny<DepartmentDetails>())).Returns(Task.FromResult(true));
            var departmentController = new DepartmentDetailsController(mock.Object);
            var result = await departmentController.addDepartment(DepartmentDetailsControllerObjectMock.createDepartment());
            Assert.IsType<OkResult>(result);


        }
        [Fact]
        public async Task AddDepartment_IsNull_ReturnsBadRequest()
        {
            mock.Setup(x => x.add(It.IsAny<DepartmentDetails>())).Returns(Task.FromResult(false));

            var departmentController = new DepartmentDetailsController(mock.Object);
            var result = await departmentController.addDepartment(DepartmentDetailsControllerObjectMock.createDepartmentNull());
            Assert.IsType<BadRequestResult>(result);


        }

        [Fact]
        public void DeleteDepartment_Id_ReturnsOkResult()
        {
            const int idToRemove = 1;
            mock.Setup(x => x.DeleteDepartment(It.IsAny<int>())).Returns(true);
            var departmentController = new DepartmentDetailsController(mock.Object);
            var result = departmentController.DeleteDepartment(idToRemove);
            Assert.IsType<OkResult>(result);


        }

        [Fact]
        public void UpdateDepartment_IfSuccess_ReturnsOkResult()
        {
            mock.Setup(x => x.updateDepartment(It.IsAny<DepartmentDetails>())).Returns(DepartmentDetailsControllerObjectMock.createDepartment());
            var departmentController = new DepartmentDetailsController(mock.Object);
            var result = departmentController.UpdateDepartment(DepartmentDetailsControllerObjectMock.updateDepartment());
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void UpdateDepartment_IfSuccess_ReturnsBadRequestResult()
        {
            mock.Setup(x => x.updateDepartment(It.IsAny<DepartmentDetails>())).Returns(DepartmentDetailsControllerObjectMock.updateDepartmentNull());
            var departmentController = new DepartmentDetailsController(mock.Object);
            var result = departmentController.UpdateDepartment(DepartmentDetailsControllerObjectMock.updateDepartmentNull());
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
