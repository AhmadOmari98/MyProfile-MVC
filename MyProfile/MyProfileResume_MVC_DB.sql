USE [master]
GO
/****** Object:  Database [MyProfileResume_MVC]    Script Date: 3/16/2025 3:19:40 PM ******/
CREATE DATABASE [MyProfileResume_MVC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyProfileResume_MVC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyProfileResume_MVC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyProfileResume_MVC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyProfileResume_MVC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MyProfileResume_MVC] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyProfileResume_MVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyProfileResume_MVC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyProfileResume_MVC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyProfileResume_MVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyProfileResume_MVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyProfileResume_MVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyProfileResume_MVC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyProfileResume_MVC] SET  MULTI_USER 
GO
ALTER DATABASE [MyProfileResume_MVC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyProfileResume_MVC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyProfileResume_MVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyProfileResume_MVC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyProfileResume_MVC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyProfileResume_MVC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyProfileResume_MVC] SET QUERY_STORE = ON
GO
ALTER DATABASE [MyProfileResume_MVC] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MyProfileResume_MVC]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasicInfos]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasicInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](150) NOT NULL,
	[MiddleName] [nvarchar](150) NOT NULL,
	[LastName] [nvarchar](150) NOT NULL,
	[Position] [nvarchar](500) NOT NULL,
	[LinkLinkedin] [nvarchar](1000) NOT NULL,
	[LinkGitHub] [nvarchar](1000) NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Phone] [nvarchar](500) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[AboutMe] [nvarchar](4000) NOT NULL,
	[Birthday] [datetime2](7) NOT NULL,
	[ImagePath] [nvarchar](1000) NULL,
	[ResumeId] [int] NOT NULL,
 CONSTRAINT [PK_BasicInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Certifications]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](500) NOT NULL,
	[InstitutionName] [nvarchar](1000) NOT NULL,
	[InstitutionLogoPath] [nvarchar](1000) NULL,
	[Link] [nvarchar](1500) NOT NULL,
	[DateCourse] [datetime2](7) NOT NULL,
	[ResumeId] [int] NOT NULL,
 CONSTRAINT [PK_Certifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUss]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUss](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Email] [nvarchar](600) NOT NULL,
	[Phonenumber] [nvarchar](600) NOT NULL,
	[Subject] [nvarchar](4000) NOT NULL,
	[Message] [nvarchar](4000) NOT NULL,
	[Respond] [nvarchar](400) NULL,
	[ResumeId] [int] NOT NULL,
 CONSTRAINT [PK_ContactUss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Educations]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DegreeName] [nvarchar](500) NOT NULL,
	[SectionName] [nvarchar](500) NOT NULL,
	[Grade] [nvarchar](500) NOT NULL,
	[Institution] [nvarchar](1000) NOT NULL,
	[InstitutionLogoPath] [nvarchar](1000) NULL,
	[DateFrom] [datetime2](7) NOT NULL,
	[DateTo] [datetime2](7) NOT NULL,
	[ResumeId] [int] NOT NULL,
 CONSTRAINT [PK_Educations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experiences]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experiences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](500) NOT NULL,
	[Position] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](1000) NOT NULL,
	[CompanyLogoPath] [nvarchar](1000) NULL,
	[DateFrom] [datetime2](7) NOT NULL,
	[DateTo] [datetime2](7) NOT NULL,
	[ResumeId] [int] NOT NULL,
 CONSTRAINT [PK_Experiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageName] [nvarchar](500) NOT NULL,
	[ResumeId] [int] NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Others]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Others](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CvPath] [nvarchar](1000) NULL,
	[ImageSiteBarPath] [nvarchar](1000) NULL,
	[ResumeId] [int] NOT NULL,
 CONSTRAINT [PK_Others] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](1500) NOT NULL,
	[ProjectLogoPath] [nvarchar](1000) NULL,
	[DateFrom] [datetime2](7) NOT NULL,
	[DateTo] [datetime2](7) NOT NULL,
	[ResumeId] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resumes]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resumes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_resumes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 3/16/2025 3:19:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [nvarchar](500) NOT NULL,
	[CategoryName] [nvarchar](500) NOT NULL,
	[ResumeId] [int] NOT NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230125140059_Resume1', N'5.0.11')
GO
SET IDENTITY_INSERT [dbo].[BasicInfos] ON 

