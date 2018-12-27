using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EMI.Departments.Domain.Models;

namespace EMI.Departments.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
         Task<IList<DepartmentDetails>> GetDepartments();
        Task<bool> add(DepartmentDetails departmentDetails);
        bool DeleteDepartment(int id);
        DepartmentDetails updateDepartment(DepartmentDetails department);
        
    }
}
