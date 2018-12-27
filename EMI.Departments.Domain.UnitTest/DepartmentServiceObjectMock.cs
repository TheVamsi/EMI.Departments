using EMI.Departments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMI.Departments.Domain.UnitTest
{
   public static  class DepartmentServiceObjectMock
    {
        public static DepartmentDetails GetDepartmentDetails()
        {
            return new DepartmentDetails
            {
                DepartmentId = 1,
                DepartmentName = "Transport"
            };
        }

        public static IList<DepartmentDetails> departmentDetails = new List<DepartmentDetails> { GetDepartmentDetails() };

        public static int addDepartments()
        {
            return 0;
        }
        public static DepartmentDetails createDepartment()
        {
            return new DepartmentDetails
            {
                DepartmentId = 56,
                DepartmentName = "Sales"
            };
        }
        public static DepartmentDetails updateDepartment()
        {
            return new DepartmentDetails
            {
                DepartmentId = 1,
                DepartmentName = "Shubham Industries"
            };
        }
    }
}
