USE [master]
GO
/****** Object:  Database [FTask]    Script Date: 6/3/2021 8:30:37 PM ******/
CREATE DATABASE [FTask]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FTask', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FTask.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FTask_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FTask_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FTask] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FTask].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FTask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FTask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FTask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FTask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FTask] SET ARITHABORT OFF 
GO
ALTER DATABASE [FTask] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FTask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FTask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FTask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FTask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FTask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FTask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FTask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FTask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FTask] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FTask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FTask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FTask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FTask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FTask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FTask] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FTask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FTask] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FTask] SET  MULTI_USER 
GO
ALTER DATABASE [FTask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FTask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FTask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FTask] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FTask] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FTask] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FTask] SET QUERY_STORE = OFF
GO
USE [FTask]
GO
/****** Object:  Table [dbo].[Major]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Major](
	[MajorId] [nvarchar](20) NOT NULL,
	[MajorName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MajorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanSemester]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanSemester](
	[PlanSemesterId] [int] IDENTITY(1,1) NOT NULL,
	[PlanSemesterName] [nvarchar](50) NULL,
	[StudentId] [nvarchar](20) NULL,
	[SemesterId] [nvarchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PlanSemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanSubject]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanSubject](
	[PlanSubjectId] [int] IDENTITY(1,1) NOT NULL,
	[Priority] [int] NULL,
	[Progress] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[Statsus] [int] NULL,
	[PlanSemesterId] [int] NOT NULL,
	[SubjectId] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlanSubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanTopic]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanTopic](
	[PlanTopicId] [int] IDENTITY(1,1) NOT NULL,
	[Progress] [int] NULL,
	[Status] [int] NULL,
	[TopicId] [int] NOT NULL,
	[PlanSubjectId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlanTopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[SemesterId] [nvarchar](10) NOT NULL,
	[SemesterName] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [nvarchar](20) NOT NULL,
	[StudentName] [nvarchar](50) NOT NULL,
	[StudentEmail] [nvarchar](50) NOT NULL,
	[MajorId] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [nvarchar](10) NOT NULL,
	[SubjectName] [nvarchar](50) NOT NULL,
	[Source] [nvarchar](50) NULL,
	[SubjectGroupId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectGroup]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectGroup](
	[SubjectGroupId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectGroupName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[Decription] [nvarchar](100) NULL,
	[CreateDate] [datetime] NOT NULL,
	[EstimateTime] [bigint] NULL,
	[EffortTime] [bigint] NULL,
	[Priority] [int] NULL,
	[Status] [int] NULL,
	[PlanTopicId] [int] NULL,
	[TaskCategoryId] [int] NULL,
 CONSTRAINT [PK__Task__7C6949B1F726E602] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskCategory]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskCategory](
	[TaskCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[TaskeType] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 6/3/2021 8:30:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[TopicId] [int] IDENTITY(1,1) NOT NULL,
	[TopicName] [nvarchar](50) NOT NULL,
	[Decription] [nvarchar](200) NULL,
	[SubjectId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK__Topic__022E0F5D074F43E6] PRIMARY KEY CLUSTERED 
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PlanSemester]  WITH CHECK ADD FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([SemesterId])
GO
ALTER TABLE [dbo].[PlanSemester]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[PlanSubject]  WITH CHECK ADD FOREIGN KEY([PlanSemesterId])
REFERENCES [dbo].[PlanSemester] ([PlanSemesterId])
GO
ALTER TABLE [dbo].[PlanSubject]  WITH CHECK ADD FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[PlanTopic]  WITH CHECK ADD FOREIGN KEY([PlanSubjectId])
REFERENCES [dbo].[PlanSubject] ([PlanSubjectId])
GO
ALTER TABLE [dbo].[PlanTopic]  WITH CHECK ADD  CONSTRAINT [FK__PlanTopic__Topic__5AEE82B9] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topic] ([TopicId])
GO
ALTER TABLE [dbo].[PlanTopic] CHECK CONSTRAINT [FK__PlanTopic__Topic__5AEE82B9]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([MajorId])
REFERENCES [dbo].[Major] ([MajorId])
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD FOREIGN KEY([SubjectGroupId])
REFERENCES [dbo].[SubjectGroup] ([SubjectGroupId])
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK__Task__PlanTopicI__5EBF139D] FOREIGN KEY([PlanTopicId])
REFERENCES [dbo].[PlanTopic] ([PlanTopicId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK__Task__PlanTopicI__5EBF139D]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK__Task__TaskCatego__5FB337D6] FOREIGN KEY([TaskCategoryId])
REFERENCES [dbo].[TaskCategory] ([TaskCategoryId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK__Task__TaskCatego__5FB337D6]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK__Topic__SubjectId__52593CB8] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK__Topic__SubjectId__52593CB8]
GO
USE [master]
GO
ALTER DATABASE [FTask] SET  READ_WRITE 
GO
