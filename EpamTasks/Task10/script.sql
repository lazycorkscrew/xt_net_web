USE [master]
GO
/****** Object:  Database [UsersAndRewards]    Script Date: 24.02.2020 14:56:23 ******/
CREATE DATABASE [UsersAndRewards] ON  PRIMARY 
( NAME = N'UsersAndRewards', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\UsersAndRewards.mdf' , SIZE = 9216KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UsersAndRewards_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\UsersAndRewards_log.ldf' , SIZE = 10176KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UsersAndRewards] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsersAndRewards].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsersAndRewards] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsersAndRewards] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsersAndRewards] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsersAndRewards] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsersAndRewards] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsersAndRewards] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsersAndRewards] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsersAndRewards] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsersAndRewards] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsersAndRewards] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsersAndRewards] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsersAndRewards] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsersAndRewards] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsersAndRewards] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsersAndRewards] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsersAndRewards] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsersAndRewards] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsersAndRewards] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsersAndRewards] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsersAndRewards] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsersAndRewards] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsersAndRewards] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsersAndRewards] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UsersAndRewards] SET  MULTI_USER 
GO
ALTER DATABASE [UsersAndRewards] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsersAndRewards] SET DB_CHAINING OFF 
GO
USE [UsersAndRewards]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Awards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Image] [varbinary](max) NULL,
	[Description] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LinksUsersAwards]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinksUsersAwards](
	[id_user] [int] NOT NULL,
	[id_award] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rights]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rights](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rank] [nvarchar](20) NOT NULL,
	[Power] [smallint] NOT NULL,
 CONSTRAINT [PK_Rights] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Rights] UNIQUE NONCLUSTERED 
(
	[Rank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Settings]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Settings](
	[DefaultImage] [varbinary](max) NULL,
	[DefaultAwardImage] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NULL,
	[Avatar] [varbinary](max) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Rights] [int] NOT NULL CONSTRAINT [DF_Users_Rights]  DEFAULT ((1)),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[LinksUsersAwards]  WITH CHECK ADD  CONSTRAINT [FK_LinksUsersAwards_Awards] FOREIGN KEY([id_award])
