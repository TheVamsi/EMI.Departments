using EMI.Departments.Domain.Models;
using EMI.Departments.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMI.Departments.Domain.UnitTest
{
    public static class DepartmentRepositoryObjectMock
    {
       

        public static DepartmentDetails GetDepartmentDetails()
        {
            return new DepartmentDetails
            {
                DepartmentId = 1,
                DepartmentName = "Transport"
            };
        }

        public static IList<DepartmentDetails> departments { get => departments; set => departments = value; }

        public static DepartmentDetails createDepartment()
        {
            return null;
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
