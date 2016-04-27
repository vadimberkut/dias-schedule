GO
CREATE VIEW Classrooms AS
   SELECT * FROM ScheduleDb.dbo.Classrooms_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.Classrooms_2

GO
CREATE VIEW Form3 AS
   SELECT * FROM ScheduleDb.dbo.Form3_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.Form3_2


GO
CREATE VIEW Groups AS
   SELECT * FROM ScheduleDb.dbo.Groups_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.Groups_2

GO
CREATE VIEW GroupWorkloads AS
   SELECT * FROM ScheduleDb.dbo.GroupWorkloads_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.GroupWorkloads_2


GO
CREATE VIEW Lessons AS
   SELECT * FROM ScheduleDb.dbo.Lessons_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.Lessons_2


GO
CREATE VIEW Restrictions AS
   SELECT * FROM ScheduleDb.dbo.Restrictions_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.Restrictions_2


GO
CREATE VIEW ScheduleItems AS
   SELECT * FROM ScheduleDb.dbo.ScheduleItems_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.ScheduleItems_2

GO
CREATE VIEW Semesters AS
   SELECT * FROM ScheduleDb.dbo.Semesters_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.Semesters_2

GO
CREATE VIEW Teachers AS
   SELECT * FROM ScheduleDb.dbo.Teachers_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.Teachers_2


GO
CREATE VIEW TeacherWorkloads AS
   SELECT * FROM ScheduleDb.dbo.TeacherWorkloads_1
UNION ALL
   SELECT * FROM "VADIM-PK\MSSQLSERVER2".ScheduleDb.dbo.TeacherWorkloads_2


