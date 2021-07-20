USE [master]
GO
/****** Object:  Database [LibraryBooksBD]    Script Date: 19.07.2021 19:13:04 ******/
CREATE DATABASE [LibraryBooksBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryBooks', FILENAME = N'C:\Users\Yurii_S\LibraryBooks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryBooks_log', FILENAME = N'C:\Users\Yurii_S\LibraryBooks_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LibraryBooksBD] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryBooksBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryBooksBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryBooksBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryBooksBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryBooksBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryBooksBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryBooksBD] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryBooksBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryBooksBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryBooksBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryBooksBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryBooksBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryBooksBD] SET QUERY_STORE = OFF
GO
USE [LibraryBooksBD]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [LibraryBooksBD]
GO
/****** Object:  Table [dbo].[AssignedRoles]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignedRoles](
	[AuthId] [int] NOT NULL,
	[RoleId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthData]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthData](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[HashPass] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AuthData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[AuthorId] [int] NULL,
	[Page] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] NOT NULL,
	[SurName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[SecondName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Phone] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAndBooks]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAndBooks](
	[UserId] [int] NOT NULL,
	[BookId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAndRoles]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAndRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AuthData] ON 
GO
INSERT [dbo].[AuthData] ([Id], [Login], [HashPass]) VALUES (0, N'admin', N'ABYUOHcUmIVTmGF/mrpzRIzUT76ygHVy5iLTOjN8NukhYc/OkV9jDpP/0ru7WS3I6Q==')
GO
INSERT [dbo].[AuthData] ([Id], [Login], [HashPass]) VALUES (1, N'user', N'AJcUuJIuzn3nII5nQa10C487dCEDB/3qS4hQpYwHTA54yM9xZCVFKYt61eP9HKKmew==')
GO
INSERT [dbo].[AuthData] ([Id], [Login], [HashPass]) VALUES (2, N'user1', N'AOfWLasIJpu2szTs7eY2ovFdPgzgHuk/YZDq1v+UuXz+DqHQbgZ3rAwSMX5hb2m6KQ==')
GO
INSERT [dbo].[AuthData] ([Id], [Login], [HashPass]) VALUES (1001, N'User2', N'AKVKlIGYf9l+JhFko9RHNNcrazVi5hTpHv8ZvSjLSAY2wFSBkxkomB4kol6HBZDIhw==')
GO
SET IDENTITY_INSERT [dbo].[AuthData] OFF
GO
SET IDENTITY_INSERT [dbo].[Author] ON 
GO
INSERT [dbo].[Author] ([Id], [FullName]) VALUES (0, N'Jojo J.J.')
GO
INSERT [dbo].[Author] ([Id], [FullName]) VALUES (1, N'Cesar S.S.')
GO
INSERT [dbo].[Author] ([Id], [FullName]) VALUES (2, N'Cepela S.S.')
GO
INSERT [dbo].[Author] ([Id], [FullName]) VALUES (3, N'SpeadWagon A.A.')
GO
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Page], [Description]) VALUES (0, N'Biographi', 0, 46, N'Adventure')
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Page], [Description]) VALUES (1, N'JoJo''s Bizarre Adventure', 3, 3700, N'ule ule')
GO
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Page], [Description]) VALUES (1001, N'Walker', 1, 100, N'lalalalala')
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (0, N'admin')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'user')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[UserInfo] ([UserId], [SurName], [FirstName], [SecondName], [DateOfBirth], [Phone]) VALUES (1, N'Ivanov', N'Ivan', N'Ivanich', CAST(N'1990-01-10T00:00:00.000' AS DateTime), N'+7-222-222-2222')
GO
INSERT [dbo].[UserInfo] ([UserId], [SurName], [FirstName], [SecondName], [DateOfBirth], [Phone]) VALUES (2, N'Vanilov', N'Vanil', N'Vanilovich', CAST(N'1997-06-11T00:00:00.000' AS DateTime), N'+7-333-333-3333')
GO
INSERT [dbo].[UserInfo] ([UserId], [SurName], [FirstName], [SecondName], [DateOfBirth], [Phone]) VALUES (1001, N'God', N'With', N'You', CAST(N'1989-02-01T00:00:00.000' AS DateTime), N'+7-353-353-3553')
GO
INSERT [dbo].[UsersAndBooks] ([UserId], [BookId]) VALUES (1, 0)
GO
INSERT [dbo].[UsersAndBooks] ([UserId], [BookId]) VALUES (1, 1001)
GO
INSERT [dbo].[UsersAndBooks] ([UserId], [BookId]) VALUES (1001, 0)
GO
INSERT [dbo].[UsersAndRoles] ([UserId], [RoleId]) VALUES (0, 0)
GO
INSERT [dbo].[UsersAndRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[UsersAndRoles] ([UserId], [RoleId]) VALUES (2, 1)
GO
INSERT [dbo].[UsersAndRoles] ([UserId], [RoleId]) VALUES (1001, 1)
GO
INSERT [dbo].[UsersAndRoles] ([UserId], [RoleId]) VALUES (1002, 1)
GO
/****** Object:  Index [IX_UsersAndBooks]    Script Date: 19.07.2021 19:13:04 ******/
ALTER TABLE [dbo].[UsersAndBooks] ADD  CONSTRAINT [IX_UsersAndBooks] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsersAndRoles]    Script Date: 19.07.2021 19:13:04 ******/
ALTER TABLE [dbo].[UsersAndRoles] ADD  CONSTRAINT [IX_UsersAndRoles] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssignedRoles]  WITH CHECK ADD  CONSTRAINT [FK_AssignedRoles_ToAuthData] FOREIGN KEY([AuthId])
REFERENCES [dbo].[AuthData] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AssignedRoles] CHECK CONSTRAINT [FK_AssignedRoles_ToAuthData]
GO
ALTER TABLE [dbo].[AssignedRoles]  WITH CHECK ADD  CONSTRAINT [FK_AssignedRoles_ToRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AssignedRoles] CHECK CONSTRAINT [FK_AssignedRoles_ToRole]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_ToAuthor] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_ToAuthor]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_ToAuthData] FOREIGN KEY([UserId])
REFERENCES [dbo].[AuthData] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_ToAuthData]
GO
ALTER TABLE [dbo].[UsersAndBooks]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndBooks_ToAuthData] FOREIGN KEY([UserId])
REFERENCES [dbo].[AuthData] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndBooks] CHECK CONSTRAINT [FK_UsersAndBooks_ToAuthData]
GO
ALTER TABLE [dbo].[UsersAndBooks]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndBooks_ToBook] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAndBooks] CHECK CONSTRAINT [FK_UsersAndBooks_ToBook]
GO
/****** Object:  StoredProcedure [dbo].[AuthData_Create]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthData_Create]
	@Login nvarchar(50),
	@HashPass nvarchar(MAX),
	@SurName nvarchar(50),
	@FirstName nvarchar(50),
	@SecondName nvarchar(50),
	@DateOfBirth datetime,
	@Phone nvarchar(50)

AS
BEGIN
    INSERT INTO AuthData(Login, HashPass)
	VALUES(@Login, @HashPass)
END
BEGIN
	INSERT INTO UserInfo(UserId, SurName, FirstName, SecondName, DateOfBirth, [Phone])
	VALUES((SELECT MAX(Id) FROM AuthData), @SurName, @FirstName, @SecondName, @DateOfBirth, @Phone)
END
BEGIN
	INSERT INTO UsersAndRoles(UserId, RoleId)
	VALUES((SELECT MAX(Id) FROM AuthData), 1)
END
GO
/****** Object:  StoredProcedure [dbo].[AuthData_DeleteById]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthData_DeleteById]
	@Id int
AS
BEGIN
    DELETE AuthData 
    WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[AuthData_GetByLogin]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthData_GetByLogin]
	@Login nvarchar(50)
AS
BEGIN
	SELECT TOP(1) * FROM AuthData
	WHERE Login = @Login
END
GO
/****** Object:  StoredProcedure [dbo].[AuthData_IsAuthentication]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthData_IsAuthentication] 
	@Login nvarchar(50), 
	@HashPass nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[AuthData]
	WHERE Login = @Login AND HashPass = @HashPass

END
GO
/****** Object:  StoredProcedure [dbo].[Author_Add]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Author_Add]
	@FullName nvarchar(50)
AS
BEGIN
	INSERT INTO Author(FullName)
	VALUES(@FullName)
END
GO
/****** Object:  StoredProcedure [dbo].[Author_DeleteById]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Author_DeleteById]
	@Id INT
AS
BEGIN
	DELETE Author 
    WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[Author_Edit]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Author_Edit]
	@Id INT,
	@FullName nvarchar(50)
AS
BEGIN
	UPDATE Author SET
	FullName = @FullName
	WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[Author_GetAll]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Author_GetAll]
AS
SELECT * FROM Author
return

GO
/****** Object:  StoredProcedure [dbo].[Author_GetByFullName]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Author_GetByFullName]
	@FullName nvarchar(50)
AS
BEGIN
	SELECT * FROM Author
	WHERE FullName = @FullName
END

GO
/****** Object:  StoredProcedure [dbo].[Author_GetById]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Author_GetById]
	@Id int
AS
BEGIN
	SELECT * FROM Author
	WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[AuthorsAndBooks_ExistBooks]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthorsAndBooks_ExistBooks]
@AuthorId int
AS
BEGIN
	SELECT TOP 1 1 FROM Author
	INNER JOIN Book ON Author.Id = Book.AuthorId
	WHERE Author.Id = @AuthorId
END

GO
/****** Object:  StoredProcedure [dbo].[AuthorsAndBooks_GetBooksByAuthorId]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthorsAndBooks_GetBooksByAuthorId]
@AuthorId nvarchar(50)
AS
BEGIN
SELECT Book.Id as Id, 
		Book.Title as Title,
		Book.AuthorId as AuthorId,
		Author.FullName as AuthorFullName,
		Book.Page as Page,
		Book.Description as Description
FROM Book
INNER JOIN Author ON Book.AuthorId = Author.Id
WHERE Author.Id = @AuthorId
END

GO
/****** Object:  StoredProcedure [dbo].[Book_Add]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Book_Add]
	@Title nvarchar(50),
	@AuthorId int,
	@Page int,
	@Description nvarchar(MAX)
AS
BEGIN
	INSERT INTO Book(Title, AuthorId, Page, Description)
	VALUES(@Title, @AuthorId, @Page, @Description)
END

GO
/****** Object:  StoredProcedure [dbo].[Book_DeleteById]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Book_DeleteById]
	@Id INT
AS
BEGIN
	DELETE Book 
    WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[Book_Edit]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Book_Edit]
	@Id INT,
	@Title nvarchar(50),
	@AuthorId INT,
	@Page INT,
	@Description nvarchar(MAX)
AS
BEGIN
	UPDATE Book SET
	Title = @Title,
	AuthorId = @AuthorId,
	Page = @Page,
	Description = @Description
	WHERE Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[Book_GetAll]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Book_GetAll]
AS
BEGIN
SELECT Book.Id as Id, 
		Book.Title as Title,
		Book.AuthorId as AuthorId,
		Author.FullName as AuthorFullName,
		Book.Page as Page,
		Book.Description as Description
FROM Book
INNER JOIN Author ON Book.AuthorId = Author.Id
END

GO
/****** Object:  StoredProcedure [dbo].[Book_GetById]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Book_GetById]
	@Id int
AS
SELECT Book.Id as Id, 
		Book.Title as Title,
		Book.AuthorId as AuthorId,
		Author.FullName as AuthorFullName,
		Book.Page as Page,
		Book.Description as Description
FROM Book
JOIN Author ON Book.AuthorId = Author.Id
	WHERE Book.Id = @Id
return

GO
/****** Object:  StoredProcedure [dbo].[UserInfo_Edit]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserInfo_Edit]
	@UserId int,
	@SurName nvarchar(50),
	@FirstName nvarchar(50),
	@SecondName nvarchar(50),
	@DateOfBirth datetime,
	@Phone nvarchar(50)
AS
BEGIN
	UPDATE UserInfo SET
	SurName = @SurName,
	FirstName = @FirstName,
	SecondName = @SecondName,
	DateOfBirth = @DateOfBirth,
	Phone = @Phone
	WHERE UserId = @UserId
END

GO
/****** Object:  StoredProcedure [dbo].[UserInfo_GetAll]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserInfo_GetAll]
AS
SELECT * FROM UserInfo
return
GO
/****** Object:  StoredProcedure [dbo].[UserInfo_GetById]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserInfo_GetById]
@Id int
AS
SELECT TOP(1) * FROM UserInfo
where UserId = @Id
return
GO
/****** Object:  StoredProcedure [dbo].[UsersAndBooks_Exist]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndBooks_Exist]
	@UserId int,
	@BookId int
AS
BEGIN
	SELECT TOP(1) * FROM UsersAndBooks
	WHERE UserId = @UserId AND BookId = @BookId
END

GO
/****** Object:  StoredProcedure [dbo].[UsersAndBooks_ExistByBookId]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndBooks_ExistByBookId]
@BookId int
AS
BEGIN
	SELECT TOP 1 1 FROM UsersAndBooks 
	WHERE BookId = @BookId
END

GO
/****** Object:  StoredProcedure [dbo].[UsersAndBooks_ExistByUserId]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndBooks_ExistByUserId]
@UserId int
AS
BEGIN
	SELECT TOP 1 1 FROM UsersAndBooks 
	WHERE UserId = @UserId
END

GO
/****** Object:  StoredProcedure [dbo].[UsersAndBooks_GetBooksByUserId]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndBooks_GetBooksByUserId]
@UserId int
AS
BEGIN
SELECT Book.Id as Id, 
		Book.Title as Title,
		Book.AuthorId as AuthorId,
		Author.FullName as AuthorFullName,
		Book.Page as Page,
		Book.Description as Description
FROM UsersAndBooks
INNER JOIN Book ON UsersAndBooks.BookId = Book.Id
INNER JOIN Author ON Book.AuthorId = Author.Id
WHERE UsersAndBooks.UserId = @UserId
END

GO
/****** Object:  StoredProcedure [dbo].[UsersAndBooks_GetBooksUnAvailableByUserId]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndBooks_GetBooksUnAvailableByUserId]
@UserId int
AS
BEGIN
SELECT Book.Id as Id, 
		Book.Title as Title,
		Book.AuthorId as AuthorId,
		Author.FullName as AuthorFullName,
		Book.Page as Page,
		Book.Description as Description
FROM  Book
INNER JOIN Author ON Book.AuthorId = Author.Id
LEFT JOIN 
(
	SELECT Book.Id as Id
	FROM UsersAndBooks
	INNER JOIN Book ON UsersAndBooks.BookId = Book.Id
	WHERE UsersAndBooks.UserId = @UserId
)	AS BooksByUserId
ON BooksByUserId.Id = Book.Id
WHERE BooksByUserId.Id is NULL
END

GO
/****** Object:  StoredProcedure [dbo].[UsersAndBooks_GetUsersByBookId]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndBooks_GetUsersByBookId]
@BookId int
AS
BEGIN
SELECT UserInfo.UserId as UserId, 
		UserInfo.SurName as SurName,
		UserInfo.FirstName as FirstName,
		UserInfo.SecondName as SecondName,
		UserInfo.DateOfBirth as DateOfBirth,
		UserInfo.Phone as Phone
FROM UsersAndBooks
INNER JOIN UserInfo ON UsersAndBooks.UserId = UserInfo.UserId
WHERE UsersAndBooks.BookId = @BookId
END

GO
/****** Object:  StoredProcedure [dbo].[UsersAndBooks_GetUsersUnAvailableByBookId]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndBooks_GetUsersUnAvailableByBookId]
@BookId int
AS
BEGIN
SELECT UserInfo.UserId as UserId, 
		UserInfo.SurName as SurName,
		UserInfo.FirstName as FirstName,
		UserInfo.SecondName as SecondName,
		UserInfo.DateOfBirth as DateOfBirth,
		UserInfo.Phone as Phone
FROM UserInfo
LEFT JOIN 
(
SELECT UserInfo.UserId as UserId
FROM UsersAndBooks
INNER JOIN UserInfo ON UsersAndBooks.UserId = UserInfo.UserId
WHERE UsersAndBooks.BookId = @BookId
) AS UsersByBookId ON UsersByBookId.UserId = UserInfo.UserId
WHERE UsersByBookId.UserId is NULL
END

GO
/****** Object:  StoredProcedure [dbo].[UsersAndBooks_GiveBookToUser]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndBooks_GiveBookToUser]
@BookId int,
@UserId int
AS
BEGIN
	INSERT INTO UsersAndBooks (BookId, UserId)
	VALUES (@BookId, @UserId)
END

GO
/****** Object:  StoredProcedure [dbo].[UsersAndBooks_ReturnBookByUser]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndBooks_ReturnBookByUser]
@BookId int,
@UserId int
AS
BEGIN
	DELETE FROM UsersAndBooks 
	WHERE BookId = @BookId AND UserId = @UserId
END

GO
/****** Object:  StoredProcedure [dbo].[UsersAndRoles_GetAll]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndRoles_GetAll]
AS
	SELECT AuthData.Id as UserId, Role.Id as RoleId, AuthData.Login as UserLogin, Role.Name as RoleName FROM AuthData
	JOIN UsersAndRoles on AuthData.Id = UsersAndRoles.UserId
	JOIN Role on UsersAndRoles.RoleId = Role.Id
return
GO
/****** Object:  StoredProcedure [dbo].[UsersAndRoles_GetByLogin]    Script Date: 19.07.2021 19:13:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersAndRoles_GetByLogin]
	@Login nvarchar(50)
AS
	SELECT Top(1) AuthData.Id as UserId, Role.Id as RoleId, AuthData.Login as UserLogin, Role.Name as RoleName FROM AuthData
	JOIN UsersAndRoles on AuthData.Id = UsersAndRoles.UserId
	JOIN Role on UsersAndRoles.RoleId = Role.Id
	where AuthData.Login = @Login 
return
GO
USE [master]
GO
ALTER DATABASE [LibraryBooksBD] SET  READ_WRITE 
GO
