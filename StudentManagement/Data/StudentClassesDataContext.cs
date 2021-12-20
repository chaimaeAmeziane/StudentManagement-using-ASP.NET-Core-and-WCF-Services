using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceReferenceStudent;

namespace StudentsWCF.Data
{
    public class StudentClassesDataContext : DbContext
    {
        public StudentClassesDataContext (DbContextOptions<StudentClassesDataContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceReferenceStudent.student> student { get; set; }
    }
}
