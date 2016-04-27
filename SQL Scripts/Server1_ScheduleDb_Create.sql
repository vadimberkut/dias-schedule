USE [master]
GO
/****** Object:  Database [ScheduleDb]    Script Date: 25.04.2016 16:08:41 ******/
CREATE DATABASE [ScheduleDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ScheduleDb.mdf', FILENAME = N'D:\Study\Розподілені інформаційно-аналітичні системи\dias-schedule\ScheduleApp\ScheduleApp\App_Data\Server1\ScheduleDb.mdf' , SIZE = 6136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ScheduleDb_log.ldf', FILENAME = N'D:\Study\Розподілені інформаційно-аналітичні системи\dias-schedule\ScheduleApp\ScheduleApp\App_Data\Server1\ScheduleDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ScheduleDb] SET COMPATIBILITY_LEVEL = 110

USE [ScheduleDb]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ScheduleDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ScheduleDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ScheduleDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ScheduleDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ScheduleDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ScheduleDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ScheduleDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ScheduleDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ScheduleDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ScheduleDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ScheduleDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ScheduleDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ScheduleDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ScheduleDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ScheduleDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ScheduleDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ScheduleDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ScheduleDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ScheduleDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ScheduleDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ScheduleDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ScheduleDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ScheduleDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ScheduleDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ScheduleDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ScheduleDb] SET  MULTI_USER 
GO
ALTER DATABASE [ScheduleDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ScheduleDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ScheduleDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ScheduleDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ScheduleDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ScheduleAccessMode] [int] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Classrooms_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classrooms_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Number] [nvarchar](max) NULL,
	[Available] [bit] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Classrooms_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Form3_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Form3_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[LessonType] [int] NOT NULL,
	[Hours] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Form3_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Groups_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*CREATE TABLE [dbo].[Groups_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[StudentsAmount] [int] NOT NULL,
	[Course] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Groups_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]*/

CREATE TABLE [dbo].[Groups_1](
  [Id] [int] IDENTITY(1,1) NOT NULL CHECK (CustomerID BETWEEN 1 AND 50), /*CHECK ([Id] BETWEEN 1 AND 9) ,*/
  [Title] [nvarchar](max) NULL,
  [StudentsAmount] [int] NOT NULL,
  [Course] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Groups_1] PRIMARY KEY CLUSTERED
(
  [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupWorkloads_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupWorkloads_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[LessonType] [int] NOT NULL,
	[Hours] [int] NOT NULL,
 CONSTRAINT [PK_dbo.GroupWorkloads_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lessons_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Lessons_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Restrictions_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restrictions_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Value] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Restrictions_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ScheduleItems_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleItems_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[LessonId] [int] NOT NULL,
	[LessonType] [int] NOT NULL,
	[ClassroomId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[DayOfWeek] [nvarchar](max) NULL,
	[LessonNumber] [int] NOT NULL,
	[LessonFrequency] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ScheduleItems_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semesters_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartsOn] [datetime] NOT NULL,
	[EndsOn] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Semesters_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teachers_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[DateOfBirth] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Teachers_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TeacherWorkloads_1]    Script Date: 25.04.2016 18:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherWorkloads_1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[PerWeek] [int] NOT NULL,
	[PerYear] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TeacherWorkloads_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_Id]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[AspNetUserClaims]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LessonId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_LessonId] ON [dbo].[Form3_1]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_TeacherId] ON [dbo].[Form3_1]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_GroupId] ON [dbo].[GroupWorkloads_1]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LessonId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_LessonId] ON [dbo].[GroupWorkloads_1]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassroomId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_ClassroomId] ON [dbo].[ScheduleItems_1]
(
	[ClassroomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_GroupId] ON [dbo].[ScheduleItems_1]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LessonId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_LessonId] ON [dbo].[ScheduleItems_1]
(
	[LessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SemesterId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_SemesterId] ON [dbo].[ScheduleItems_1]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_TeacherId] ON [dbo].[ScheduleItems_1]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherId]    Script Date: 25.04.2016 18:57:38 ******/
CREATE NONCLUSTERED INDEX [IX_TeacherId] ON [dbo].[TeacherWorkloads_1]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Form3_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Form3_dbo.Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Form3_1] CHECK CONSTRAINT [FK_dbo.Form3_dbo.Lessons_LessonId]
GO
ALTER TABLE [dbo].[Form3_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Form3_dbo.Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Form3_1] CHECK CONSTRAINT [FK_dbo.Form3_dbo.Teachers_TeacherId]
GO
ALTER TABLE [dbo].[GroupWorkloads_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GroupWorkloads_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupWorkloads_1] CHECK CONSTRAINT [FK_dbo.GroupWorkloads_dbo.Groups_GroupId]
GO
ALTER TABLE [dbo].[GroupWorkloads_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.GroupWorkloads_dbo.Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GroupWorkloads_1] CHECK CONSTRAINT [FK_dbo.GroupWorkloads_dbo.Lessons_LessonId]
GO
ALTER TABLE [dbo].[ScheduleItems_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ScheduleItems_dbo.Classrooms_ClassroomId] FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classrooms_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScheduleItems_1] CHECK CONSTRAINT [FK_dbo.ScheduleItems_dbo.Classrooms_ClassroomId]
GO
ALTER TABLE [dbo].[ScheduleItems_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ScheduleItems_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScheduleItems_1] CHECK CONSTRAINT [FK_dbo.ScheduleItems_dbo.Groups_GroupId]
GO
ALTER TABLE [dbo].[ScheduleItems_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ScheduleItems_dbo.Lessons_LessonId] FOREIGN KEY([LessonId])
REFERENCES [dbo].[Lessons_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScheduleItems_1] CHECK CONSTRAINT [FK_dbo.ScheduleItems_dbo.Lessons_LessonId]
GO
ALTER TABLE [dbo].[ScheduleItems_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ScheduleItems_dbo.Semesters_SemesterId] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScheduleItems_1] CHECK CONSTRAINT [FK_dbo.ScheduleItems_dbo.Semesters_SemesterId]
GO
ALTER TABLE [dbo].[ScheduleItems_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ScheduleItems_dbo.Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScheduleItems_1] CHECK CONSTRAINT [FK_dbo.ScheduleItems_dbo.Teachers_TeacherId]
GO
ALTER TABLE [dbo].[TeacherWorkloads_1]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TeacherWorkloads_dbo.Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers_1] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherWorkloads_1] CHECK CONSTRAINT [FK_dbo.TeacherWorkloads_dbo.Teachers_TeacherId]
GO
USE [master]
GO
ALTER DATABASE [ScheduleDb] SET  READ_WRITE 
GO