REFERENCES [dbo].[Awards] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LinksUsersAwards] CHECK CONSTRAINT [FK_LinksUsersAwards_Awards]
GO
ALTER TABLE [dbo].[LinksUsersAwards]  WITH CHECK ADD  CONSTRAINT [FK_LinksUsersAwards_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LinksUsersAwards] CHECK CONSTRAINT [FK_LinksUsersAwards_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Rights] FOREIGN KEY([Rights])
REFERENCES [dbo].[Rights] ([Id])
ON UPDATE SET DEFAULT
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Rights]
GO
/****** Object:  StoredProcedure [dbo].[CheckLoginPassword]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CheckLoginPassword]
@login nvarchar(50),
@password nvarchar(50)
AS
BEGIN
	select top(1) CONVERT(NVARCHAR(50), HashBytes('MD5', 'epamtasks'+@login+@password), 2) from Users where Login = @login and Password = @password
END

GO
/****** Object:  StoredProcedure [dbo].[CheckRightsVolume]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CheckRightsVolume]
@login nvarchar(50),
@password nvarchar(50)
	
AS
BEGIN
select r.Power from Users u
inner join Rights r on u.Rights = r.id
where u.Login = @login and u.Password = CONVERT(NVARCHAR(50), HashBytes('MD5', @password), 2)
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAward]
@id bigint
	
AS
BEGIN
	delete from Awards where Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
@id bigint
	
AS
BEGIN
	delete from Users where Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DepriveUserOfAward]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DepriveUserOfAward]
@user_id bigint,
@award_id bigint
	
AS
BEGIN
delete top(1) from LinksUsersAwards where id_user = @user_id and id_award = @award_id
END

GO
/****** Object:  StoredProcedure [dbo].[GetImageByAwardId]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetImageByAwardId]
@award_id bigint
AS
BEGIN
	SELECT Image from Awards where Id = @award_id
END


GO
/****** Object:  StoredProcedure [dbo].[GetImageByUserId]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetImageByUserId]
@user_id bigint
AS
BEGIN
	SELECT Avatar from Users where Id = @user_id
END

GO
/****** Object:  StoredProcedure [dbo].[GiveAwardToUser]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GiveAwardToUser]
@user_id bigint,
@award_id bigint
	
AS
BEGIN
	insert into LinksUsersAwards (id_user, id_award) values (@user_id, @award_id)
END

GO
/****** Object:  StoredProcedure [dbo].[RegisterAward]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[RegisterAward]
@title NVARCHAR(50)
	
AS
BEGIN
	insert into Awards (Title) values (@title)
END



GO
/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[RegisterUser]
    @name NVARCHAR(50),
    @dateofbirth DATE,
    @login NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
	insert into Users(Name, DateOfBirth, Login, Password) values (@name, @dateofbirth, @login, @password)
END



GO
/****** Object:  StoredProcedure [dbo].[SelectAward]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SelectAward]
@award_id int
	
AS
BEGIN
	select Id, Title, Description from Awards  
	where Id = @award_id
END



GO
/****** Object:  StoredProcedure [dbo].[SelectAwards]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SelectAwards]
	
AS
BEGIN
	select Id, Title, Description from Awards
END


GO
/****** Object:  StoredProcedure [dbo].[SelectDefaultAwardImage]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SelectDefaultAwardImage]
AS
BEGIN
	select DefaultAwardImage from Settings
END



GO
/****** Object:  StoredProcedure [dbo].[SelectDefaultImage]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SelectDefaultImage]
AS
BEGIN
	select DefaultImage from Settings
END


GO
/****** Object:  StoredProcedure [dbo].[SelectFullUserInfo]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SelectFullUserInfo]
@user_id bigint
	
AS
BEGIN
select u.id, u.Name, u.DateOfBirth, r.Rank from Users u
inner join Rights r on u.Rights = r.id
where u.id = @user_id
END


GO
/****** Object:  StoredProcedure [dbo].[SelectFullUserInfoByLoginAndPass]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SelectFullUserInfoByLoginAndPass]
@login nvarchar(50),
@password nvarchar(50)

AS
BEGIN
select u.id, u.Name, u.DateOfBirth, r.Rank, r.Power from Users u
inner join Rights r on u.Rights = r.id
where Login = @login and Password = @password
END




GO
/****** Object:  StoredProcedure [dbo].[SelectRights]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SelectRights]
	
AS
BEGIN
	select Id, Rank from Rights
END



GO
/****** Object:  StoredProcedure [dbo].[SelectShortUserInfo]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SelectShortUserInfo]
@user_id bigint
	
AS
BEGIN
select u.id, u.Name from Users u
where u.id = @user_id
END



GO
/****** Object:  StoredProcedure [dbo].[SelectShortUsersInfo]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SelectShortUsersInfo]
@count int,
@offset int
	
AS
BEGIN
select top(@count) id, Name from Users where id not in(select top(@offset) id from Users)
END




GO
/****** Object:  StoredProcedure [dbo].[SelectUserAwards]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SelectUserAwards]
@user_id bigint
	
AS
BEGIN
	select a.id, a.Title from Users u
	inner join LinksUsersAwards lua on u.Id = lua.id_user
	inner join Awards a on lua.id_award = a.Id
	where u.id = @user_id
	order by a.Title
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateRights]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[UpdateRights]
@user_id int,
@right_id int

AS
BEGIN
update top(1) Users set Rights = @right_id where Id = @user_id
END




GO
/****** Object:  StoredProcedure [dbo].[UploadDefaultAwardImage]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UploadDefaultAwardImage]
@image varbinary(max)
AS
BEGIN
insert into Settings (DefaultAwardImage) values (@image)
    
END


GO
/****** Object:  StoredProcedure [dbo].[UploadDefaultImage]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UploadDefaultImage]
@image varbinary(max)
AS
BEGIN
insert into Settings (DefaultImage) values (@image)
    
END

GO
/****** Object:  StoredProcedure [dbo].[UploadImageToAward]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UploadImageToAward]
    @award_id int,
	@image varbinary(max)
AS
BEGIN
	update top(1) Awards set Image = @image where Id = @award_id
END


GO
/****** Object:  StoredProcedure [dbo].[UploadImageToUser]    Script Date: 24.02.2020 14:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UploadImageToUser]
    @user_id int,
	@image varbinary(max)
AS
BEGIN
	update top(1) Users set Avatar = @image where Id = @user_id
END


GO
USE [master]
GO
ALTER DATABASE [UsersAndRewards] SET  READ_WRITE 
GO
