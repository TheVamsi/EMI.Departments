using EMI.Departments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMI.Departments.Users.UnitTest
{
   public static  class DepartmentDetailsControllerObjectMock
    {
       public static IList<DepartmentDetails>  GetDepartmentDetails()
        {
            return new List<DepartmentDetails>
            {
                new DepartmentDetails
                {
                    DepartmentId=26,
                    DepartmentName="Transport",

                },
                new DepartmentDetails
                {
                    DepartmentId=27,
                    DepartmentName="sales",
                }
            };
        }
        public static IList<DepartmentDetails> GetDepartmentDetailsNull()
        {
            return null;
        }
        public static DepartmentDetails createDepartment()
        {
            return new DepartmentDetails
            {
                DepartmentId = 1,
                DepartmentName = "Transport"
            };
        }

        public static IList<DepartmentDetails> departments { get => departments; set => departments = value; }

        public static DepartmentDetails createDepartmentNull()
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
        public static DepartmentDetails updateDepartmentNull()
        {
            return null;
        }
    }
}
