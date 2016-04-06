//using System.Data.Entity;
//using ScheduleApp.Models;
//
//namespace ScheduleApp.Context
//{
//    public class ApplicationDbContext : DbContext 
//    {
//        public ApplicationDbContext()
//            : base("DefaultConnection") 
//    {
//        //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
//
//        //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
//        //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
//        //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
//
//        Database.SetInitializer<ApplicationDbContext>(new ApplicationDbContextInitializer());
//    }
//
//        public static ApplicationDbContext Create()
//        {
//            return new ApplicationDbContext();
//        }
//
//        public DbSet<Classroom> Classrooms { get; set; }
//        public DbSet<Group> Groups { get; set; }
//        public DbSet<GroupWorkload> GroupsWorkload { get; set; }
//        public DbSet<Lesson> Lessons { get; set; }
//        public DbSet<ScheduleItem> ScheduleItems { get; set; }
//        public DbSet<Teacher> Teachers { get; set; }
//        public DbSet<TeacherWorkload> TeachersWorkload { get; set; }
//        public DbSet<Semester> Semesters { get; set; }
//        public DbSet<Form3> Form3s { get; set; }
//
//    }
//}