using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using University.BL.Models;

namespace University.BL.Data
{
    public class UniversityContext : IdentityDbContext<ApplicationUser>
    {
        private static UniversityContext universityContext = null;
        public UniversityContext() : base("UniversityContext")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        public static UniversityContext Create()
        {
            if (universityContext == null)
                universityContext = new UniversityContext();
            return universityContext;
        }
    }
}