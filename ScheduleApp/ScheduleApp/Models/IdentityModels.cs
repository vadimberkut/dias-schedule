using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScheduleApp.Context;
using ScheduleApp.Helpers;

namespace ScheduleApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       // public ScheduleAccessMode CurrentScheduleAccessMode { get; set; }
        public ScheduleAccessMode ScheduleAccessMode { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbContextInitializer());
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupWorkload> GroupsWorkload { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<ScheduleItem> ScheduleItems { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherWorkload> TeachersWorkload { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Form3> Form3s { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
    }
}