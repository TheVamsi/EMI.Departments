using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

using EMI.Departments.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EMI.Departments.Domain.Repositories
{

   public class DepartmentDbContext :DbContext
    {
        public DepartmentDbContext()
        {

        }
        public DepartmentDbContext(DbContextOptions options) :base(options)
        {
           
        }
      
        public virtual DbSet<DepartmentDetails> Departments { get ; set; }

      
    }
}
