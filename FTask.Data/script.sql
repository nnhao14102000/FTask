USE [master]
GO
/****** Object:  Database [FTask]    Script Date: 19/06/2021 12:46:36 CH ******/
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
/****** Object:  Table [dbo].[Major]    Script Date: 19/06/2021 12:46:36 CH ******/
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
/****** Object:  Table [dbo].[PlanSemester]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanSemester](
	[PlanSemesterId] [int] IDENTITY(1,1) NOT NULL,
	[PlanSemesterName] [nvarchar](50) NULL,
	[StudentId] [nvarchar](20) NOT NULL,
	[SemesterId] [nvarchar](10) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsComplete] [bit] NOT NULL,
 CONSTRAINT [PK__PlanSeme__633CF023DBA907AC] PRIMARY KEY CLUSTERED 
(
	[PlanSemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanSubject]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanSubject](
	[PlanSubjectId] [int] IDENTITY(1,1) NOT NULL,
	[Priority] [int] NULL,
	[Progress] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsComplete] [bit] NOT NULL,
	[PlanSemesterId] [int] NOT NULL,
	[SubjectId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK__PlanSubj__BC02B4F0EE63952C] PRIMARY KEY CLUSTERED 
(
	[PlanSubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanTopic]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanTopic](
	[PlanTopicId] [int] IDENTITY(1,1) NOT NULL,
	[Progress] [int] NULL,
	[IsComplete] [bit] NOT NULL,
	[TopicId] [int] NOT NULL,
	[PlanSubjectId] [int] NOT NULL,
 CONSTRAINT [PK__PlanTopi__1E0255363D627E85] PRIMARY KEY CLUSTERED 
(
	[PlanTopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[SemesterId] [nvarchar](10) NOT NULL,
	[SemesterName] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsComplete] [bit] NOT NULL,
 CONSTRAINT [PK__Semester__043301DD18E1725F] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [nvarchar](20) NOT NULL,
	[StudentName] [nvarchar](50) NOT NULL,
	[StudentEmail] [nvarchar](50) NOT NULL,
	[MajorId] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__Student__32C52B993DCBE7AA] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [nvarchar](10) NOT NULL,
	[SubjectName] [nvarchar](50) NOT NULL,
	[Source] [nvarchar](50) NULL,
	[SubjectGroupId] [int] NOT NULL,
 CONSTRAINT [PK__Subject__AC1BA3A8CB9A123C] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectGroup]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectGroup](
	[SubjectGroupId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectGroupName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__SubjectG__2F88B036A0937DA8] PRIMARY KEY CLUSTERED 
(
	[SubjectGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskDecription] [nvarchar](200) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[EstimateTime] [bigint] NULL,
	[EffortTime] [bigint] NULL,
	[DueDate] [datetime] NULL,
	[Priority] [int] NULL,
	[IsComplete] [bit] NOT NULL,
	[PlanTopicId] [int] NOT NULL,
	[TaskCategoryId] [int] NOT NULL,
 CONSTRAINT [PK__Task__7C6949B1973725C4] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskCategory]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskCategory](
	[TaskCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[TaskType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__TaskCate__FEB1EA2EDFC0CDED] PRIMARY KEY CLUSTERED 
(
	[TaskCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 19/06/2021 12:46:36 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[TopicId] [int] IDENTITY(1,1) NOT NULL,
	[TopicName] [nvarchar](50) NOT NULL,
	[TopicDescription] [nvarchar](200) NULL,
	[SubjectId] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BBA_FIN', N'Business Administration_Finance')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BBA_IB', N'Business Administration_International Business')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BBA_MC', N'Business Administration_Multimedia communication')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BBA_MKT', N'Business Administration_Marketing')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BEL', N'English Language')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BEN', N'English Language')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BGD', N'	Graphic Design')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BIT_AI', N'Bachelor of Information technology')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BIT_GD', N'Information technology_Digital art designr')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BIT_IA', N'Bachelor of Information technology')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BIT_IoT', N'Bachelor of Information technology')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BIT_IS', N'Bachelor of Information technology')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BIT_SE', N'Bachelor of Information technology ')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BJP', N'Bachelor of Japanese Language')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BKR', N'Bachelor of Korean Language ')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'BMC', N'Multimedia Communication')
GO
INSERT [dbo].[Major] ([MajorId], [MajorName]) VALUES (N'SBBA_HM', N'Business Adminstration_Hotel Management')
GO
SET IDENTITY_INSERT [dbo].[PlanSemester] ON 
GO
INSERT [dbo].[PlanSemester] ([PlanSemesterId], [PlanSemesterName], [StudentId], [SemesterId], [CreateDate], [IsComplete]) VALUES (1, N'PassAllSubject', N'SE140129', N'Fall_21', CAST(N'2021-06-18T03:35:39.323' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[PlanSemester] OFF
GO
SET IDENTITY_INSERT [dbo].[PlanSubject] ON 
GO
INSERT [dbo].[PlanSubject] ([PlanSubjectId], [Priority], [Progress], [CreateDate], [IsComplete], [PlanSemesterId], [SubjectId]) VALUES (1, 0, 0, CAST(N'2021-06-18T03:34:59.403' AS DateTime), 0, 1, N'PRJ311')
GO
SET IDENTITY_INSERT [dbo].[PlanSubject] OFF
GO
SET IDENTITY_INSERT [dbo].[PlanTopic] ON 
GO
INSERT [dbo].[PlanTopic] ([PlanTopicId], [Progress], [IsComplete], [TopicId], [PlanSubjectId]) VALUES (1, 0, 0, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[PlanTopic] OFF
GO
INSERT [dbo].[Semester] ([SemesterId], [SemesterName], [StartDate], [EndDate], [IsComplete]) VALUES (N'Fall_21', N'Fall 2021', CAST(N'2021-06-13T06:58:49.157' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Semester] ([SemesterId], [SemesterName], [StartDate], [EndDate], [IsComplete]) VALUES (N'SPR_21', N'Spring 2021', NULL, NULL, 0)
GO
INSERT [dbo].[Semester] ([SemesterId], [SemesterName], [StartDate], [EndDate], [IsComplete]) VALUES (N'SUM_21', N'Summer 2021', NULL, NULL, 0)
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SA100000', N'Huynh Thanh Nhat', N'Nhathtsa100000@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SA100001', N'Trần Văn Kiên', N'Kientvsa100001@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SA100002', N'Nguyễn Nhật Hào', N'HaoNHsa100002@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE130059', N'Pham Hà Hoàng Nam', N'NamPHHSE130059@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE130157', N'Nguyễn Đức Thắng', N'ThangNDSE130157@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE130221', N'Nguyễn Tấn Sang', N'SangNTSE130221@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE140026', N'Nguyễn Tấn Sang', N'SangNTSE140026@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE140108', N'Lê Minh Hiếu', N'HieuLMSE140108@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE140117', N'Lê Bảo Long', N'LongLBSE140117@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE140129', N'Đàm Đông Tín', N'TinDDSE140129@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE140133', N'Vũ Quý Hậu', N'HauVQSE140133@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE140297', N'Nguyễn Quang Vinh', N'VinhNQSE140297@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE140329', N'Nguyễn Minh Trí', N'TriNMSE140329@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE62198', N'Nguyễn Minh Hiếu', N'hieunmse62198@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE62732', N'Dương Đình Nguyên', N'nguyenddse62732@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE62733', N'Võ Minh Quân', N'QuanVMSS150380@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE63295', N'Lê Kha', N'nguyenddse62732@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SE65733', N'Võ Minh Quân', N'QuanVMSS150380@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SS140179', N'Nguyễn Quỳnh Hương', N'HuongNQSS140179@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SS140321', N'Dương Quý Bảo', N'BaoDQSS140321@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SS140367', N'Trần Quốc Bảo', N'BaoTQSS140367@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SS150187', N'Phạm Văn Đạt', N'DatPVSS150187@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SS150324', N'Nguyễn Quốc Khải', N'KhaiNQSS150324@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [MajorId]) VALUES (N'SS150380', N'Võ Minh Quân', N'QuanVMSS150380@fpt.edu.vn', N'BIT_SE')
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ADG301', N'Book and Packaging Design', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ADH301', N'Mobility Applications Design 1', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ADI201', N'Brand Identity Design', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ADT401', N'Mobility Applications Design 2', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'AET101', N' Aesthetic', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ANA401', N'3D Character Animation', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ANB401', N' Background Painting for Animation ', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ANC301', N'Character Development', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ANM301', N'3D Modeling & Texturing', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ANR401', N'3D Introduction to Rigging', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ANS301', N'3D Character Animation', N'BBB', 4)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'CEA201', N'Computer Organization and Architectureg', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'CSD201', N'Data Structure and Algorithm ', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'CSD301 ', N'Advanced Algorithms', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'CSI104', N'Introduction to Computing', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'DBI202', N'Database Systems ', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ECO101', N'Micro economics', N'BBB', 5)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ECO102', N'Business Environment', N'BBB', 5)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ECO111', N'Basic Microeconomics', N'BBB', 5)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ECO121', N'Basic Macroeconomics', N'BBB', 5)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'ECO201', N'International Economics', N'BBB', 5)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'FIN201', N'Monetary Economics and Global Economy', N'BBB', 5)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'IOT102', N'Internet of Things', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'JFE301', N'JITF ', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'LAB101', N'Basic Practicing', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'LAB2', N'OOP With Java', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'LAB211', N'Pre-intermediate Practicing', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'LAB221', N'Intermediate Practicing', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'LAB231', N'Web Java Lab', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'NWC203c', N'Mạng máy tính ', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'OSG202', N'Operating System', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'PRE201', N'Excel Programming', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'PRF192', N'Programming Fundamentals Using C', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'PRJ301', N'Java Web Application', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'PRJ311', N'Desktop Java Applications', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'PRN292', N'C# & Dot Net', N'AAA', 1)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Source], [SubjectGroupId]) VALUES (N'PRO192', N'Object-Oriented Paradigm using Java', N'AAA', 1)
GO
SET IDENTITY_INSERT [dbo].[SubjectGroup] ON 
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (1, N'Computing Fundamentals')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (2, N'Accounting')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (3, N'Chính Trị')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (4, N'Digital Art & Design')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (5, N'Economics')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (6, N'Finance')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (7, N'General Management')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (8, N'Information Assurance')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (9, N'International Business')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (10, N'Japanese')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (11, N'Marketing')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (12, N'Mathematics')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (13, N'Software Engineering')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (14, N'English')
GO
INSERT [dbo].[SubjectGroup] ([SubjectGroupId], [SubjectGroupName]) VALUES (15, N'Multiple Media Communication	')
GO
SET IDENTITY_INSERT [dbo].[SubjectGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskCategory] ON 
GO
INSERT [dbo].[TaskCategory] ([TaskCategoryId], [TaskType]) VALUES (2, N'Quiz')
GO
SET IDENTITY_INSERT [dbo].[TaskCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Topic] ON 
GO
INSERT [dbo].[Topic] ([TopicId], [TopicName], [TopicDescription], [SubjectId]) VALUES (0, N'Linked List', N'Learn a bout linked list and compare with array...', N'CSD201')
GO
INSERT [dbo].[Topic] ([TopicId], [TopicName], [TopicDescription], [SubjectId]) VALUES (1, N'Array', N'Learn about Array', N'CSD201')
GO
INSERT [dbo].[Topic] ([TopicId], [TopicName], [TopicDescription], [SubjectId]) VALUES (4, N'Collection', N'Learn about list and arraylist', N'PRO192')
GO
SET IDENTITY_INSERT [dbo].[Topic] OFF
GO
ALTER TABLE [dbo].[PlanSemester]  WITH CHECK ADD  CONSTRAINT [FK__PlanSemes__Semes__37A5467C] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([SemesterId])
GO
ALTER TABLE [dbo].[PlanSemester] CHECK CONSTRAINT [FK__PlanSemes__Semes__37A5467C]
GO
ALTER TABLE [dbo].[PlanSemester]  WITH CHECK ADD  CONSTRAINT [FK__PlanSemes__Stude__38996AB5] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[PlanSemester] CHECK CONSTRAINT [FK__PlanSemes__Stude__38996AB5]
GO
ALTER TABLE [dbo].[PlanSubject]  WITH CHECK ADD  CONSTRAINT [FK__PlanSubje__PlanS__398D8EEE] FOREIGN KEY([PlanSemesterId])
REFERENCES [dbo].[PlanSemester] ([PlanSemesterId])
GO
ALTER TABLE [dbo].[PlanSubject] CHECK CONSTRAINT [FK__PlanSubje__PlanS__398D8EEE]
GO
ALTER TABLE [dbo].[PlanSubject]  WITH CHECK ADD  CONSTRAINT [FK__PlanSubje__Subje__3A81B327] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[PlanSubject] CHECK CONSTRAINT [FK__PlanSubje__Subje__3A81B327]
GO
ALTER TABLE [dbo].[PlanTopic]  WITH CHECK ADD  CONSTRAINT [FK__PlanTopic__PlanS__3B75D760] FOREIGN KEY([PlanSubjectId])
REFERENCES [dbo].[PlanSubject] ([PlanSubjectId])
GO
ALTER TABLE [dbo].[PlanTopic] CHECK CONSTRAINT [FK__PlanTopic__PlanS__3B75D760]
GO
ALTER TABLE [dbo].[PlanTopic]  WITH CHECK ADD  CONSTRAINT [FK_PlanTopic_Topic] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topic] ([TopicId])
GO
ALTER TABLE [dbo].[PlanTopic] CHECK CONSTRAINT [FK_PlanTopic_Topic]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK__Student__MajorId__3D5E1FD2] FOREIGN KEY([MajorId])
REFERENCES [dbo].[Major] ([MajorId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK__Student__MajorId__3D5E1FD2]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK__Subject__Subject__3E52440B] FOREIGN KEY([SubjectGroupId])
REFERENCES [dbo].[SubjectGroup] ([SubjectGroupId])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK__Subject__Subject__3E52440B]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK__Task__PlanTopicI__5BE2A6F2] FOREIGN KEY([PlanTopicId])
REFERENCES [dbo].[PlanTopic] ([PlanTopicId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK__Task__PlanTopicI__5BE2A6F2]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK__Task__TaskCatego__5CD6CB2B] FOREIGN KEY([TaskCategoryId])
REFERENCES [dbo].[TaskCategory] ([TaskCategoryId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK__Task__TaskCatego__5CD6CB2B]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_Topic_Subject]
GO
USE [master]
GO
ALTER DATABASE [FTask] SET  READ_WRITE 
GO
