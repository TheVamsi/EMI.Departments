using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMI.Departments.Domain.Interfaces;
using EMI.Departments.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMI.Departments.Domain.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DepartmentDbContext _dbContext;
        public DepartmentRepository(DepartmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
      
        public async Task<IList<DepartmentDetails>> GetDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
            //return new List<DepartmentDetails>
            //{
            //    new DepartmentDetails(){DepartmentId = 1,
            //    DepartmentName = "Transport" }
            //};
        }

        public async Task<bool> add([Bind("DepartmentName")] DepartmentDetails departmentDetails)
        {
            _dbContext.Departments.Add(departmentDetails);
            var res = await _dbContext.SaveChangesAsync();
            if(res != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDepartment(int id)
        {
            var departmentDetails = _dbContext.Departments.Find(id);
            _dbContext.Departments.Remove(departmentDetails);
            var res = _dbContext.SaveChanges();
            if (res != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        public DepartmentDetails updateDepartment(DepartmentDetails department)
        {
            var existingDepartment = _dbContext.Departments.Find(department.DepartmentId);
            if(existingDepartment != null)
            {
                existingDepartment.DepartmentName = department.DepartmentName;
                _dbContext.SaveChanges();
            }
            return existingDepartment;
           

        }
    }
}
