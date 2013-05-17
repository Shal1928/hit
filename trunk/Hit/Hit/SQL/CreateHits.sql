USE [master]
GO

/****** Object:  Database [Hits]    Script Date: 05/05/2013 14:23:46 ******/
CREATE DATABASE [Hits] ON  PRIMARY 
( NAME = N'Hits', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Hits.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Hits_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Hits_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Hits] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hits].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Hits] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Hits] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Hits] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Hits] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Hits] SET ARITHABORT OFF 
GO

ALTER DATABASE [Hits] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Hits] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Hits] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Hits] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Hits] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Hits] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Hits] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Hits] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Hits] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Hits] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Hits] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Hits] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Hits] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Hits] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Hits] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Hits] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Hits] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Hits] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Hits] SET  READ_WRITE 
GO

ALTER DATABASE [Hits] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Hits] SET  MULTI_USER 
GO

ALTER DATABASE [Hits] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Hits] SET DB_CHAINING OFF 
GO

/*Create Requests Table*/
USE [Hits]
GO

/****** Object:  Table [dbo].[Requests]    Script Date: 05/05/2013 14:24:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RequestThemes](
	[RequestThemeId] [int] NOT NULL,
	[RequestTheme] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RequestThemes] PRIMARY KEY CLUSTERED 
(
	[RequestThemeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[RequestTypes](
	[RequestTypeId] [int] NOT NULL,
	[RequestType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RequestTypes] PRIMARY KEY CLUSTERED 
(
	[RequestTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Requests](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[RequestTypeId] [int] NOT NULL,
	[RequestThemeId] [int] NOT NULL,
	[RequestDate] [date] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_RequestThemes] FOREIGN KEY([RequestThemeId])
REFERENCES [dbo].[RequestThemes] ([RequestThemeId])
GO

ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_RequestThemes]
GO

ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_RequestTypes] FOREIGN KEY([RequestTypeId])
REFERENCES [dbo].[RequestTypes] ([RequestTypeId])
GO

ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_RequestTypes]
GO

CREATE PROCEDURE [dbo].[HitsReport]

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT RequestThemes.RequestTheme, RequestTypes.RequestType, Requests.RequestDate
	FROM Requests INNER JOIN RequestThemes ON Requests.RequestThemeId = RequestThemes.RequestThemeId 
			      INNER JOIN RequestTypes ON Requests.RequestTypeId = RequestTypes.RequestTypeId
END

GO

CREATE LOGIN [tucurator1] WITH PASSWORD=N'MeG?�y?�/J;afs?oA
OAS?a?u	?l?', DEFAULT_DATABASE=[PeopleDB], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO

ALTER LOGIN [tucurator1] DISABLE
GO