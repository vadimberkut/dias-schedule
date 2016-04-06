using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScheduleApp.Models;

namespace ScheduleApp.Context
{
    public class ApplicationDbContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //public class ApplicationDbContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //Users
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var role = roleManager.FindByName("Admin");
            if (role == null)
            {
                role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            var adminUser = userManager.FindByName("admin");
            if (adminUser == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "admin"
                };
                var result = userManager.Create(newUser, "111111");
                if (result.Succeeded)
                {
                    //userManager.SetLockoutEnabled(newUser.Id, false);
                    userManager.AddToRole(newUser.Id, "Admin");
                }
            }

            List<Group> groups = new List<Group>()
            {
                new Group() {Title = "ПК-15-1", StudentsAmount = 33, Course = 1},
                new Group() {Title = "ПК-15-2", StudentsAmount = 22, Course = 1},
                new Group() {Title = "ПМ-15-1", StudentsAmount = 12, Course = 1},
                new Group() {Title = "ПМ-15-2", StudentsAmount = 13, Course = 1},
                new Group() {Title = "ПЗ-15-1", StudentsAmount = 24, Course = 1},
                new Group() {Title = "ПЗ-15-2", StudentsAmount = 21, Course = 1},
                new Group() {Title = "ПС-15-1", StudentsAmount = 13, Course = 1},
                new Group() {Title = "ПС-15-2", StudentsAmount = 42, Course = 1},

                new Group() {Title = "ПК-14-1", StudentsAmount = 31, Course = 2},
                new Group() {Title = "ПК-14-2", StudentsAmount = 22, Course = 2},
                new Group() {Title = "ПМ-14-1", StudentsAmount = 13, Course = 2},
                new Group() {Title = "ПМ-14-2", StudentsAmount = 24, Course = 2},
                new Group() {Title = "ПЗ-14-1", StudentsAmount = 21, Course = 2},
                new Group() {Title = "ПЗ-14-2", StudentsAmount = 22, Course = 2},
                new Group() {Title = "ПС-14-1", StudentsAmount = 13, Course = 2},
                new Group() {Title = "ПС-14-2", StudentsAmount = 24, Course = 2},

                new Group() {Title = "ПК-13-1", StudentsAmount = 20, Course = 3},
                new Group() {Title = "ПК-13-2", StudentsAmount = 11, Course = 3},
                new Group() {Title = "ПМ-13-1", StudentsAmount = 12, Course = 3},
                new Group() {Title = "ПМ-13-2", StudentsAmount = 21, Course = 3},
                new Group() {Title = "ПЗ-13-1", StudentsAmount = 14, Course = 3},
                new Group() {Title = "ПЗ-13-2", StudentsAmount = 12, Course = 3},
                new Group() {Title = "ПС-13-1", StudentsAmount = 15, Course = 3},
                new Group() {Title = "ПС-13-2", StudentsAmount = 22, Course = 3},

                new Group() {Title = "ПК-12-1", StudentsAmount = 18, Course = 4},
                new Group() {Title = "ПК-12-2", StudentsAmount = 16, Course = 4},
                new Group() {Title = "ПМ-12-1", StudentsAmount = 15, Course = 4},
                new Group() {Title = "ПМ-12-2", StudentsAmount = 25, Course = 4},
                new Group() {Title = "ПЗ-12-1", StudentsAmount = 21, Course = 4},
                new Group() {Title = "ПЗ-12-2", StudentsAmount = 20, Course = 4},
                new Group() {Title = "ПС-12-1", StudentsAmount = 16, Course = 4},
                new Group() {Title = "ПС-12-2", StudentsAmount = 21, Course = 4},

                new Group() {Title = "ПК-11м-1", StudentsAmount = 13, Course = 5},
                new Group() {Title = "ПМ-11м-1", StudentsAmount = 10, Course = 5},
                new Group() {Title = "ПЗ-11м-1", StudentsAmount = 8, Course = 5},
                new Group() {Title = "ПС-11м-1", StudentsAmount = 6, Course = 5},
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
                new Teacher()
                {
                    DateOfBirth = DateTime.Now,
                    FirstName = "Nikita",
                    MiddleName = "Olegovich",
                    LastName = "Zarev",
                    Gender = "male"
                },
                new Teacher()
                {
                    DateOfBirth = DateTime.Now,
                    FirstName = "Oleg",
                    MiddleName = "Ivanovich",
                    LastName = "Branev",
                    Gender = "male"
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
                new Classroom() { Capacity = 10, Type = ClassroomType.Lab, Number = "3/41" },
                new Classroom() { Capacity = 10, Type = ClassroomType.Lab, Number = "3/42" },
                new Classroom() { Capacity = 15, Type = ClassroomType.Lab, Number = "3/43" },
                new Classroom() { Capacity = 15, Type = ClassroomType.Lab, Number = "3/44" },
                new Classroom() { Capacity = 8, Type = ClassroomType.Lab, Number = "3/45" },
                new Classroom() { Capacity = 8, Type = ClassroomType.Lab, Number = "3/46" },
                new Classroom() { Capacity = 16, Type = ClassroomType.Lab, Number = "3/47" },
                new Classroom() { Capacity = 16, Type = ClassroomType.Lab, Number = "3/48" },

                new Classroom() { Capacity = 20, Type = ClassroomType.Prac, Number = "3/31" },
                new Classroom() { Capacity = 20, Type = ClassroomType.Prac, Number = "3/32" },
                new Classroom() { Capacity = 24, Type = ClassroomType.Prac, Number = "3/33" },
                new Classroom() { Capacity = 28, Type = ClassroomType.Prac, Number = "3/34" },
                new Classroom() { Capacity = 30, Type = ClassroomType.Prac, Number = "3/35" },
                new Classroom() { Capacity = 30, Type = ClassroomType.Prac, Number = "3/36" },

                new Classroom() { Capacity = 30, Type = ClassroomType.Lec, Number = "3/21" },
                new Classroom() { Capacity = 35, Type = ClassroomType.Lec, Number = "3/22" },
                new Classroom() { Capacity = 50, Type = ClassroomType.Lec, Number = "3/23" },
                new Classroom() { Capacity = 60, Type = ClassroomType.Lec, Number = "3/24" },
                new Classroom() { Capacity = 60, Type = ClassroomType.Lec, Number = "3/25" },
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
                new Lesson() {Title = "Data protection"},
                new Lesson() {Title = "Design of software systems"},
                new Lesson() {Title = "Intelligent information systems"},
                new Lesson() {Title = "Distributed information-analytical systems"},
                new Lesson() {Title = "Differential equations"},
                new Lesson() {Title = "Elements of chaotic dynamics"},
                new Lesson() {Title = "Digital Image Processing"},
                new Lesson() {Title = "Computer graphics"},
            };
            foreach (var item in lessons)
            {
                context.Lessons.AddOrUpdate(i => i.Title, item);
            }
            context.SaveChanges();

            //Form3
            List<Form3> form3s = new List<Form3>()
            {
                new Form3() { TeacherId = teachers[0].Id, LessonId = lessons[0].Id, LessonType = LessonType.Lec, Hours = 10},
                new Form3() { TeacherId = teachers[0].Id, LessonId = lessons[1].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[0].Id, LessonId = lessons[2].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[0].Id, LessonId = lessons[3].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[0].Id, LessonId = lessons[4].Id, LessonType = LessonType.Lec, Hours = 1},

                new Form3() { TeacherId = teachers[1].Id, LessonId = lessons[0].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[1].Id, LessonId = lessons[1].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[1].Id, LessonId = lessons[2].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[1].Id, LessonId = lessons[3].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[1].Id, LessonId = lessons[4].Id, LessonType = LessonType.Lab, Hours = 1},

                new Form3() { TeacherId = teachers[2].Id, LessonId = lessons[3].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[2].Id, LessonId = lessons[3].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[2].Id, LessonId = lessons[3].Id, LessonType = LessonType.Prac, Hours = 1},
                new Form3() { TeacherId = teachers[2].Id, LessonId = lessons[4].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[2].Id, LessonId = lessons[4].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[2].Id, LessonId = lessons[4].Id, LessonType = LessonType.Prac, Hours = 1},
                new Form3() { TeacherId = teachers[2].Id, LessonId = lessons[5].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[2].Id, LessonId = lessons[5].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[2].Id, LessonId = lessons[5].Id, LessonType = LessonType.Prac, Hours = 1},

                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[5].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[5].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[6].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[6].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[7].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[7].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[8].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[8].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[9].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[3].Id, LessonId = lessons[9].Id, LessonType = LessonType.Lab, Hours = 1},

                new Form3() { TeacherId = teachers[4].Id, LessonId = lessons[8].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[4].Id, LessonId = lessons[8].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[4].Id, LessonId = lessons[8].Id, LessonType = LessonType.Prac, Hours = 1},
                new Form3() { TeacherId = teachers[4].Id, LessonId = lessons[9].Id, LessonType = LessonType.Lec, Hours = 1},
                new Form3() { TeacherId = teachers[4].Id, LessonId = lessons[9].Id, LessonType = LessonType.Lab, Hours = 1},
                new Form3() { TeacherId = teachers[4].Id, LessonId = lessons[9].Id, LessonType = LessonType.Prac, Hours = 1},
            };
            foreach (var item in form3s)
            {
                context.Form3s.AddOrUpdate(item);
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
//            foreach (var item in groupWorkloads)
//            {
//                //context.GroupsWorkload.AddOrUpdate(i => i.Title, item);
            //   context.GroupsWorkload.AddOrUpdate(item);
//            }
//            context.SaveChanges();

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
            List<ScheduleItem> schedules = new List<ScheduleItem>()
            {
                new ScheduleItem()
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
                new ScheduleItem()
                {
                    LessonId = lessons[1].Id,
                    TeacherId = teachers[1].Id,
                    ClassroomId = classrooms[3].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 2,
                    GroupId = groups[0].Id,
                    LessonFrequency = LessonFrequency.Nominator
                },
                new ScheduleItem()
                {
                    LessonId = lessons[2].Id,
                    TeacherId = teachers[2].Id,
                    ClassroomId = classrooms[2].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 3,
                    GroupId = groups[0].Id,
                    LessonFrequency = LessonFrequency.Denominator
                },
                new ScheduleItem()
                {
                    LessonId = lessons[3].Id,
                    TeacherId = teachers[3].Id,
                    ClassroomId = classrooms[3].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 4,
                    GroupId = groups[0].Id,
                    LessonFrequency = LessonFrequency.Denominator
                },
                new ScheduleItem()
                {
                    LessonId = lessons[4].Id,
                    TeacherId = teachers[4].Id,
                    ClassroomId = classrooms[3].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 5,
                    GroupId = groups[0].Id,
                    LessonFrequency = LessonFrequency.Constant
                },

                //тест макс занятий преподавателя
                new ScheduleItem()
                {
                    LessonId = lessons[0].Id,
                    TeacherId = teachers[0].Id,
                    ClassroomId = classrooms[0].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 1,
                    GroupId = groups[1].Id,
                    LessonFrequency = LessonFrequency.Constant
                },
                new ScheduleItem()
                {
                    LessonId = lessons[0].Id,
                    TeacherId = teachers[0].Id,
                    ClassroomId = classrooms[0].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 2,
                    GroupId = groups[1].Id,
                    LessonFrequency = LessonFrequency.Constant
                },
                new ScheduleItem()
                {
                    LessonId = lessons[0].Id,
                    TeacherId = teachers[0].Id,
                    ClassroomId = classrooms[0].Id,
                    SemesterId = semesters[0].Id,
                    LessonType = LessonType.Lec,
                    DayOfWeek = "Monday",
                    LessonNumber = 3,
                    GroupId = groups[1].Id,
                    LessonFrequency = LessonFrequency.Constant
                },

            };
            foreach (var item in schedules)
            {
                //context.ScheduleItems.AddOrUpdate(item);
                context.ScheduleItems.Add(item);
            }
            context.SaveChanges();


            //Restrictions
            List<Restriction> restrictions = new List<Restriction>()
            {
                new Restriction()
                {
                    Name = "MaxLessonsPerDayForTeachers",
                    Type = RestrictionType.Integer,
                    Value = "3",
                    Description = "Max Lessons Per Day For Teachers",
                },
                new Restriction()
                {
                    Name = "MaxLessonsPerDayForStudents",
                    Type = RestrictionType.Integer,
                    Value = "4",
                    Description = "Max Lessons Per Day For Teachers",
                },
                new Restriction()
                {
                    Name = "SelfStudyDaysAmount",
                    Type = RestrictionType.Integer,
                    Value = "1",
                    Description = "",
                },
                new Restriction()
                {
                    Name = "SelfStudyDaysCourses",
                    Type = RestrictionType.List,
                    Value = "4,5",
                    Description = "",
                },

            };
            foreach (var item in restrictions)
            {
                context.Restrictions.AddOrUpdate(i => i.Name, item);
            }
            context.SaveChanges();

            base.Seed(context);
        } 
    }
}