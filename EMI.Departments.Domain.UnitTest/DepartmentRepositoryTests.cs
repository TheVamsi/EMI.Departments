using EMI.Departments.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;

using EMI.Departments.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EMI.Departments.Domain.UnitTest
{
    public class DepartmentRepositoryTests
    {
        // private readonly Mock<DepartmentDbContext> mockdepartmentDBContext;
        public DepartmentRepositoryTests()
        {
            // mockdepartmentDBContext = new Mock<DepartmentDbContext>();
        }
        [Fact]
        public async Task GetDepartments_IsValid_ReturnsDepartmentsList()
        {
            var options = new DbContextOptionsBuilder<DepartmentDbContext>()
               .UseInMemoryDatabase(databaseName: "Get_Department").Options;
            using (var context = new DepartmentDbContext(options))
            {
                var deprepo = new DepartmentRepository(context);
                await deprepo.add(DepartmentRepositoryObjectMock.GetDepartmentDetails());
            }
            using (var context = new DepartmentDbContext(options))
            {
                var deprepo = new DepartmentRepository(context);
                // await deprepo.add(DepartmentRepositoryObjectMock.GetDepartmentDetails());
                await deprepo.GetDepartments();
            }
            using (var context = new DepartmentDbContext(options))
            {
                Assert.Equal(1, context.Departments.Count());
               Assert.Equal(DepartmentRepositoryObjectMock.GetDepartmentDetails().DepartmentId, context.Departments.Single().DepartmentId);
            }
        }
        [Fact]
        public async Task AddDepartment_IsValid_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<DepartmentDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_department").Options;
            using (var context = new DepartmentDbContext(options))
            {
                var deprepo = new DepartmentRepository(context);
                await deprepo.add(DepartmentRepositoryObjectMock.GetDepartmentDetails());
            }
            using (var context = new DepartmentDbContext(options))
            {
                Assert.Equal(1, context.Departments.Count());
                Assert.Equal(DepartmentRepositoryObjectMock.GetDepartmentDetails().DepartmentId, context.Departments.Single().DepartmentId);
            }
        }


        [Fact]
        public  async Task DeleteDepartment_IffoundWithId_ReturnsTrue()
        {
            const int id = 1;
            var options = new DbContextOptionsBuilder<DepartmentDbContext>()
                   .UseInMemoryDatabase(databaseName: "Delete_department").Options;
            using (var context = new DepartmentDbContext(options))
            {
                var deprepo = new DepartmentRepository(context);
                await deprepo.add(DepartmentRepositoryObjectMock.GetDepartmentDetails());
            }
            using (var context = new DepartmentDbContext(options))
            {
                var deprepo = new DepartmentRepository(context);
                deprepo.DeleteDepartment(id);
            }
            using (var context = new DepartmentDbContext(options))
            {
                Assert.Equal(0, context.Departments.Count());
                //Assert.Equal(DepartmentRepositoryObjectMock.GetDepartmentDetails().DepartmentId, context.Departments.Single().DepartmentId);
            }

        }

        [Fact]
        public void UpdateDepartment_IsSuccess_ReturnsUpdatedDepartmentDetails()
        {
            var options = new DbContextOptionsBuilder<DepartmentDbContext>()
                   .UseInMemoryDatabase(databaseName: "Update_Department").Options;
            using (var context = new DepartmentDbContext(options))
            {
                var deprepo = new DepartmentRepository(context);
                 deprepo.add(DepartmentRepositoryObjectMock.GetDepartmentDetails());
            }
            using (var context = new DepartmentDbContext(options))
            {
                var deprepo = new DepartmentRepository(context);
                deprepo.updateDepartment(DepartmentRepositoryObjectMock.updateDepartment());
            }
            using (var context = new DepartmentDbContext(options))
            {
                Assert.Equal(1, context.Departments.Count());
              
            }
        }
    }
}
       