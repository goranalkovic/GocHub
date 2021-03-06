USE [master]
GO
/****** Object:  Database [tbp-db]    Script Date: 21.1.2019. 1:32:50 ******/
CREATE DATABASE [tbp-db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tbp-db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\tbp-db.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'tbp-db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\tbp-db_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [tbp-db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tbp-db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tbp-db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tbp-db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tbp-db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tbp-db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tbp-db] SET ARITHABORT OFF 
GO
ALTER DATABASE [tbp-db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tbp-db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tbp-db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tbp-db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tbp-db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tbp-db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tbp-db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tbp-db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tbp-db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tbp-db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tbp-db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tbp-db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tbp-db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tbp-db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tbp-db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tbp-db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tbp-db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tbp-db] SET RECOVERY FULL 
GO
ALTER DATABASE [tbp-db] SET  MULTI_USER 
GO
ALTER DATABASE [tbp-db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tbp-db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tbp-db] SET FILESTREAM( NON_TRANSACTED_ACCESS = FULL, DIRECTORY_NAME = N'files' ) 
GO
ALTER DATABASE [tbp-db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [tbp-db] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'tbp-db', N'ON'
GO
ALTER DATABASE [tbp-db] SET QUERY_STORE = OFF
GO
USE [tbp-db]
GO
/****** Object:  User [goc]    Script Date: 21.1.2019. 1:32:50 ******/
CREATE USER [goc] FOR LOGIN [goc] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[document_history]    Script Date: 21.1.2019. 1:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[document_history](
	[id] [int] NOT NULL,
	[repoId] [int] NOT NULL,
	[fileName] [varchar](255) NOT NULL,
	[fileType] [varchar](10) NOT NULL,
	[contents] [varchar](max) NOT NULL,
	[path] [varchar](max) NOT NULL,
	[SysStartTime] [datetime2](7) NOT NULL,
	[SysEndTime] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[document]    Script Date: 21.1.2019. 1:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[document](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[repoId] [int] NOT NULL,
	[fileName] [varchar](255) NOT NULL,
	[fileType] [varchar](10) NOT NULL,
	[contents] [varchar](max) NOT NULL,
	[path] [varchar](max) NOT NULL,
	[SysStartTime] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[SysEndTime] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_document] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON ( HISTORY_TABLE = [dbo].[document_history] )
)
GO
/****** Object:  Table [dbo].[user_history]    Script Date: 21.1.2019. 1:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_history](
	[id] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[SysStartTime] [datetime2](7) NOT NULL,
	[SysEndTime] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 21.1.2019. 1:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[SysStartTime] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[SysEndTime] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON ( HISTORY_TABLE = [dbo].[user_history] )
)
GO
/****** Object:  Table [dbo].[repository_history]    Script Date: 21.1.2019. 1:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[repository_history](
	[id] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[description] [varchar](max) NOT NULL,
	[SysStartTime] [datetime2](7) NOT NULL,
	[SysEndTime] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[repository]    Script Date: 21.1.2019. 1:32:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[repository](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[description] [varchar](max) NOT NULL,
	[SysStartTime] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[SysEndTime] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_repository] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([SysStartTime], [SysEndTime])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON ( HISTORY_TABLE = [dbo].[repository_history] )
)
GO
ALTER TABLE [dbo].[document]  WITH CHECK ADD  CONSTRAINT [FK_doc_repo] FOREIGN KEY([repoId])
REFERENCES [dbo].[repository] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[document] CHECK CONSTRAINT [FK_doc_repo]
GO
ALTER TABLE [dbo].[repository]  WITH CHECK ADD  CONSTRAINT [FK_repoUser] FOREIGN KEY([userId])
REFERENCES [dbo].[user] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[repository] CHECK CONSTRAINT [FK_repoUser]
GO
USE [master]
GO
ALTER DATABASE [tbp-db] SET  READ_WRITE 
GO
