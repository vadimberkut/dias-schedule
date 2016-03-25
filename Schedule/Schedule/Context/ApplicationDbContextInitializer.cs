using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Schedule.Models;

namespace Schedule.Context
{
    public class ApplicationDbContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //public class ApplicationDbContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            List<Group> groups = new List<Group>()
            {
                new Group() {Title = "ПК-12-1", StudentsAmount = 30},
                new Group() {Title = "ПК-12-2", StudentsAmount = 15},
                new Group() {Title = "ПК-13-1", StudentsAmount = 20},
                new Group() {Title = "ПК-13-2", StudentsAmount = 10},
                new Group() {Title = "ПК-14-1", StudentsAmount = 36},
                new Group() {Title = "ПК-14-2", StudentsAmount = 20},
            };
            //groups.Add(new Group() {Title = "ПК-12-1"});

            foreach (var group in groups)
            {
                context.Groups.AddOrUpdate(i => i.Title,group);
            }
            context.SaveChanges();

            //Teachers
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    DateOfBirth = DateTime.Now,
                    FirstName = "Ivan",
                    MiddleName = "Olegovich",
                    LastName = "Gromov",
                    Gender = "male"
                },
                new Teacher()
                {
                    DateOfBirth = DateTime.Now,
                    FirstName = "Vladimir",
                    MiddleName = "Ivanovich",
                    LastName = "Rakov",
                    Gender = "male"
                },
                new Teacher()
                {
                    DateOfBirth = DateTime.Now,
                    FirstName = "Elena",
                    MiddleName = "Viktorovna",
                    LastName = "Fomenko",
                    Gender = "female"
                },
            };
            foreach (var item in teachers)
            {
                context.Teachers.AddOrUpdate(i => i.LastName, item);
            }
            context.SaveChanges();

            //Classrooms
            List<Classroom> classrooms = new List<Classroom>()
            {
                new Classroom() { Capacity = 15, Type = "lab", Number = "3/14" },
                new Classroom() { Capacity = 15, Type = "lab", Number = "3/15" },
                new Classroom() { Capacity = 30, Type = "pr", Number = "3/44" },
                new Classroom() { Capacity = 20, Type = "pr", Number = "3/47" },
                new Classroom() { Capacity = 50, Type = "lec", Number = "3/45" },
                new Classroom() { Capacity = 60, Type = "lec", Number = "3/24" },
            };
            foreach (var item in classrooms)
            {
                context.Classrooms.AddOrUpdate(i => i.Number, item);
            }
            context.SaveChanges();

            //Classrooms
            List<Lesson> lessons = new List<Lesson>()
            {
                new Lesson() {Title = "Programming"},
                new Lesson() {Title = "OS"},
                new Lesson() {Title = "DU"},
                new Lesson() {Title = "Mathematical analysis"},
                new Lesson() {Title = "Data protection"},
            };
            foreach (var item in lessons)
            {
                context.Lessons.AddOrUpdate(i => i.Title, item);
            }
            context.SaveChanges();

            //Form3
            List<Form3> form3s = new List<Form3>()
            {
                new Form3() { TeacherId = teachers[0].Id, LessonId = lessons[0].Id},
                new Form3() { TeacherId = teachers[0].Id, LessonId = lessons[1].Id},
                new Form3() { TeacherId = teachers[0].Id, LessonId = lessons[2].Id},
                new Form3() { TeacherId = teachers[1].Id, LessonId = lessons[1].Id},
                new Form3() { TeacherId = teachers[1].Id, LessonId = lessons[2].Id},
                new Form3() { TeacherId = teachers[1].Id, LessonId = lessons[3].Id},
            };
            foreach (var item in form3s)
            {
                context.Form3s.AddOrUpdate(item);
            }
            context.SaveChanges();

            //Semester
            List<Semester> semesters = new List<Semester>()
            {
                new Semester() {StartsOn = DateTime.Parse("2016-02-01"), EndsOn = DateTime.Parse("2016-05-01")},
            };
            foreach (var item in semesters)
            {
                context.Semesters.AddOrUpdate(i => i.StartsOn, item);
            }
            context.SaveChanges();

            //Schedule
            List<Models.ScheduleItem> schedules = new List<Models.ScheduleItem>()
            {
                new Models.ScheduleItem()
                {
                    LessonId = lessons[0].Id,
                    TeacherId = teachers[0].Id,
                    ClassroomId = classrooms[0].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 1,
                    GroupId = groups[0].Id,
                    LessonFrequency = LessonFrequency.Constant
                },
                new Models.ScheduleItem()
                {
                    LessonId = lessons[1].Id,
                    TeacherId = teachers[2].Id,
                    ClassroomId = classrooms[3].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 2,
                    GroupId = groups[0].Id,
                    LessonFrequency = LessonFrequency.Nominator
                },
                new Models.ScheduleItem()
                {
                    LessonId = lessons[2].Id,
                    TeacherId = teachers[1].Id,
                    ClassroomId = classrooms[2].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 2,
                    GroupId = groups[0].Id,
                    LessonFrequency = LessonFrequency.Denominator
                },
            };
            foreach (var item in schedules)
            {
                //context.ScheduleItems.AddOrUpdate(item);
                context.ScheduleItems.Add(item);
            }
            context.SaveChanges();

//            //GroupWorkload
//            List<GroupWorkload> groupWorkloads = new List<GroupWorkload>()
//            {
//                new GroupWorkload()
//                {
//                    GroupId = ,
//                    LessonId = ,
//                    Hours = 5,
//                    LessonType = "lection"
//                },
//            };
//            foreach (var item in lessons)
//            {
//                context.Lessons.AddOrUpdate(i => i.Title, item);
//            }
//            context.SaveChanges();

            base.Seed(context);
        } 
    }
}