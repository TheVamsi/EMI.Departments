using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using EMI.Departments.Domain.Interfaces;
using EMI.Departments.Domain.Models;

namespace EMI.Departments.Domain.Services
{
  public  class DepartmentService :IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Task<bool> add(DepartmentDetails departmentDetails)
        {
            return _departmentRepository.add(departmentDetails);
        }

        public async Task<IList<DepartmentDetails>> GetDepartments()
        {
            
            var departmentDetails =await  _departmentRepository.GetDepartments();
           
            return departmentDetails;
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.DeleteDepartment(id);
            return department;
        }

        public DepartmentDetails updateDepartment(DepartmentDetails departmentDetails)
        {
            var updatedResult =  _departmentRepository.updateDepartment(departmentDetails);
            return updatedResult;
        }
    }
}
