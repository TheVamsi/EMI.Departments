using EMI.Departments.Domain.Interfaces;
using EMI.Departments.Domain.Services;
using EMI.Departments.Domain.Models;
using System.Collections.Generic;
using System;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace EMI.Departments.Domain.UnitTest
{
    public class DepartmentServiceTests
    {
        // private readonly IDepartmentService departmentService;
        private readonly Mock<IDepartmentRepository> mockDepartmentRepository;
        public DepartmentServiceTests()
        {
            mockDepartmentRepository = new Mock<IDepartmentRepository>();
           
        }
       

        [Fact]
        public async Task AddDepartment_Isvalid_ReturnsTrue()
        {
            mockDepartmentRepository.Setup(x => x.add(It.IsAny<DepartmentDetails>())).Returns(Task.FromResult(true));
            var depService = new DepartmentService(mockDepartmentRepository.Object);
            var res = await depService.add(DepartmentServiceObjectMock.createDepartment());
            Assert.True(res);
        }

        [Fact]
        public void DeleteDepartment_IfFoundWithId_ReturnsTrue()
        {
            const int id = 1;
            mockDepartmentRepository.Setup(x => x.DeleteDepartment(It.IsAny<int>())).Returns(true);
            var depService = new DepartmentService(mockDepartmentRepository.Object);
            var res = depService.DeleteDepartment(id);
            Assert.True(res);

        }

        [Fact]
        public async Task GetDepartments_IsValid_ReturnsDepartmentsList()
        {
            mockDepartmentRepository.Setup(x => x.GetDepartments()).Returns(Task.FromResult(DepartmentServiceObjectMock.departmentDetails));
            var departmentService = new DepartmentService(mockDepartmentRepository.Object);
            var result = await departmentService.GetDepartments();
            Assert.NotNull(result);
            Assert.Equal(DepartmentServiceObjectMock.departmentDetails, result);
        }

        [Fact]
        public void UpdateDepartments_ISSuccess_ReturnUpdatedDepartment()
        {
            mockDepartmentRepository.Setup(x => x.updateDepartment(It.IsAny<DepartmentDetails>())).Returns(DepartmentServiceObjectMock.updateDepartment());
            var departmentService = new DepartmentService(mockDepartmentRepository.Object);
            var result = departmentService.updateDepartment(DepartmentServiceObjectMock.GetDepartmentDetails());
            Assert.NotNull(result);

        }
    }
}
