using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using EMI.Departments.Domain.Models;

namespace EMI.Departments.Domain.Services
{
    public interface IDepartmentService
    {
        Task<IList<DepartmentDetails>> GetDepartments();
        Task<bool> add(DepartmentDetails departmentDetails);
        bool DeleteDepartment(int id);
        DepartmentDetails updateDepartment(DepartmentDetails departmentDetails);
        
    }
}