INSERT [dbo].[BasicInfos] ([Id], [FirstName], [MiddleName], [LastName], [Position], [LinkLinkedin], [LinkGitHub], [Email], [Phone], [Address], [AboutMe], [Birthday], [ImagePath], [ResumeId]) VALUES (1, N'Ahmad', N'M', N'AL-Omari', N'Full-Stack Web Developers', N'https://www.linkedin.com/in/ahmad-al-omari-37801b1ab', N'https://github.com/AhmadOmari98', N'AhmOmari@outlook.com', N'+962790061201', N'Irbid,Jordan', N'Full-Stack web developer. I have several projects, I love working in the web field, I have
experience in training students, Have fun programming problems solving: C++, Java, and
Python.
', CAST(N'1998-10-29T00:00:00.0000000' AS DateTime2), N'c5026e84-ceb2-47ff-b04c-21654b1b81b9_my1.jpg', 1)
SET IDENTITY_INSERT [dbo].[BasicInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[Certifications] ON 

INSERT [dbo].[Certifications] ([Id], [CourseName], [InstitutionName], [InstitutionLogoPath], [Link], [DateCourse], [ResumeId]) VALUES (1, N'C# ', N'Sololearn', N'7e3c1ae7-aace-4ed0-b714-768fa3a0e3ce_sololearn.jfif', N'https://drive.google.com/file/d/1o_UZ16wSbOuSA0swCfzrgt6VwPhGtzXD/view?usp=sharing', CAST(N'2022-11-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Certifications] ([Id], [CourseName], [InstitutionName], [InstitutionLogoPath], [Link], [DateCourse], [ResumeId]) VALUES (2, N'C# Developer ', N'Reed', N'aed1ea71-8ae9-4dde-a7ae-35a212063173_Reed.jfif', N'https://drive.google.com/file/d/1cIFOWDe0DWz7z8Jw7GLONx0IfdgbnEK6/view?usp=sharing', CAST(N'2022-09-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Certifications] ([Id], [CourseName], [InstitutionName], [InstitutionLogoPath], [Link], [DateCourse], [ResumeId]) VALUES (3, N'HTML Development', N'Orange Jordan', N'8d0a4128-c82e-4ed2-a32e-96e5b3474a04_Orange.jfif', N'https://drive.google.com/file/d/1Kgv1WgRu3gRsabM_cekb9Uty1x6lvxUf/view?usp=sharing', CAST(N'2022-09-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Certifications] ([Id], [CourseName], [InstitutionName], [InstitutionLogoPath], [Link], [DateCourse], [ResumeId]) VALUES (4, N'JavaScript ', N'Orange Jordan', N'f74b1e05-6e1d-419a-90a4-78bb9a1e1c64_Orange.jfif', N'https://drive.google.com/file/d/1dlHDfEDVUcZlvJXLJMuVh2jCtA8-7U1C/view?usp=sharing', CAST(N'2022-09-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Certifications] ([Id], [CourseName], [InstitutionName], [InstitutionLogoPath], [Link], [DateCourse], [ResumeId]) VALUES (5, N'Building Web Applications using PHP & MYSQL', N'MaharaTech - ITIMooca', N'f167fb4f-2fee-4be9-9e63-0b3276a370ea_MaharaTech - ITIMooca.jfif', N'https://drive.google.com/file/d/1gfYjd0xr-RnrkQ6IjPg5Z4zitUhfKCLn/view?usp=sharing', CAST(N'2022-08-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Certifications] ([Id], [CourseName], [InstitutionName], [InstitutionLogoPath], [Link], [DateCourse], [ResumeId]) VALUES (6, N'PHP Development ', N'Orange Jordan', N'8881d7c8-2714-40e7-9a3d-668baeba37b8_Orange.jfif', N'https://drive.google.com/file/d/12MQ223bdP3l1tPNLIFPxuFlZYreTn935/view?usp=sharing', CAST(N'2022-08-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Certifications] ([Id], [CourseName], [InstitutionName], [InstitutionLogoPath], [Link], [DateCourse], [ResumeId]) VALUES (7, N'Entrepreneurship', N'Cisco Networking Academy ©', N'783f8ec5-d370-4d94-be49-63d1063c284b_CiscoNetworkingAcademy.jfif', N'https://drive.google.com/file/d/17NhdxWz3-wETcTsSX5Sz4wOE1c_El4Mn/view?usp=sharing', CAST(N'2019-11-01T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Certifications] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactUss] ON 

INSERT [dbo].[ContactUss] ([Id], [Name], [Email], [Phonenumber], [Subject], [Message], [Respond], [ResumeId]) VALUES (22, N'Ahmad Omari', N'ahmadahmadomari624@gmail.com', N'0790061200', N'TEST', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', N'Yes', 1)
SET IDENTITY_INSERT [dbo].[ContactUss] OFF
GO
SET IDENTITY_INSERT [dbo].[Educations] ON 

INSERT [dbo].[Educations] ([Id], [DegreeName], [SectionName], [Grade], [Institution], [InstitutionLogoPath], [DateFrom], [DateTo], [ResumeId]) VALUES (1, N'Bachelor', N' Computer Science ', N'3.8 (Excellent)', N'Jordan University of Science & Technology (JUST)', N'31f3b146-ae0e-4a1d-bb72-88433de69e3a_JUST.png', CAST(N'2019-02-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-09-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Educations] ([Id], [DegreeName], [SectionName], [Grade], [Institution], [InstitutionLogoPath], [DateFrom], [DateTo], [ResumeId]) VALUES (2, N'High School Degree', N'Scientific', N'79% (Very Good)', N'Amjad Al Orouba School - İstanbul Branch', N'4d9122a5-d64b-4d55-bacd-8c580cb385f9_Amjad.jpg', CAST(N'2017-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2018-08-01T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Educations] OFF
GO
SET IDENTITY_INSERT [dbo].[Experiences] ON 

INSERT [dbo].[Experiences] ([Id], [CompanyName], [Position], [Description], [Address], [CompanyLogoPath], [DateFrom], [DateTo], [ResumeId]) VALUES (1, N'Tahaluf Al Emarat Technical Solutions', N'Full-Stack Web Developers -  Internship', N'Skills: Oracle SQL Developer, PL/SQL, C#, OOP, Web Page design (HTML, CSS, bootstrap, JavaScript), Agile Methodology Scrum Master Program, ASP.NET Core Web App (MVC), ASP.NET Core Web API, Angular', N'Irbid,Jordan - Remote', N'b472ecbf-43e8-4216-a336-88e57a2eb10e_Tahaluf.jpg', CAST(N'2022-07-25T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-12T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Experiences] OFF
GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([Id], [LanguageName], [ResumeId]) VALUES (1, N'Arabic (Mother Tongue) ', 1)
INSERT [dbo].[Languages] ([Id], [LanguageName], [ResumeId]) VALUES (2, N' English (Good)', 1)
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[Others] ON 

INSERT [dbo].[Others] ([Id], [CvPath], [ImageSiteBarPath], [ResumeId]) VALUES (1, N'4840fc92-1b45-4885-83d5-d5557249099c_Ahmad_Al-Omari_Latest_CV.pdf', N'efbcced1-d79b-495b-8c78-86ca95a362fc_my1.jpg', 1)
SET IDENTITY_INSERT [dbo].[Others] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([Id], [Name], [Description], [Link], [ProjectLogoPath], [DateFrom], [DateTo], [ResumeId]) VALUES (1, N'Herfa', N'It is a site that provides a link channel between craft owners and customers while preserving the rights of both parties. The site was created using (ASP.NET Core MVC, C# Programming Language, Oracle Database, HTML, CSS, JavaScript, Bootstrap).', N'https://ahmadomari98.github.io/Herfa/', N'eefc130d-47c1-4f3b-9b4e-62aedb84c354_Herfa.png', CAST(N'2022-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-31T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [Link], [ProjectLogoPath], [DateFrom], [DateTo], [ResumeId]) VALUES (2, N'Blood Bank System', N'Designed with (PHP, MySQL, Html, CSS, JavaScript, jQuery, Bootstrap).<br><br>
This system is a browser-based system designed to store, process, retrieve and analyze information related to administrative management and inventory management within the blood bank. therefore, this project aims to develop a system that preserves all information Related to blood donors and different blood units and help bank employees manage it in a better way.<br><br>
In short, the system requires from the donors to create an account on the website (blood bank) and book an appointment for donation. Then, the blood bank employee enters the blood unit into database. On the other side the recipients (hospitals) who have submitted a request to create an account with the blood bank, the request is will be either accepted or rejected by the employee, and in the case of acceptance, the recipients (hospitals) can request blood from the bank.', N'https://ahmadomari98.github.io/BloodBankSystem/', N'59da7667-d45c-4296-822d-b1aec788a792_BBS.png', CAST(N'2022-02-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-01T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [Link], [ProjectLogoPath], [DateFrom], [DateTo], [ResumeId]) VALUES (3, N'Tourist-Places', N'A site that provides information on tourist places in Jordan. Designed with (Html, CSS, JavaScript, Bootstrap).
', N'https://ahmadomari98.github.io/Tourist-places/', N'4b2c8ac2-d5e6-4f4e-bd64-4860f56253a5_TouristPlaces.PNG', CAST(N'2022-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-09-30T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [Link], [ProjectLogoPath], [DateFrom], [DateTo], [ResumeId]) VALUES (4, N'ABH News', N'It is a news site that is based on securing a channel that connects journalists and users in an easy and safe way, where news is displayed by categories and countries, and according to the journalist who publishes the news, and there are also many features such as that a user can like a news and also leave a comment on the news. Also can user to choose his favorite categories, there is also the feature of sending notifications to users of new news. <br><br>
Also, User authentication & authorization, each part in the home can change dynamically using Database, Ads can also be added by users under the approval of the Admin.<br><br>
Designed with (Oracle SQL Developer, ASP.NET Core Web API, C# Programming Language, Html, CSS, JavaScript, Bootstrap, Angular).
', N'https://ahmadomari98.github.io/ABH-News/', N'794e2c3c-e082-4845-9350-31465d24f941_ABHNews.png', CAST(N'2022-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[resumes] ON 

INSERT [dbo].[resumes] ([Id], [Name]) VALUES (1, N'Ahmad M AL-Omari')
SET IDENTITY_INSERT [dbo].[resumes] OFF
GO
SET IDENTITY_INSERT [dbo].[Skills] ON 

INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (1, N'C#', N'Programming Languages', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (2, N'C++', N'Programming Languages', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (3, N'Java', N'Programming Languages', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (4, N'Python', N'Programming Languages', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (5, N'Object-Oriented Programming (OOP)', N'Programming Languages', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (6, N'Oracle SQL Developer', N'Database', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (7, N'Microsoft SQL Server ', N'Database', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (8, N'PL/SQL', N'Database', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (9, N'Microsoft Office', N'Other', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (10, N'Agile Methodology Scrum', N'Other', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (11, N'ASP.NET Core Web App (MVC)', N'Backend', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (12, N'ASP.NET Core Web API', N'Backend', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (13, N'PHP', N'Backend', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (14, N'HTML', N'Frontend', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (15, N'CSS', N'Frontend', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (16, N'JavaScript', N'Frontend', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (17, N'Bootstrap', N'Frontend', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (18, N'Angular', N'Frontend', 1)
INSERT [dbo].[Skills] ([Id], [SkillName], [CategoryName], [ResumeId]) VALUES (19, N'Command-line interface (CLI)', N'Other', 1)
SET IDENTITY_INSERT [dbo].[Skills] OFF
GO
/****** Object:  Index [IX_BasicInfos_ResumeId]    Script Date: 3/16/2025 3:19:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_BasicInfos_ResumeId] ON [dbo].[BasicInfos]
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Certifications_ResumeId]    Script Date: 3/16/2025 3:19:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Certifications_ResumeId] ON [dbo].[Certifications]
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContactUss_ResumeId]    Script Date: 3/16/2025 3:19:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContactUss_ResumeId] ON [dbo].[ContactUss]
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Educations_ResumeId]    Script Date: 3/16/2025 3:19:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Educations_ResumeId] ON [dbo].[Educations]
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Experiences_ResumeId]    Script Date: 3/16/2025 3:19:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Experiences_ResumeId] ON [dbo].[Experiences]
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Languages_ResumeId]    Script Date: 3/16/2025 3:19:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Languages_ResumeId] ON [dbo].[Languages]
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Projects_ResumeId]    Script Date: 3/16/2025 3:19:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Projects_ResumeId] ON [dbo].[Projects]
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Skills_ResumeId]    Script Date: 3/16/2025 3:19:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Skills_ResumeId] ON [dbo].[Skills]
(
	[ResumeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BasicInfos]  WITH CHECK ADD  CONSTRAINT [FK_BasicInfos_resumes_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[resumes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BasicInfos] CHECK CONSTRAINT [FK_BasicInfos_resumes_ResumeId]
GO
ALTER TABLE [dbo].[Certifications]  WITH CHECK ADD  CONSTRAINT [FK_Certifications_resumes_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[resumes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Certifications] CHECK CONSTRAINT [FK_Certifications_resumes_ResumeId]
GO
ALTER TABLE [dbo].[ContactUss]  WITH CHECK ADD  CONSTRAINT [FK_ContactUss_resumes_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[resumes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactUss] CHECK CONSTRAINT [FK_ContactUss_resumes_ResumeId]
GO
ALTER TABLE [dbo].[Educations]  WITH CHECK ADD  CONSTRAINT [FK_Educations_resumes_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[resumes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Educations] CHECK CONSTRAINT [FK_Educations_resumes_ResumeId]
GO
ALTER TABLE [dbo].[Experiences]  WITH CHECK ADD  CONSTRAINT [FK_Experiences_resumes_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[resumes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Experiences] CHECK CONSTRAINT [FK_Experiences_resumes_ResumeId]
GO
ALTER TABLE [dbo].[Languages]  WITH CHECK ADD  CONSTRAINT [FK_Languages_resumes_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[resumes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Languages] CHECK CONSTRAINT [FK_Languages_resumes_ResumeId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_resumes_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[resumes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_resumes_ResumeId]
GO
ALTER TABLE [dbo].[Skills]  WITH CHECK ADD  CONSTRAINT [FK_Skills_resumes_ResumeId] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[resumes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Skills] CHECK CONSTRAINT [FK_Skills_resumes_ResumeId]
GO
USE [master]
GO
ALTER DATABASE [MyProfileResume_MVC] SET  READ_WRITE 
GO
