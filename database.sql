/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [BDU_Management]    Script Date: 4/15/2018 3:22:38 AM ******/
CREATE DATABASE [BDU_Management]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDU_Management', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BDU_Management.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDU_Management_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BDU_Management_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BDU_Management] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDU_Management].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDU_Management] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDU_Management] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDU_Management] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDU_Management] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDU_Management] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDU_Management] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDU_Management] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDU_Management] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDU_Management] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDU_Management] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDU_Management] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDU_Management] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDU_Management] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDU_Management] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDU_Management] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDU_Management] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDU_Management] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDU_Management] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDU_Management] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDU_Management] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDU_Management] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDU_Management] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDU_Management] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDU_Management] SET  MULTI_USER 
GO
ALTER DATABASE [BDU_Management] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDU_Management] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDU_Management] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDU_Management] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDU_Management] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDU_Management] SET QUERY_STORE = OFF
GO
USE [BDU_Management]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BDU_Management]
GO
/****** Object:  Table [dbo].[Authorized_Persons]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authorized_Persons](
	[authorized_person_id] [int] IDENTITY(1,1) NOT NULL,
	[authorized_person_name] [nvarchar](50) NOT NULL,
	[authorized_person_surname] [nvarchar](50) NOT NULL,
	[authorized_person_father_name] [nvarchar](50) NULL,
	[authorized_person_email] [nvarchar](150) NOT NULL,
	[authorized_person_password] [nvarchar](100) NOT NULL,
	[authorized_person_role_id] [int] NOT NULL,
	[authorized_person_degree_id] [int] NULL,
	[authorized_person_gender_id] [int] NOT NULL,
 CONSTRAINT [PK_Authorized_Persons] PRIMARY KEY CLUSTERED 
(
	[authorized_person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cafedras]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cafedras](
	[cafedra_id] [int] IDENTITY(1,1) NOT NULL,
	[cafedra_name] [nvarchar](100) NOT NULL,
	[cafedra_chief_id] [int] NOT NULL,
	[cafedra_faculty_id] [int] NOT NULL,
 CONSTRAINT [PK_Cafedras] PRIMARY KEY CLUSTERED 
(
	[cafedra_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Centers]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Centers](
	[center_id] [int] IDENTITY(1,1) NOT NULL,
	[center_name] [nvarchar](70) NOT NULL,
	[center_chief_id] [int] NOT NULL,
 CONSTRAINT [PK_Centers] PRIMARY KEY CLUSTERED 
(
	[center_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Degrees]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Degrees](
	[degree_id] [int] IDENTITY(1,1) NOT NULL,
	[degree_name] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_Degrees] PRIMARY KEY CLUSTERED 
(
	[degree_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[faculty_id] [int] IDENTITY(1,1) NOT NULL,
	[faculty_name] [nvarchar](100) NOT NULL,
	[faculty_dean_id] [int] NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[faculty_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[gender_id] [int] IDENTITY(1,1) NOT NULL,
	[gender_name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[gender_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Museums]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Museums](
	[museum_id] [int] IDENTITY(1,1) NOT NULL,
	[museum_name] [nvarchar](70) NOT NULL,
	[museum_chief_id] [int] NOT NULL,
 CONSTRAINT [PK_Museums] PRIMARY KEY CLUSTERED 
(
	[museum_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profession_Types]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profession_Types](
	[profession_type_id] [int] IDENTITY(1,1) NOT NULL,
	[profession_type_name] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_Profession_Type] PRIMARY KEY CLUSTERED 
(
	[profession_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professions]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professions](
	[profession_id] [int] IDENTITY(1,1) NOT NULL,
	[profession_name] [nvarchar](100) NOT NULL,
	[profession_profession_type_id] [int] NOT NULL,
	[profession_cafedra_id] [int] NOT NULL,
 CONSTRAINT [PK_Professions] PRIMARY KEY CLUSTERED 
(
	[profession_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prorector_Branchs]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prorector_Branchs](
	[prorector_branch_id] [int] IDENTITY(1,1) NOT NULL,
	[prorector_branch_name] [nvarchar](100) NOT NULL,
	[prorector_branch_prorector_id] [int] NOT NULL,
 CONSTRAINT [PK_Prorector_Branchs] PRIMARY KEY CLUSTERED 
(
	[prorector_branch_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[student_id] [int] IDENTITY(1,1) NOT NULL,
	[student_name] [nvarchar](50) NOT NULL,
	[student_surname] [nvarchar](50) NOT NULL,
	[student_father_name] [nvarchar](50) NULL,
	[student_email] [nvarchar](150) NOT NULL,
	[student_password] [nvarchar](100) NOT NULL,
	[student_gender_id] [int] NOT NULL,
	[student_profession_id] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[subject_id] [int] IDENTITY(1,1) NOT NULL,
	[subject_name] [nvarchar](70) NOT NULL,
	[subject_profession_id] [int] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[teacher_id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_name] [nvarchar](50) NOT NULL,
	[teacher_surname] [nvarchar](50) NOT NULL,
	[teacher_father_name] [nvarchar](50) NOT NULL,
	[teacher_email] [nvarchar](150) NOT NULL,
	[teacher_password] [nvarchar](100) NOT NULL,
	[teacher_gender_id] [int] NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers_Subjects_Pivot]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers_Subjects_Pivot](
	[ts_id] [int] IDENTITY(1,1) NOT NULL,
	[ts_teacher_id] [int] NOT NULL,
	[ts_subject_id] [int] NOT NULL,
 CONSTRAINT [PK_Teachers_Subjects_Pivot] PRIMARY KEY CLUSTERED 
(
	[ts_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Roles]    Script Date: 4/15/2018 3:22:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Roles](
	[user_role_id] [int] IDENTITY(1,1) NOT NULL,
	[user_role_name] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[user_role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authorized_Persons] ON 

INSERT [dbo].[Authorized_Persons] ([authorized_person_id], [authorized_person_name], [authorized_person_surname], [authorized_person_father_name], [authorized_person_email], [authorized_person_password], [authorized_person_role_id], [authorized_person_degree_id], [authorized_person_gender_id]) VALUES (7, N'Orxan', N'Ferecov', N'Xeyyam', N'orxan@code.edu.az', N'sha1:64000:18:MXicqtPFxdJhoyOVMDSKv8b8tIidpriD:zMg3SC2D09fGj/9a6J7sOWfl', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Authorized_Persons] OFF
SET IDENTITY_INSERT [dbo].[Degrees] ON 

INSERT [dbo].[Degrees] ([degree_id], [degree_name]) VALUES (1, N'Akademik')
INSERT [dbo].[Degrees] ([degree_id], [degree_name]) VALUES (2, N'Professor')
SET IDENTITY_INSERT [dbo].[Degrees] OFF
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([gender_id], [gender_name]) VALUES (1, N'Kişi')
INSERT [dbo].[Genders] ([gender_id], [gender_name]) VALUES (2, N'Qadın')
SET IDENTITY_INSERT [dbo].[Genders] OFF
SET IDENTITY_INSERT [dbo].[User_Roles] ON 

INSERT [dbo].[User_Roles] ([user_role_id], [user_role_name]) VALUES (1, N'Rektor')
INSERT [dbo].[User_Roles] ([user_role_id], [user_role_name]) VALUES (2, N'Prorektor')
INSERT [dbo].[User_Roles] ([user_role_id], [user_role_name]) VALUES (3, N'Rektor Müşaviri')
INSERT [dbo].[User_Roles] ([user_role_id], [user_role_name]) VALUES (4, N'Dekan')
INSERT [dbo].[User_Roles] ([user_role_id], [user_role_name]) VALUES (5, N'Kafedra Müdiri')
INSERT [dbo].[User_Roles] ([user_role_id], [user_role_name]) VALUES (6, N'Mərkəz Rəhbəri')
INSERT [dbo].[User_Roles] ([user_role_id], [user_role_name]) VALUES (7, N'Muzey Rəhbəri')
SET IDENTITY_INSERT [dbo].[User_Roles] OFF
ALTER TABLE [dbo].[Authorized_Persons]  WITH CHECK ADD  CONSTRAINT [FK_Authorized_Persons_To_Degrees] FOREIGN KEY([authorized_person_degree_id])
REFERENCES [dbo].[Degrees] ([degree_id])
GO
ALTER TABLE [dbo].[Authorized_Persons] CHECK CONSTRAINT [FK_Authorized_Persons_To_Degrees]
GO
ALTER TABLE [dbo].[Authorized_Persons]  WITH CHECK ADD  CONSTRAINT [FK_Authorized_Persons_To_Genders] FOREIGN KEY([authorized_person_gender_id])
REFERENCES [dbo].[Genders] ([gender_id])
GO
ALTER TABLE [dbo].[Authorized_Persons] CHECK CONSTRAINT [FK_Authorized_Persons_To_Genders]
GO
ALTER TABLE [dbo].[Authorized_Persons]  WITH CHECK ADD  CONSTRAINT [FK_Authorized_Persons_To_Roles] FOREIGN KEY([authorized_person_role_id])
REFERENCES [dbo].[User_Roles] ([user_role_id])
GO
ALTER TABLE [dbo].[Authorized_Persons] CHECK CONSTRAINT [FK_Authorized_Persons_To_Roles]
GO
ALTER TABLE [dbo].[Cafedras]  WITH CHECK ADD  CONSTRAINT [FK_Cafedras_Faculties] FOREIGN KEY([cafedra_faculty_id])
REFERENCES [dbo].[Faculties] ([faculty_id])
GO
ALTER TABLE [dbo].[Cafedras] CHECK CONSTRAINT [FK_Cafedras_Faculties]
GO
ALTER TABLE [dbo].[Cafedras]  WITH CHECK ADD  CONSTRAINT [FK_Cafedras_To_Authorized_Persons] FOREIGN KEY([cafedra_chief_id])
REFERENCES [dbo].[Authorized_Persons] ([authorized_person_id])
GO
ALTER TABLE [dbo].[Cafedras] CHECK CONSTRAINT [FK_Cafedras_To_Authorized_Persons]
GO
ALTER TABLE [dbo].[Centers]  WITH CHECK ADD  CONSTRAINT [FK_Centers_To_Authorized_Persons] FOREIGN KEY([center_chief_id])
REFERENCES [dbo].[Authorized_Persons] ([authorized_person_id])
GO
ALTER TABLE [dbo].[Centers] CHECK CONSTRAINT [FK_Centers_To_Authorized_Persons]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_Faculties_To_Authorized_Persons] FOREIGN KEY([faculty_dean_id])
REFERENCES [dbo].[Authorized_Persons] ([authorized_person_id])
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_Faculties_To_Authorized_Persons]
GO
ALTER TABLE [dbo].[Museums]  WITH CHECK ADD  CONSTRAINT [FK_Museums_To_Authorized_Persons] FOREIGN KEY([museum_chief_id])
REFERENCES [dbo].[Authorized_Persons] ([authorized_person_id])
GO
ALTER TABLE [dbo].[Museums] CHECK CONSTRAINT [FK_Museums_To_Authorized_Persons]
GO
ALTER TABLE [dbo].[Professions]  WITH CHECK ADD  CONSTRAINT [FK_Professions_To_Cafedras] FOREIGN KEY([profession_cafedra_id])
REFERENCES [dbo].[Cafedras] ([cafedra_id])
GO
ALTER TABLE [dbo].[Professions] CHECK CONSTRAINT [FK_Professions_To_Cafedras]
GO
ALTER TABLE [dbo].[Professions]  WITH CHECK ADD  CONSTRAINT [FK_Professions_To_Profession_Types] FOREIGN KEY([profession_profession_type_id])
REFERENCES [dbo].[Profession_Types] ([profession_type_id])
GO
ALTER TABLE [dbo].[Professions] CHECK CONSTRAINT [FK_Professions_To_Profession_Types]
GO
ALTER TABLE [dbo].[Prorector_Branchs]  WITH CHECK ADD  CONSTRAINT [FK_Prorector_Branchs_To_Authorized_Persons] FOREIGN KEY([prorector_branch_prorector_id])
REFERENCES [dbo].[Authorized_Persons] ([authorized_person_id])
GO
ALTER TABLE [dbo].[Prorector_Branchs] CHECK CONSTRAINT [FK_Prorector_Branchs_To_Authorized_Persons]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_To_Genders] FOREIGN KEY([student_gender_id])
REFERENCES [dbo].[Genders] ([gender_id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_To_Genders]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_To_Professions] FOREIGN KEY([student_profession_id])
REFERENCES [dbo].[Professions] ([profession_id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_To_Professions]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Professions] FOREIGN KEY([subject_profession_id])
REFERENCES [dbo].[Professions] ([profession_id])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Professions]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_To_Genders] FOREIGN KEY([teacher_gender_id])
REFERENCES [dbo].[Genders] ([gender_id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_To_Genders]
GO
ALTER TABLE [dbo].[Teachers_Subjects_Pivot]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Subjects_Pivot_To_Subjects] FOREIGN KEY([ts_subject_id])
REFERENCES [dbo].[Subjects] ([subject_id])
GO
ALTER TABLE [dbo].[Teachers_Subjects_Pivot] CHECK CONSTRAINT [FK_Teachers_Subjects_Pivot_To_Subjects]
GO
ALTER TABLE [dbo].[Teachers_Subjects_Pivot]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Subjects_Pivot_To_Teachers] FOREIGN KEY([ts_teacher_id])
REFERENCES [dbo].[Teachers] ([teacher_id])
GO
ALTER TABLE [dbo].[Teachers_Subjects_Pivot] CHECK CONSTRAINT [FK_Teachers_Subjects_Pivot_To_Teachers]
GO
USE [master]
GO
ALTER DATABASE [BDU_Management] SET  READ_WRITE 
GO
