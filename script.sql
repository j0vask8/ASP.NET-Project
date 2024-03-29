USE [master]
GO
/****** Object:  Database [Sajt]    Script Date: 6/16/2019 11:49:15 PM ******/
CREATE DATABASE [Sajt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sajt', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Sajt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sajt_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Sajt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Sajt] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sajt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sajt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sajt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sajt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sajt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sajt] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sajt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sajt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sajt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sajt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sajt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sajt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sajt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sajt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sajt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sajt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sajt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sajt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sajt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sajt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sajt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sajt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sajt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sajt] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Sajt] SET  MULTI_USER 
GO
ALTER DATABASE [Sajt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sajt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sajt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sajt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sajt] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Sajt] SET QUERY_STORE = OFF
GO
USE [Sajt]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/16/2019 11:49:16 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/16/2019 11:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[isDeleted] [bit] NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 6/16/2019 11:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[isDeleted] [bit] NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
	[UserId] [int] NOT NULL,
	[TopicId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/16/2019 11:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[isDeleted] [bit] NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 6/16/2019 11:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[isDeleted] [bit] NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/16/2019 11:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[isDeleted] [bit] NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190612141619_Initial', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190612145113_Replies_to_Comment', N'2.2.4-servicing-10062')
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (1, CAST(N'2019-06-12T16:44:48.5733333' AS DateTime2), NULL, 0, N'Sport')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (2, CAST(N'2019-06-12T16:44:54.7900000' AS DateTime2), NULL, 0, N'Games')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (3, CAST(N'2019-06-12T16:44:58.8066667' AS DateTime2), NULL, 0, N'Movies')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (4, CAST(N'2019-06-12T16:45:04.2800000' AS DateTime2), NULL, 0, N'Music')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (5, CAST(N'2019-06-12T17:40:02.3166667' AS DateTime2), NULL, 0, N'NewCategory')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (6, CAST(N'2019-06-12T18:04:46.4300000' AS DateTime2), NULL, 1, N'NewCategory2')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (7, CAST(N'2019-06-14T01:04:26.2600000' AS DateTime2), NULL, 0, N'NewCategory3')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (8, CAST(N'2019-06-14T13:11:51.2233333' AS DateTime2), NULL, 0, N'Newww')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (9, CAST(N'2019-06-14T13:12:38.9333333' AS DateTime2), NULL, 1, N'cat')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Content], [UserId], [TopicId]) VALUES (3, CAST(N'2019-06-12T16:58:04.5600000' AS DateTime2), NULL, 0, N'My favourite move is Movie1', 3, 1)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Content], [UserId], [TopicId]) VALUES (8, CAST(N'2019-06-12T16:58:04.5600000' AS DateTime2), NULL, 1, N'Text Text', 2, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Content], [UserId], [TopicId]) VALUES (9, CAST(N'2019-06-16T16:00:25.2700000' AS DateTime2), NULL, 0, N'adsadsa', 5, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Content], [UserId], [TopicId]) VALUES (10, CAST(N'2019-06-16T16:00:41.8733333' AS DateTime2), NULL, 1, N'adsadsa', 5, 2)
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (2, CAST(N'2019-06-12T16:26:56.1033333' AS DateTime2), NULL, 0, N'Admin')
INSERT [dbo].[Roles] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Name]) VALUES (3, CAST(N'2019-06-12T16:37:40.7033333' AS DateTime2), NULL, 0, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Topics] ON 

INSERT [dbo].[Topics] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Subject], [Content], [UserId], [CategoryId]) VALUES (1, CAST(N'2019-06-12T16:48:21.9233333' AS DateTime2), NULL, 0, N'Favourite Band', N'What is your favourite band?', 3, 4)
INSERT [dbo].[Topics] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Subject], [Content], [UserId], [CategoryId]) VALUES (2, CAST(N'2019-06-12T16:48:51.0766667' AS DateTime2), NULL, 0, N'Favourite Movie', N'What is your favourite movie?', 5, 3)
SET IDENTITY_INSERT [dbo].[Topics] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Username], [Email], [Password], [RoleId]) VALUES (2, CAST(N'2019-06-12T16:39:04.5000000' AS DateTime2), CAST(N'2019-06-16T21:10:18.0031785' AS DateTime2), 0, N'Java', N'java@gmail.com', N'Jova', 2)
INSERT [dbo].[Users] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Username], [Email], [Password], [RoleId]) VALUES (3, CAST(N'2019-06-12T16:39:20.5233333' AS DateTime2), NULL, 0, N'Mika', N'mika@gmail.com', N'Mika', 3)
INSERT [dbo].[Users] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Username], [Email], [Password], [RoleId]) VALUES (5, CAST(N'2019-06-12T16:39:39.2600000' AS DateTime2), NULL, 0, N'Zika', N'zika@gmail.com', N'Zika', 3)
INSERT [dbo].[Users] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Username], [Email], [Password], [RoleId]) VALUES (6, CAST(N'2019-06-12T16:39:55.7333333' AS DateTime2), NULL, 0, N'Pera', N'pera@gmail.com', N'Pera', 3)
INSERT [dbo].[Users] ([Id], [CreatedAt], [ModifiedAt], [isDeleted], [Username], [Email], [Password], [RoleId]) VALUES (7, CAST(N'2019-06-12T17:26:10.5233333' AS DateTime2), NULL, 1, N'Mira', N'mira@gmail.com', N'Mira', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categories_Name]    Script Date: 6/16/2019 11:49:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_Name] ON [dbo].[Categories]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_TopicId]    Script Date: 6/16/2019 11:49:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_TopicId] ON [dbo].[Comments]
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_UserId]    Script Date: 6/16/2019 11:49:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_UserId] ON [dbo].[Comments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Roles_Name]    Script Date: 6/16/2019 11:49:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Roles_Name] ON [dbo].[Roles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Topics_CategoryId]    Script Date: 6/16/2019 11:49:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Topics_CategoryId] ON [dbo].[Topics]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Topics_Subject]    Script Date: 6/16/2019 11:49:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Topics_Subject] ON [dbo].[Topics]
(
	[Subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Topics_UserId]    Script Date: 6/16/2019 11:49:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Topics_UserId] ON [dbo].[Topics]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 6/16/2019 11:49:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Username]    Script Date: 6/16/2019 11:49:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Topics] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Topics_TopicId] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topics] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Topics_TopicId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topics_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topics_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topics_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topics_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [Sajt] SET  READ_WRITE 
GO
