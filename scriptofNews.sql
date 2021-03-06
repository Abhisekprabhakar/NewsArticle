USE [master]
GO
/****** Object:  Database [News_article]    Script Date: 14-10-2021 13:25:33 ******/
CREATE DATABASE [News_article]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'News_article', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\News_article.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'News_article_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\News_article_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [News_article] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [News_article].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [News_article] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [News_article] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [News_article] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [News_article] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [News_article] SET ARITHABORT OFF 
GO
ALTER DATABASE [News_article] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [News_article] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [News_article] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [News_article] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [News_article] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [News_article] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [News_article] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [News_article] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [News_article] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [News_article] SET  DISABLE_BROKER 
GO
ALTER DATABASE [News_article] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [News_article] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [News_article] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [News_article] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [News_article] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [News_article] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [News_article] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [News_article] SET RECOVERY FULL 
GO
ALTER DATABASE [News_article] SET  MULTI_USER 
GO
ALTER DATABASE [News_article] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [News_article] SET DB_CHAINING OFF 
GO
ALTER DATABASE [News_article] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [News_article] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [News_article] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'News_article', N'ON'
GO
ALTER DATABASE [News_article] SET QUERY_STORE = OFF
GO
USE [News_article]
GO
/****** Object:  Table [dbo].[article]    Script Date: 14-10-2021 13:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[article] [varchar](max) NOT NULL,
	[publishedOn] [datetime] NOT NULL,
	[title] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14-10-2021 13:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](max) NOT NULL,
	[username] [varchar](max) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[role] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[article] ON 

INSERT [dbo].[article] ([Id], [article], [publishedOn], [title]) VALUES (1, N'asdf', CAST(N'1899-12-31T00:00:00.000' AS DateTime), N'asd')
INSERT [dbo].[article] ([Id], [article], [publishedOn], [title]) VALUES (2, N'asdf', CAST(N'1899-12-31T00:00:00.000' AS DateTime), N'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')
INSERT [dbo].[article] ([Id], [article], [publishedOn], [title]) VALUES (1002, N'sjjef efiijf qjwf9jfi qwjqjfijw  efjijfic ewjcijwqicjiwq', CAST(N'2021-10-07T13:27:51.270' AS DateTime), N'this is the title of article')
SET IDENTITY_INSERT [dbo].[article] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [name], [username], [password], [role]) VALUES (1, N'abhishek', N'ap001', N'Ap0001', N'admin')
INSERT [dbo].[Users] ([Id], [name], [username], [password], [role]) VALUES (2, N'suresh', N'suresh', N'suresh01', N'admin')
INSERT [dbo].[Users] ([Id], [name], [username], [password], [role]) VALUES (3, N'ramesh', N'ramesh', N'ramesh01', N'user')
INSERT [dbo].[Users] ([Id], [name], [username], [password], [role]) VALUES (1002, N'Abhishek', N'abhishek@article.com', N'Abhishek@01', N'user')
INSERT [dbo].[Users] ([Id], [name], [username], [password], [role]) VALUES (1003, N'Abhishek', N'abhishek.admin@article', N'Ap@0001', N'admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [News_article] SET  READ_WRITE 
GO
