using System.Data.Entity;
using System.Runtime.Remoting.Lifetime;
using Schedule.Models;

namespace Schedule.Context
{
    public class ApplicationDbContext : DbContext 
    {

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupWorkload> GroupsWorkload { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Models.Schedule> Schedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherWorkload> TeachersWorkload { get; set; }

    }
}