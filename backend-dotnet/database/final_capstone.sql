USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

/****** Object:  Database [final_capstone]    Script Date: 8/12/2020 1:26:41 PM ******/
CREATE DATABASE [final_capstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'final_capstone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\final_capstone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'final_capstone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\final_capstone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [final_capstone] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [final_capstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [final_capstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [final_capstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [final_capstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [final_capstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [final_capstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [final_capstone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [final_capstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [final_capstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [final_capstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [final_capstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [final_capstone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [final_capstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [final_capstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [final_capstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [final_capstone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [final_capstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [final_capstone] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [final_capstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [final_capstone] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [final_capstone] SET  MULTI_USER 
GO
ALTER DATABASE [final_capstone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [final_capstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [final_capstone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [final_capstone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [final_capstone] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [final_capstone] SET QUERY_STORE = OFF
GO
USE [final_capstone]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/12/2020 1:26:41 PM ******/
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
/****** Object:  Table [dbo].[Comment]    Script Date: 8/12/2020 1:26:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[PostId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Author] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forum]    Script Date: 8/12/2020 1:26:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forum](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Forum] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 8/12/2020 1:26:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[ForumId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IMG_URL] [nvarchar](max) NULL,
	[Author] [nvarchar](max) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UpdatedComment]    Script Date: 8/12/2020 1:26:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpdatedComment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[CommentId] [int] NOT NULL,
 CONSTRAINT [PK_UpdatedComment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UpdatedPost]    Script Date: 8/12/2020 1:26:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpdatedPost](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[PostId] [int] NOT NULL,
 CONSTRAINT [PK_UpdatedPost] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_forum_favorite]    Script Date: 8/12/2020 1:26:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_forum_favorite](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ForumId] [int] NOT NULL,
 CONSTRAINT [PK_user_forum_favorite] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_forum_moderator]    Script Date: 8/12/2020 1:26:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_forum_moderator](
	[RelationID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[ForumName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_user_forum_moderator] PRIMARY KEY CLUSTERED 
(
	[RelationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 8/12/2020 1:26:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password_hash] [varchar](200) NOT NULL,
	[salt] [varchar](200) NOT NULL,
	[user_role] [varchar](50) NOT NULL,
	[profilePicture] [varchar](2083) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votes]    Script Date: 8/12/2020 1:26:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[VoteId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PostId] [int] NULL,
	[CommentId] [int] NULL,
	[VoteType] [int] NOT NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[VoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200810172537_Initial', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200812001746_FavoriteForumModel', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200812002059_FavoriteForumModel2', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200812010951_FavoriteForumModelChange', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200812011210_FavoriteForumModelChange2', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200812024332_SwitchedToDateTime', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200812172419_MadeCommentIdAndPostIdNullableInVoteModel', N'2.2.6-servicing-10079')
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([ID], [Title], [Body], [Date], [PostId], [ParentId], [Author]) VALUES (1, NULL, N'I completely agree!', CAST(N'2020-08-09T00:00:00.0000000' AS DateTime2), 1, NULL, N'josiah')
INSERT [dbo].[Comment] ([ID], [Title], [Body], [Date], [PostId], [ParentId], [Author]) VALUES (2, NULL, N'You have thought a lot about this...', CAST(N'2020-08-09T00:00:00.0000000' AS DateTime2), 2, NULL, N'brittany')
INSERT [dbo].[Comment] ([ID], [Title], [Body], [Date], [PostId], [ParentId], [Author]) VALUES (3, NULL, N'I have never seen that show. Does the first season stream anywhere?', CAST(N'2020-08-09T00:00:00.0000000' AS DateTime2), 3, NULL, N'schmidty the clam')
INSERT [dbo].[Comment] ([ID], [Title], [Body], [Date], [PostId], [ParentId], [Author]) VALUES (4, NULL, N'How am I even responding?', CAST(N'2020-08-09T00:00:00.0000000' AS DateTime2), 4, NULL, N'user')
INSERT [dbo].[Comment] ([ID], [Title], [Body], [Date], [PostId], [ParentId], [Author]) VALUES (5, NULL, N'Oh my God! Yes!', CAST(N'2020-08-09T00:00:00.0000000' AS DateTime2), 5, NULL, N'brittany')
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
SET IDENTITY_INSERT [dbo].[Forum] ON 

INSERT [dbo].[Forum] ([ID], [Title], [Body], [Date]) VALUES (1, N'Video Games', N'Conversations regarding any and all video games', CAST(N'2020-08-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Forum] ([ID], [Title], [Body], [Date]) VALUES (2, N'Movies', N'Conversations regarding any and all movies', CAST(N'2020-08-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Forum] ([ID], [Title], [Body], [Date]) VALUES (3, N'TV Shows', N'Conversations regarding any and all TV shows', CAST(N'2020-08-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Forum] ([ID], [Title], [Body], [Date]) VALUES (4, N'Books', N'Conversations regarding any and all Books', CAST(N'2020-08-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Forum] ([ID], [Title], [Body], [Date]) VALUES (5, N'.NET', N'Conversations regarding how .NET is the best', CAST(N'2020-08-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Forum] ([ID], [Title], [Body], [Date]) VALUES (6, N'Music', N'Conversations regarding any and all music', CAST(N'2020-08-06T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Forum] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (1, N'CoD warzone', N'Ya''ll need an anti-cheat. This is getting ridiculous. You guys are worth tens of billions. Download some free AVG or something.', CAST(N'2020-08-01T00:00:00.0000000' AS DateTime2), 1, 3, N'https://upload.wikimedia.org/wikipedia/en/7/71/COD_Warzone_cover_art.jpg', N'sam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (2, N'The Room - Flower Shop', N'This dude bought flowers one time in the whole movie but the florist calls him her favorite customer. A customer who she did not recognize immediately. Then Tommy shows the most genuine emotion of the whole film saying hi to the dog. He has her keep the change for the transaction, because he''s a baller I guess. Then, to the chagrin of everyone in the shop, the owner shouts out loud that Tommy is indeed her favorite customer. Somehow.', CAST(N'2020-08-02T00:00:00.0000000' AS DateTime2), 2, 3, N'https://www.sbs.com.au/movies/sites/sbs.com.au.film/files/styles/body_image/public/the_room_favourite_customer.jpg?itok=vWVIpPKB&mtime=1517785643', N'sam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (3, N'John Doe', N'This was a fantastic show about a super genius with amnesia about who he is or where he came from. He of course helps the police solve crimes. And games the stock market to become rich. They left me on huge cliffhanger at the end of season 1 and it did not get picked back up. I''m quite upset about it.', CAST(N'2020-08-03T00:00:00.0000000' AS DateTime2), 3, 3, N'https://static.next-episode.net/tv-shows-images/big/john-doe.jpg', N'sam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (4, N'Song of Ice and Fire', N'So I read the first the first 4 books in only 2 weeks. I loved them. I do need to finish book 5 as well. But if this dude doesn''t finish the series and I''m left With the TV show I didn''t watch, I will be very disappointed.', CAST(N'2020-08-04T00:00:00.0000000' AS DateTime2), 4, 3, NULL, N'sam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (5, N'.NET Squad!', N'We are champions. You folks have been fantastic and I''m glad I got to know you all.', CAST(N'2020-08-05T00:00:00.0000000' AS DateTime2), 5, 3, NULL, N'sam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (6, N'OutKast', N'I absolutely love Andre 3000 and Big Boi. This group could easily be the GOATs and they just don''t seem to enter the conversation enough. What''s up with that?', CAST(N'2020-08-06T00:00:00.0000000' AS DateTime2), 6, 3, N'https://cdn.pitchfork.com/content/stankonizzzz.jpg', N'sam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (7, N'ESO - Elder Scrolls Online', N'So I have been on a huge Elder Scrolls kick as of late. I started with modding the hell out of Skyrim and doing another playthrough. But I know it so well I decided to play Oblivion again. Turns out I still remember the game incredibly well too. This led me to ESO and my god I am looving it. The quests are knew and interesting and the environments are beautiful and unique. I am truly enjoying it.', CAST(N'2020-08-12T00:00:00.0000000' AS DateTime2), 1, 3, N'https://esosslfiles-a.akamaihd.net/cms/2018/05/94686c25494074a0efeec9644e629db6.jpg', N'sam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (8, N'IT', N'It definitely has it''s moments. In general I enjoy the book. But, it is way too long. It needs to be trimmed down way more. Plus, what kind of drug fueled existential crisis is that ending? Stephen King makes us question our place in the universe by presenting us with a Boggart esque alien. Way out of left field...', CAST(N'2020-08-13T00:00:00.0000000' AS DateTime2), 2, 5, N'https://m.media-amazon.com/images/I/41nngxCNKxL.jpg', N'brittany')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (9, N'Never Gonna Give You Up', N'I know this song is a meme and all, but it actually slaps. I love this song and listen to it whenever I get RickRolled', CAST(N'2020-08-13T00:00:00.0000000' AS DateTime2), 6, 6, N'https://www.kxan.com/wp-content/uploads/sites/40/2017/07/rick-astley-never-gonna-give-you-up_35327903_ver1.0.jpg', N'schmidty the clam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (10, N'It doesn''t even take a year...', N'I look at stuff from a week ago and just trust it works.', CAST(N'2020-08-13T12:18:00.0000000' AS DateTime2), 5, 6, N'https://i.redd.it/3wg91df5qjz11.png', N'josiah')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (11, N'44% of American households subscribed to cable service in 2019.', N'Like why? Every streaming service has stronger shows than what cable provides now. Hell, netflix gives new memes every month practically. I just don''t understand why the market share is still so high.', CAST(N'2020-08-13T12:18:00.0000000' AS DateTime2), 3, 6, NULL, N'schmidty the clam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (12, N'Sequels that are better than the original. Let''s talk about it.', N'This is one of my favorite conversations to have about movies. It really seperates your friends with taste from your friends that are idiots. I''ll start by the way: Terminator 2', CAST(N'2020-08-05T00:00:00.0000000' AS DateTime2), 2, 3, NULL, N'sam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (13, N'Killjoy is an understatement...', N'Right now, Killjoy is wayyyyy to strong. She can delay a defuse for a solid 8 seconds even after death simply by leaving her annoying little grenades on the bomb. And who decided her E should be a whole turret!? She might need to be a little nerfed. What do you all think?', CAST(N'2020-08-13T03:33:00.0000000' AS DateTime2), 1, 4, N'https://image-cdn.essentiallysports.com/wp-content/uploads/20200805114024/valorant___killjoy_by_snatti89_de2b3wh-fullview-800x450.jpg', N'josiah')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (14, N'League of Legends: ELO HELL is the worst for ADC mains...', N'This is because ADC''s need more items then all other roles to reach their power spike. I can win my lane and still not be strong enough to carry the game for my team until 20 minutes +. That, along with the fact that in ELO HELL most players don''t know how to peel for the ADC. Riot needs to add more items for ADC''s to build that allow for self peeling capabilities!', CAST(N'2020-08-13T09:53:00.0000000' AS DateTime2), 1, 6, N'https://cdn1.dotesports.com/wp-content/uploads/2019/09/12195522/league-of-legends.jpg', N'schmidty the clam')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (15, N'Sherlock (BBC series)', N'This show is amazing. Although the episodes are each roughly the length of a movie, it''s well worth it. You could skip the second episode of season 1 if you want but the rest are golden. The characters develop in fantastic ways, there are good twists that make each story more modern and different than the books, and it''s quite funny at times. I really cannot recommend this show enough.', CAST(N'2020-08-06T11:22:00.0000000' AS DateTime2), 3, 4, N'https://cdn.thebuzzpaper.com/wp-content/uploads/2020/03/sherlock-season-4-netflix-696x392.jpg', N'josiah')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (16, N'Hannibal', N'is interesting in parts, sometimes a little TOO edgy. Like, we get it, he eats people. Where’s the love story? This show is like extra edgy dexter.', CAST(N'2020-08-09T00:00:00.0000000' AS DateTime2), 3, 5, NULL, N'brittany')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (17, N'Doctor who', N'okay so I’m rewatching starting with Christopher eccleston and OMG I forgot how cheesy the first season is! I love Rose but plastic coming to life to take over the world, gas masks that melt into your face, garbage cans on wheels, and that whole “moisturize me” stuff from ep.2! So funny.', CAST(N'2020-08-10T07:24:00.0000000' AS DateTime2), 3, 5, NULL, N'brittany')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (18, N' The Stormlight Archives', N'This book series is an epic fantasy series that will eventually span 10 books. At the moment there are only 3 books released but they are quite considerable in length. So much happens in each book that it feels like a movie trilogy could be made from each. The story also deals with interesting ethical dilemmas and interacts with current issues in a very subtle, well-executed way. Magic is very thought out and relationships feel dynamic and real. This is my favorite book series so far.', CAST(N'2020-08-06T11:22:00.0000000' AS DateTime2), 4, 4, NULL, N'josiah')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (19, N'About Time', N'This movie is freaking awesome. Though it leans towards the chick-flick/feel good genre, it''s about a young man who learns he can time travel: it''s an inherited trait from his father! This movie made me feel like living life to the fullest every day, giving me a sense of gratitude for every moment. I highly recommend it. Has anyone else seen it?', CAST(N'2020-08-10T07:24:00.0000000' AS DateTime2), 2, 4, N'https://i2.wp.com/media.aintitcool.com/media/uploads/2013/nordling/abouttime.jpg', N'josiah')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (20, N'Sarah j Maas, a thread:', N'this woman changed my life. The writing is fantastic, twists and turns everywhere, and truly fantastical worlds. The throne of glass series is my favorite—starts off with the MC as a teenager and over the books she grows up and saves the world. A court of thrones and roses—DEFINITELY an adult book, but action and romance packed. Now, those two series are a++ but let’s talk about  the new series Crescent City... MAAAAN I had so many high hopes for this book. Wonderful world creation but DANG the story flops. I’m big bummed.', CAST(N'2020-08-07T01:45:00.0000000' AS DateTime2), 4, 5, NULL, N'brittany')
INSERT [dbo].[Post] ([ID], [Title], [Body], [Date], [ForumId], [UserId], [IMG_URL], [Author]) VALUES (21, N'Fallout 76', N'okay we get it bethesda, your mommy and daddy told you to make a battle royale and you TRIED to keep it a fallout game. Well you didn’t. It sucks. It’s not a battle royale OR a fallout game. Smh.', CAST(N'2020-08-14T06:13:00.0000000' AS DateTime2), 1, 5, N'https://upload.wikimedia.org/wikipedia/en/thumb/0/06/Fallout_76_cover.jpg/220px-Fallout_76_cover.jpg', N'brittany')
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[user_forum_favorite] ON 

INSERT [dbo].[user_forum_favorite] ([ID], [UserId], [ForumId]) VALUES (1, 3, 1)
INSERT [dbo].[user_forum_favorite] ([ID], [UserId], [ForumId]) VALUES (2, 3, 2)
SET IDENTITY_INSERT [dbo].[user_forum_favorite] OFF
GO
SET IDENTITY_INSERT [dbo].[user_forum_moderator] ON 

INSERT [dbo].[user_forum_moderator] ([RelationID], [UserId], [Username], [ForumName]) VALUES (1, 3, N'schmidty the clam', N'Video Games')
INSERT [dbo].[user_forum_moderator] ([RelationID], [UserId], [Username], [ForumName]) VALUES (2, 3, N'sam', N'Movies')
INSERT [dbo].[user_forum_moderator] ([RelationID], [UserId], [Username], [ForumName]) VALUES (3, 3, N'sam', N'TV Shows')
INSERT [dbo].[user_forum_moderator] ([RelationID], [UserId], [Username], [ForumName]) VALUES (4, 3, N'brittany', N'Books')
INSERT [dbo].[user_forum_moderator] ([RelationID], [UserId], [Username], [ForumName]) VALUES (5, 3, N'brittany', N'.NET')
INSERT [dbo].[user_forum_moderator] ([RelationID], [UserId], [Username], [ForumName]) VALUES (6, 3, N'josiah', N'Music')
SET IDENTITY_INSERT [dbo].[user_forum_moderator] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (1, N'user', N'Jg45HuwT7PZkfuKTz6IB90CtWY4=', N'LHxP4Xh7bN0=', N'user')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (2, N'admin', N'YhyGVQ+Ch69n4JMBncM4lNF/i9s=', N'Ar/aB2thQTI=', N'admin')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (3, N'sam', N'OrNuA9Fu7vxbs4WPn8qQvp4HFTI=', N'TdROYVCkuCs=', N'moderator')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (4, N'josiah', N'WmjkAdwAj2Ik7ACZOHk2bmJfqVk=', N'MwmDXHyQWJQ=', N'moderator')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (5, N'brittany', N'Up+Eq5kebpL1mQZqUn7I/1vjBsM=', N'0wK8/paA24U=', N'moderator')
INSERT [dbo].[users] ([user_id], [username], [password_hash], [salt], [user_role]) VALUES (6, N'schmidty the clam', N'Ba/GvNl+IpzuJ5+mN9FRs8kzgew=', N'R7zbf5bIeiY=', N'moderator')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[Votes] ON 

INSERT [dbo].[Votes] ([VoteId], [UserId], [PostId], [CommentId], [VoteType]) VALUES (3, 7, 1, NULL, 1)
INSERT [dbo].[Votes] ([VoteId], [UserId], [PostId], [CommentId], [VoteType]) VALUES (4, 3, 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Votes] OFF
GO
USE [master]
GO
ALTER DATABASE [final_capstone] SET  READ_WRITE 
GO
