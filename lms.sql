USE [master]
GO
/****** Object:  Database [LeaveManagementSystem]    Script Date: 4/25/2021 11:07:10 AM ******/
CREATE DATABASE [LeaveManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LeaveManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LeaveManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LeaveManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LeaveManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LeaveManagementSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LeaveManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LeaveManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LeaveManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LeaveManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LeaveManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LeaveManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [LeaveManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [LeaveManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LeaveManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LeaveManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LeaveManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LeaveManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LeaveManagementSystem', N'ON'
GO
ALTER DATABASE [LeaveManagementSystem] SET QUERY_STORE = OFF
GO
USE [LeaveManagementSystem]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationID] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[DesignationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holiday](
	[HolidayID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Day] [varchar](50) NOT NULL,
	[Date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED 
(
	[HolidayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Holiday] UNIQUE NONCLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institute]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institute](
	[InstituteID] [int] IDENTITY(1,1) NOT NULL,
	[InstituteName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Institute] PRIMARY KEY CLUSTERED 
(
	[InstituteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[LeaveID] [int] IDENTITY(1,1) NOT NULL,
	[LeaveTypeID] [int] NULL,
	[LeaveReason] [varchar](50) NOT NULL,
	[LeaveStartDate] [varchar](50) NOT NULL,
	[LeaveEndDate] [varchar](50) NULL,
	[LeaveDuration] [varchar](50) NOT NULL,
	[LeaveResponseBy] [varchar](50) NULL,
	[LeaveStatus] [varchar](50) NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[LeaveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveStatus]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveStatus](
	[LeaveStatusID] [int] IDENTITY(1,1) NOT NULL,
	[LeaveTypeID] [int] NULL,
	[UserID] [int] NOT NULL,
	[LeaveID] [int] NOT NULL,
 CONSTRAINT [PK_LeaveStatus] PRIMARY KEY CLUSTERED 
(
	[LeaveStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveType]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveType](
	[LeaveTypeID] [int] IDENTITY(1,1) NOT NULL,
	[LeaveType] [varchar](50) NOT NULL,
	[TotalDays] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Leave Type] PRIMARY KEY CLUSTERED 
(
	[LeaveTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[DisplayName] [varchar](50) NOT NULL,
	[MobileNo] [varchar](50) NULL,
	[DOB] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Experience] [varchar](50) NULL,
	[Qualification] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[DesignationID] [int] NULL,
	[DepartmentID] [int] NULL,
	[InstituteID] [int] NULL,
	[PhotoPath] [varchar](1000) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User]    Script Date: 4/25/2021 11:07:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_User] ON [dbo].[User]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Leave] ADD  CONSTRAINT [DF_Leave_LeaveResponseBy]  DEFAULT ('Pending') FOR [LeaveResponseBy]
GO
ALTER TABLE [dbo].[Leave] ADD  CONSTRAINT [DF_Leave_LeaveStatus]  DEFAULT ('Pending') FOR [LeaveStatus]
GO
ALTER TABLE [dbo].[Leave]  WITH CHECK ADD  CONSTRAINT [FK_Leave_LeaveType] FOREIGN KEY([LeaveTypeID])
REFERENCES [dbo].[LeaveType] ([LeaveTypeID])
GO
ALTER TABLE [dbo].[Leave] CHECK CONSTRAINT [FK_Leave_LeaveType]
GO
ALTER TABLE [dbo].[Leave]  WITH CHECK ADD  CONSTRAINT [FK_Leave_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Leave] CHECK CONSTRAINT [FK_Leave_User]
GO
ALTER TABLE [dbo].[LeaveStatus]  WITH CHECK ADD  CONSTRAINT [FK_LeaveStatus_Leave] FOREIGN KEY([LeaveID])
REFERENCES [dbo].[Leave] ([LeaveID])
GO
ALTER TABLE [dbo].[LeaveStatus] CHECK CONSTRAINT [FK_LeaveStatus_Leave]
GO
ALTER TABLE [dbo].[LeaveStatus]  WITH CHECK ADD  CONSTRAINT [FK_LeaveStatus_LeaveType] FOREIGN KEY([LeaveTypeID])
REFERENCES [dbo].[LeaveType] ([LeaveTypeID])
GO
ALTER TABLE [dbo].[LeaveStatus] CHECK CONSTRAINT [FK_LeaveStatus_LeaveType]
GO
ALTER TABLE [dbo].[LeaveStatus]  WITH CHECK ADD  CONSTRAINT [FK_LeaveStatus_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[LeaveStatus] CHECK CONSTRAINT [FK_LeaveStatus_User]
GO
ALTER TABLE [dbo].[LeaveType]  WITH CHECK ADD  CONSTRAINT [FK_LeaveType_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[LeaveType] CHECK CONSTRAINT [FK_LeaveType_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Department]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Designation] FOREIGN KEY([DesignationID])
REFERENCES [dbo].[Designation] ([DesignationID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Designation]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Institute] FOREIGN KEY([InstituteID])
REFERENCES [dbo].[Institute] ([InstituteID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Institute]
GO
/****** Object:  StoredProcedure [dbo].[PR_Department_DeleteByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Department_DeleteByPK]
	@DepartmentID int
AS
DELETE
FROM [dbo].[Department]
WHERE [dbo].[Department].[DepartmentID] = @DepartmentID
GO
/****** Object:  StoredProcedure [dbo].[PR_Department_Insert]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Department_Insert]
	@DepartmentID INT OUTPUT,
	@DepartmentName varchar(100)
AS
INSERT INTO [dbo].[Department]
(
	[DepartmentName]
)
VALUES
(
	@DepartmentName
)
SET @DepartmentID= SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_Department_SelectAll]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Department_SelectAll]
As
Select
	[dbo].[Department].[DepartmentID],
	[dbo].[Department].[DepartmentName]
FROM [dbo].[Department]
ORDER BY [dbo].[Department].[DepartmentName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Department_SelectByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PR_Department_SelectByPK]
	@DepartmentID INT
As
Select
	[dbo].[Department].[DepartmentID],
	[dbo].[Department].[DepartmentName]
FROM [dbo].[Department]
WHERE [dbo].[Department].[DepartmentID] = @DepartmentID
GO
/****** Object:  StoredProcedure [dbo].[PR_Department_SelectForDropDownList]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Department_SelectForDropDownList]
As
Select
	[dbo].[Department].[DepartmentID],
	[dbo].[Department].[DepartmentName]
FROM [dbo].[Department]
ORDER BY [dbo].[Department].[DepartmentName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Department_UpdateByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Department_UpdateByPK]
	@DepartmentID int,
	@DepartmentName varchar(50)
AS
UPDATE [dbo].[Department]
SET 
	[DepartmentName] = @DepartmentName
WHERE [dbo].[Department].[DepartmentID] = @DepartmentID
GO
/****** Object:  StoredProcedure [dbo].[PR_Designation_DeleteByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Designation_DeleteByPK]
	@DesignationID int
AS
DELETE
FROM [dbo].[Designation]
WHERE [dbo].[Designation].[DesignationID] = @DesignationID
GO
/****** Object:  StoredProcedure [dbo].[PR_Designation_Insert]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Designation_Insert]
	@DesignationID INT OUTPUT,
	@DesignationName varchar(50)
AS
INSERT INTO [dbo].[Designation]
(
	[DesignationName]
)
VALUES
(
	@DesignationName
)
SET @DesignationID = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_Designation_SelectAll]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Designation_SelectAll]
As
Select
	[dbo].[Designation].[DesignationID],
	[dbo].[Designation].[DesignationName]
FROM [dbo].[Designation]
ORDER BY [dbo].[Designation].[DesignationName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Designation_SelectByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PR_Designation_SelectByPK]
	@DesignationID INT
As
Select
	[dbo].[Designation].[DesignationID],
	[dbo].[Designation].[DesignationName]
FROM [dbo].[Designation]
WHERE [dbo].[Designation].[DesignationID] = @DesignationID
GO
/****** Object:  StoredProcedure [dbo].[PR_Designation_SelectForDropDownList]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Designation_SelectForDropDownList]
As
Select
	[dbo].[Designation].[DesignationID],
	[dbo].[Designation].[DesignationName]
FROM [dbo].[Designation]
ORDER BY [dbo].[Designation].[DesignationName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Designation_SelectWithoutHODForDropDownList]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Designation_SelectWithoutHODForDropDownList]
As
Select
	[dbo].[Designation].[DesignationID],
	[dbo].[Designation].[DesignationName]
FROM [dbo].[Designation]
WHERE [dbo].[Designation].[DesignationName] != 'HOD'
ORDER BY [dbo].[Designation].[DesignationName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Designation_UpdateByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Designation_UpdateByPK]
	@DesignationID int,
	@DesignationName varchar(50)
AS
UPDATE [dbo].[Designation]
SET 
	[DesignationName] = @DesignationName
WHERE [dbo].[Designation].[DesignationID] = @DesignationID
GO
/****** Object:  StoredProcedure [dbo].[PR_Holiday_DeleteByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Holiday_DeleteByPK]
	@HolidayID int
AS
DELETE
FROM [dbo].[Holiday]
WHERE [dbo].[Holiday].[HolidayID] = @HolidayID
GO
/****** Object:  StoredProcedure [dbo].[PR_Holiday_Insert]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Holiday_Insert]
	@Name varchar(50),
	@Day varchar(50),
	@Date varchar(50)
AS
INSERT INTO [dbo].[Holiday]
(
	[Name],
	[Day],
	[Date]
)
VALUES
(
	@Name,
	@Day,
	@Date
)
GO
/****** Object:  StoredProcedure [dbo].[PR_Holiday_SelectAll]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Holiday_SelectAll]
As
Select
	[dbo].[Holiday].[HolidayID],
	[dbo].[Holiday].[Name],
	[dbo].[Holiday].[Day],
	[dbo].[Holiday].[Date]
FROM [dbo].[Holiday]
ORDER BY [dbo].[Holiday].[Name]
GO
/****** Object:  StoredProcedure [dbo].[PR_Holiday_SelectByHolidayDate]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Holiday_SelectByHolidayDate] 
	@Date varchar(50)
As
Select
	[dbo].[Holiday].[Name],
	[dbo].[Holiday].[Date],
	[dbo].[Holiday].[Day]
FROM [dbo].[Holiday]
WHERE [dbo].[Holiday].[Date] = @Date
GO
/****** Object:  StoredProcedure [dbo].[PR_Holiday_SelectByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PR_Holiday_SelectByPK]
	@HolidayID INT
As
Select
	[dbo].[Holiday].[HolidayID],
	[dbo].[Holiday].[Date],
	[dbo].[Holiday].[Name],
	[dbo].[Holiday].[Day]
FROM [dbo].[Holiday]
WHERE [dbo].[Holiday].[HolidayID] = @HolidayID
GO
/****** Object:  StoredProcedure [dbo].[PR_Holiday_SelectHolidayDate]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Holiday_SelectHolidayDate]
As
Select
	[dbo].[Holiday].[Date]
FROM [dbo].[Holiday]
GO
/****** Object:  StoredProcedure [dbo].[PR_Holiday_UpdateByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Holiday_UpdateByPK]
	@HolidayID INT,
	@Name varchar(50),
	@Day varchar(50),
	@Date varchar(50)
AS
UPDATE [dbo].[Holiday]
SET 
	[Name] = @Name,
	[Day] = @Day,
	[Date] = @Date
WHERE [dbo].[Holiday].[HolidayID] = @HolidayID
GO
/****** Object:  StoredProcedure [dbo].[PR_Institute_DeleteByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Institute_DeleteByPK]
	@InstituteID int
AS
DELETE
FROM [dbo].[Institute]
WHERE [dbo].[Institute].[InstituteID] = @InstituteID
GO
/****** Object:  StoredProcedure [dbo].[PR_Institute_Insert]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Institute_Insert]
	@InstituteID INT OUTPUT,
	@InstituteName varchar(100)
AS
INSERT INTO [dbo].[Institute]
(
	[InstituteName]
)
VALUES
(
	@InstituteName
)
SET @InstituteID= SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_Institute_SelectAll]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Institute_SelectAll]
As
Select
	[dbo].[Institute].[InstituteID],
	[dbo].[Institute].[InstituteName]
FROM [dbo].[Institute]
ORDER BY [dbo].[Institute].[InstituteName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Institute_SelectByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PR_Institute_SelectByPK]
	@InstituteID INT
As
Select
	[dbo].[Institute].[InstituteID],
	[dbo].[Institute].[InstituteName]
FROM [dbo].[Institute]
WHERE [dbo].[Institute].[InstituteID] = @InstituteID
GO
/****** Object:  StoredProcedure [dbo].[PR_Institute_SelectForDropDownList]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Institute_SelectForDropDownList]
As
Select
	[dbo].[Institute].[InstituteID],
	[dbo].[Institute].[InstituteName]
FROM [dbo].[Institute]
ORDER BY [dbo].[Institute].[InstituteName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Institute_UpdateByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Institute_UpdateByPK]
	@InstituteID int,
	@InstituteName varchar(100)
AS
UPDATE [dbo].[Institute]
SET 
	[InstituteName] = @InstituteName
WHERE [dbo].[Institute].[InstituteID] = @InstituteID
GO
/****** Object:  StoredProcedure [dbo].[PR_Leave_DeleteAllByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Leave_DeleteAllByUserID]
	@UserID int
AS
DELETE
FROM [dbo].[Leave]
WHERE [dbo].[Leave].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_Leave_DeleteByPKUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Leave_DeleteByPKUserID]
	@LeaveID int,
	@UserID int
AS
DELETE
FROM [dbo].[Leave]
WHERE [dbo].[Leave].[LeaveID] = @LeaveID
AND [dbo].[Leave].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_Leave_InsertByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Leave_InsertByUserID]
	@LeaveID INT OUTPUT,
	@LeaveTypeID int,
	@LeaveReason varchar(50),
	@LeaveStartDate varchar(50),
	@LeaveEndDate varchar(50),
	@LeaveDuration varchar(50),
	@UserID int
AS
INSERT INTO [dbo].[Leave]
(
	[LeaveTypeID],
	[LeaveReason],
	[LeaveStartDate],
	[LeaveEndDate],
	[LeaveDuration],
	[UserID]
)
VALUES
(
	@LeaveTypeID,
	@LeaveReason,
	@LeaveStartDate,
	@LeaveEndDate,
	@LeaveDuration,
	@UserID
)
SET @LeaveID=SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_Leave_SelectAllByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Leave_SelectAllByUserID]
	@UserID int
As
Select
	[dbo].[Leave].[LeaveID],
	[dbo].[LeaveType].[LeaveType],
	[dbo].[Leave].[LeaveReason],
	[dbo].[Leave].[LeaveStartDate],
	[dbo].[Leave].[LeaveEndDate],
	[dbo].[Leave].[LeaveDuration],
	[dbo].[Leave].[LeaveResponseBy],
	[dbo].[Leave].[LeaveStatus]
FROM [dbo].[Leave]
LEFT OUTER JOIN 
[dbo].[LeaveType]
ON [dbo].[LeaveType].[LeaveTypeID] = [dbo].[Leave].[LeaveTypeID]
WHERE [dbo].[Leave].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_Leave_SelectByPKUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Leave_SelectByPKUserID]
	@LeaveID int,
	@UserID int
As
Select
	[dbo].[Leave].[LeaveID],
	[dbo].[Leave].[LeaveTypeID],
	[dbo].[LeaveType].[LeaveType],
	[dbo].[Leave].[LeaveReason],
	[dbo].[Leave].[LeaveStartDate],
	[dbo].[Leave].[LeaveEndDate],
	[dbo].[Leave].[LeaveDuration]
FROM [dbo].[Leave]
LEFT OUTER JOIN 
[dbo].[LeaveType]
ON [dbo].[LeaveType].[LeaveTypeID] = [dbo].[Leave].[LeaveTypeID]
WHERE [dbo].[Leave].[LeaveID] = @LeaveID
AND [dbo].[Leave].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_Leave_SelectLeaveStatusLeaveTypeIDByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Leave_SelectLeaveStatusLeaveTypeIDByPK]
	@LeaveID INT
AS
SELECT 
	[dbo].[Leave].[LeaveResponseBy],
	[dbo].[Leave].[LeaveStatus],
	[dbo].[Leave].[LeaveTypeID]
FROM [dbo].[Leave]
WHERE  [dbo].[Leave].[LeaveID]= @LeaveID
GO
/****** Object:  StoredProcedure [dbo].[PR_Leave_SelectLeaveTotalDaysByLeaveTypeIDUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Leave_SelectLeaveTotalDaysByLeaveTypeIDUserID] 
	@LeaveTypeID int,
	@UserID int
As
Select
	[dbo].[LeaveType].[TotalDays]
FROM [dbo].[Leave]
LEFT OUTER JOIN 
[dbo].[LeaveType]
ON [dbo].[LeaveType].[LeaveTypeID] = [dbo].[Leave].[LeaveTypeID]
WHERE [dbo].[Leave].[LeaveTypeID] = @LeaveTypeID
AND [dbo].[Leave].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_Leave_UpdateByPKUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Leave_UpdateByPKUserID]
	@LeaveID INT,
	@LeaveTypeID INT,
	@LeaveReason VARCHAR(50),
	@LeaveStartDate varchar(50),
	@LeaveEndDate varchar(50),
	@LeaveDuration VARCHAR(50),
	@UserID int
AS
UPDATE [dbo].[Leave]
SET 
	[LeaveTypeID]=@LeaveTypeID,
	[LeaveReason]=@LeaveReason,
	[LeaveStartDate]=@LeaveStartDate,
	[LeaveEndDate]=@LeaveEndDate,
	[LeaveDuration]=@LeaveDuration,
	[UserID]=@UserID
WHERE [dbo].[Leave].[LeaveID] = @LeaveID
AND [dbo].[Leave].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_Leave_UpdateLeaveStatusByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Leave_UpdateLeaveStatusByPK]
	@LeaveID INT,
	@LeaveResponseBy VARCHAR(50),
	@LeaveStatus VARCHAR(50)
AS
UPDATE [dbo].[Leave]
SET 
	[LeaveResponseBy]=@LeaveResponseBy,
	[LeaveStatus]=@LeaveStatus
WHERE [dbo].[Leave].[LeaveID] = @LeaveID
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveStatus_DeleteAllByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveStatus_DeleteAllByUserID]
	@UserID int
AS
DELETE
FROM [dbo].[LeaveStatus]
WHERE [dbo].[LeaveStatus].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveStatus_DeleteByLeaveID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveStatus_DeleteByLeaveID]
	@LeaveID int
AS
DELETE
FROM [dbo].[LeaveStatus]
WHERE [dbo].[LeaveStatus].[LeaveID] = @LeaveID
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveStatus_InsertByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveStatus_InsertByUserID]
	@LeaveTypeID int,
	@LeaveID int,
	@UserID int
AS
INSERT INTO [dbo].[LeaveStatus]
(
	[LeaveTypeID],
	[LeaveID],
	[UserID]
)
VALUES
(
	@LeaveTypeID,
	@LeaveID,
	@UserID
)
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveStatus_SelectAll]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveStatus_SelectAll]
As
Select
	[dbo].[LeaveStatus].[LeaveStatusID],
	[dbo].[User].[UserName],
	[dbo].[LeaveType].[LeaveType],
	[dbo].[Leave].[LeaveID],
	[dbo].[Leave].[LeaveReason],
	[dbo].[Leave].[LeaveStartDate],
	[dbo].[Leave].[LeaveEndDate],
	[dbo].[Leave].[LeaveDuration]
FROM [dbo].[LeaveStatus]
LEFT OUTER JOIN 
[dbo].[LeaveType]
ON [dbo].[LeaveType].[LeaveTypeID] = [dbo].[LeaveStatus].[LeaveTypeID]
LEFT OUTER JOIN 
[dbo].[Leave]
ON [dbo].[Leave].[LeaveID] = [dbo].[LeaveStatus].[LeaveID]
LEFT OUTER JOIN 
[dbo].[User]
ON [dbo].[User].[UserID] = [dbo].[LeaveStatus].[UserID]
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveStatus_UpdateByLeaveID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveStatus_UpdateByLeaveID]
	@LeaveID INT,
	@LeaveTypeID INT
AS
UPDATE [dbo].[LeaveStatus]
SET 
	[LeaveID]=@LeaveID,
	[LeaveTypeID]=@LeaveTypeID
WHERE [dbo].[LeaveStatus].[LeaveID] = @LeaveID
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveType_DeleteAllByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveType_DeleteAllByUserID]
	@UserID int
AS
DELETE
FROM [dbo].[LeaveType]
WHERE [dbo].[LeaveType].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveType_DeleteByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveType_DeleteByPK]
	@LeaveTypeID int
AS
DELETE
FROM [dbo].[LeaveType]
WHERE [dbo].[LeaveType].[LeaveTypeID] = @LeaveTypeID
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveType_InsertByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveType_InsertByUserID]
	@LeaveTypeID INT OUTPUT,
	@LeaveType varchar(50),
	@TotalDays INT,
	@UserID INT
AS
INSERT INTO [dbo].[LeaveType]
(
	[LeaveType],
	[TotalDays],
	[UserID]
)
VALUES
(
	@LeaveType,
	@TotalDays,
	@UserID
)
SET @LeaveTypeID=SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveType_SelectAll]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveType_SelectAll]
As
Select
	[dbo].[LeaveType].[LeaveTypeID],
	[dbo].[LeaveType].[LeaveType],
	[dbo].[LeaveType].[TotalDays],
	[dbo].[User].[UserName]
FROM [dbo].[LeaveType]
LEFT OUTER JOIN [dbo].[User]
ON [dbo].[LeaveType].[UserID] = [dbo].[User].[UserID]
ORDER BY [dbo].[LeaveType].[LeaveType]
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveType_SelectByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveType_SelectByPK]
	@LeaveTypeID int
As
Select
	[dbo].[LeaveType].[LeaveTypeID],
	[dbo].[LeaveType].[LeaveType],
	[dbo].[LeaveType].[TotalDays]
FROM [dbo].[LeaveType]
WHERE [dbo].[LeaveType].[LeaveTypeID] = @LeaveTypeID
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveType_SelectByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveType_SelectByUserID]
	@UserID int
As
Select
	[dbo].[LeaveType].[LeaveType],
	[dbo].[LeaveType].[TotalDays]
FROM [dbo].[LeaveType]
WHERE [dbo].[LeaveType].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveType_SelectForDropDownListByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveType_SelectForDropDownListByUserID]
	@UserID INT
As
Select
	[dbo].[LeaveType].[LeaveTypeID],
	[dbo].[LeaveType].[LeaveType]
FROM [dbo].[LeaveType]
WHERE [dbo].[LeaveType].[UserID] = @UserID
ORDER BY [dbo].[LeaveType].[LeaveType]
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveType_UpdateByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveType_UpdateByPK]
	@LeaveTypeID int,
	@LeaveType varchar(50),
	@TotalDays int
AS
UPDATE [dbo].[LeaveType]
SET 
	[LeaveType] = @LeaveType,
	[TotalDays] = @TotalDays
WHERE [dbo].[LeaveType].[LeaveTypeID] = @LeaveTypeID
GO
/****** Object:  StoredProcedure [dbo].[PR_LeaveType_UpdateTotalDaysByLeaveTypeUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LeaveType_UpdateTotalDaysByLeaveTypeUserID]
	@LeaveType varchar(50),
	@TotalDays int,
	@UserID int
AS
UPDATE [dbo].[LeaveType]
SET 
	[TotalDays] = @TotalDays
WHERE [dbo].[LeaveType].[LeaveType] = @LeaveType
AND [dbo].[LeaveType].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_User_DeleteByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_User_DeleteByPK]
	@UserID int
AS
DELETE
FROM [dbo].[User]
WHERE [dbo].[User].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_User_Insert]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_User_Insert]
	@UserID INT OUTPUT,
	@UserName VARCHAR(50),
	@Password VARCHAR(50),
	@DisplayName VARCHAR(50),
	@MobileNo VARCHAR(50),
	@DOB VARCHAR(50),
	@Gender VARCHAR(50),
	@Email VARCHAR(50),
	@Experience VARCHAR(50),
	@Qualification VARCHAR(50),
	@City VARCHAR(50),
	@DesignationID INT,
	@InstituteID int,
	@DepartmentID int,
	@PhotoPath VARCHAR(1000)
AS
INSERT INTO [dbo].[User]
(
	[UserName],
	[Password],
	[DisplayName],
	[MobileNo],
	[DOB],
	[Gender],
	[Email],
	[Experience],
	[Qualification],
	[City],
	[DesignationID],
	[InstituteID],
	[DepartmentID],
	[PhotoPath]
)
VALUES
(
	@UserName,
	@Password,
	@DisplayName,
	@MobileNo,
	@DOB,
	@Gender,
	@Email,
	@City,
	@Experience,
	@Qualification,
	@DesignationID,
	@InstituteID,
	@DepartmentID,
	@PhotoPath
)
SET @UserID=SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_User_SelectAll]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_User_SelectAll]
As
Select
	[dbo].[User].[UserID],
	[dbo].[User].[UserName],
	[dbo].[User].[MobileNo],
	[dbo].[User].[DOB],
	[dbo].[User].[Gender],
	[dbo].[User].[Email],
	[dbo].[User].[City],
	[dbo].[User].[Experience],
	[dbo].[User].[Qualification],
	[dbo].[Designation].[DesignationName],
	[dbo].[Department].[DepartmentName],
	[dbo].[Institute].[InstituteName]
FROM [dbo].[User]
LEFT OUTER JOIN 
[dbo].[Designation]
ON [dbo].[Designation].[DesignationID] = [dbo].[User].[DesignationID]
LEFT OUTER JOIN 
[dbo].[Department]
ON [dbo].[Department].[DepartmentID] = [dbo].[User].[DepartmentID] 
LEFT OUTER JOIN 
[dbo].[Institute]
ON [dbo].[Institute].[InstituteID] = [dbo].[User].[InstituteID]
WHERE [dbo].[Designation].[DesignationName] != 'HOD'
ORDER BY [dbo].[User].[UserName]
GO
/****** Object:  StoredProcedure [dbo].[PR_User_SelectByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_User_SelectByPK]
	@UserID int
As
Select
	[dbo].[User].[UserName],
	[dbo].[User].[Password],
	[dbo].[User].[DisplayName],
	[dbo].[User].[MobileNo],
	[dbo].[User].[DOB],
	[dbo].[User].[Gender],
	[dbo].[User].[Email],
	[dbo].[User].[City],
	[dbo].[User].[Experience],
	[dbo].[User].[Qualification],
	[dbo].[User].[DesignationID],
	[dbo].[Designation].[DesignationName],
	[dbo].[User].[DepartmentID],
	[dbo].[Department].[DepartmentName],
	[dbo].[User].[InstituteID],
	[dbo].[Institute].[InstituteName],
	[dbo].[User].[PhotoPath]
FROM [dbo].[User]
LEFT OUTER JOIN 
[dbo].[Designation]
ON [dbo].[Designation].[DesignationID] = [dbo].[User].[DesignationID]
LEFT OUTER JOIN 
[dbo].[Department]
ON [dbo].[Department].[DepartmentID] = [dbo].[User].[DepartmentID] 
LEFT OUTER JOIN 
[dbo].[Institute]
ON [dbo].[Institute].[InstituteID] = [dbo].[User].[InstituteID]
WHERE [dbo].[User].[UserID] = @UserID
ORDER BY [dbo].[User].[UserName]
GO
/****** Object:  StoredProcedure [dbo].[PR_User_SelectByUserNamePassword]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_User_SelectByUserNamePassword]
	@UserName varchar(50),
	@Password varchar(50)
AS

SELECT 
		[dbo].[User].[UserID],
		[dbo].[User].[UserName],
		[dbo].[User].[Password],
		[dbo].[User].[DisplayName],
		[dbo].[User].[PhotoPath],
		[dbo].[User].[DesignationID],
		[dbo].[Designation].[DesignationName]
FROM	[dbo].[User]
LEFT OUTER JOIN 
[dbo].[Designation]
ON [dbo].[Designation].[DesignationID] = [dbo].[User].[DesignationID]
WHERE	[UserName] = @UserName
AND		[Password] = @Password
GO
/****** Object:  StoredProcedure [dbo].[PR_User_SelectForDropDownList]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_User_SelectForDropDownList]
As
Select
	[dbo].[User].[UserID],
	[dbo].[User].[UserName]
FROM [dbo].[User]
ORDER BY [dbo].[User].[UserName]
GO
/****** Object:  StoredProcedure [dbo].[PR_User_SelectUserCount]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_User_SelectUserCount]
As
Select
	count(UserID) as Usercount
FROM [dbo].[User]
LEFT OUTER JOIN 
[dbo].[Designation]
ON [dbo].[Designation].[DesignationID] = [dbo].[User].[DesignationID]
WHERE [dbo].[Designation].[DesignationName] != 'HOD'
GO
/****** Object:  StoredProcedure [dbo].[PR_User_SelectUserNameByUserID]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_User_SelectUserNameByUserID]
	@UserID int
As
Select
	[dbo].[User].[UserName]
FROM [dbo].[User]
WHERE [dbo].[User].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_User_UpdateByPK]    Script Date: 4/25/2021 11:07:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_User_UpdateByPK]
	
	@UserID INT,
	@UserName VARCHAR(50),
	@Password VARCHAR(50),
	@DisplayName VARCHAR(50),
	@MobileNo VARCHAR(50),
	@DOB VARCHAR(50),
	@Gender VARCHAR(50),
	@Email VARCHAR(50),
	@City VARCHAR(50),
	@Experience VARCHAR(50),
	@Qualification VARCHAR(50),
	@DesignationID int,
	@InstituteID int,
	@DepartmentID int,
	@PhotoPath VARCHAR(1000)
AS
UPDATE [dbo].[User]
SET 
	[UserName]=@UserName,
	[Password]=@Password,
	[DisplayName]=@DisplayName,
	[MobileNo]=@MobileNo,
	[DOB]=@DOB,
	[Gender]=@Gender,
	[Email]=@Email,
	[City]=@City,
	[Experience]=@Experience,
	[Qualification]=@Qualification,
	[DesignationID]=@DesignationID,
	[InstituteID]=@InstituteID,
	[DepartmentID]=@DepartmentID,
	[PhotoPath]=@PhotoPath
WHERE [dbo].[User].[UserID] = @UserID
GO
USE [master]
GO
ALTER DATABASE [LeaveManagementSystem] SET  READ_WRITE 
GO
