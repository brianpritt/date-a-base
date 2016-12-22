USE [date_a_base]
GO
/****** Object:  Table [dbo].[matches]    Script Date: 12/22/2016 2:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[matches](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user1_id] [int] NULL,
	[user2_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[messages]    Script Date: 12/22/2016 2:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sender_id] [int] NULL,
	[receiver_id] [int] NULL,
	[body] [varchar](max) NULL,
	[viewed] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[photos]    Script Date: 12/22/2016 2:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[photos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[url] [varchar](max) NULL,
	[profile] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[state]    Script Date: 12/22/2016 2:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[state](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tags]    Script Date: 12/22/2016 2:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tags_users]    Script Date: 12/22/2016 2:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tags_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[tag_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 12/22/2016 2:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](255) NULL,
	[last_name] [varchar](255) NULL,
	[zip_code] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[phone_number] [varchar](255) NULL,
	[about_me] [varchar](255) NULL,
	[tag_line] [varchar](255) NULL,
	[user_name] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[gender_identity] [int] NULL,
	[seeking_gender] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[photos] ON 

INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (56, 1539, N'https://pbs.twimg.com/profile_images/378800000822867536/3f5a00acf72df93528b6bb7cd0a4fd0c.jpeg', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (59, 1539, N'https://pbs.twimg.com/profile_images/378800000822867536/3f5a00acf72df93528b6bb7cd0a4fd0c.jpeg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (61, 1540, N'https://cdn.thinglink.me/api/image/727110550026190849/1240/10/scaletowidth', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (62, 1540, N'https://cdn.thinglink.me/api/image/727110550026190849/1240/10/scaletowidth', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (63, 1540, N'https://cdn.thinglink.me/api/image/727110550026190849/1240/10/scaletowidth', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (64, 1540, N'https://cdn.thinglink.me/api/image/727110550026190849/1240/10/scaletowidth', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (65, 1541, N'https://cdn.thinglink.me/api/image/727110550026190849/1240/10/scaletowidth', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (66, 1542, N'https://s-media-cache-ak0.pinimg.com/600x315/93/01/c5/9301c53fe757fa042d66a4f439ad2582.jpg', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (67, 1543, N'https://pbs.twimg.com/profile_images/378800000822867536/3f5a00acf72df93528b6bb7cd0a4fd0c.jpeg', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (68, 1543, N'https://pbs.twimg.com/profile_images/378800000822867536/3f5a00acf72df93528b6bb7cd0a4fd0c.jpeg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (72, 1547, N'https://s-media-cache-ak0.pinimg.com/originals/ed/a6/4a/eda64a9f3c041693eed936acc94041da.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (73, 1548, N'http://i.imgur.com/Kzk9I8o.png', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (77, 1551, N'https://cdn.meme.am/cache/instances/folder626/68550626.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (78, 1552, N'https://a1-videos.myspacecdn.com/videos02/193/1c69fe49412344b8acaf7937f352834c/1920w.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (79, 1553, N'https://avatars1.githubusercontent.com/u/706659?v=3&s=400', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (80, 1554, N'https://v.cdn.vine.co/v/avatars/7ca9cc17-cee1-4a18-b164-3b168620ae50.jpg?versionId=foVXR2SdfKttCLNoiSY0t_SHO3896sT3', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (86, 1559, N'http://previously.tv/m/kotm-cartoonsplural-full.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (87, 1560, N'https://i.redd.it/a7u21zjpq3wx.gif', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (88, 1561, N'https://images-na.ssl-images-amazon.com/images/M/MV5BMTM0MzM3MTg3MF5BMl5BanBnXkFtZTcwNDcwODE0Nw@@._V1_UX214_CR0,0,214,317_AL_.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (89, 1562, N'https://thecreatorsproject-images.vice.com/content-images/contentimage/no-slug/4199b9e20c28a5f8a67f192f59f75541.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (90, 1563, N'http://www.defenders.org/sites/default/files/bobcat-stephan-lins-dpc.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (91, 1564, N'http://images.clipartpanda.com/superman-clipart-superman-logo-clip-art.png', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (92, 1565, N'http://www.drodd.com/images15/clip-art8.png', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (97, 1570, N'http://southparkstudios.mtvnimages.com/shared/faqs/2012/jan/1_19_12_PhilCollins.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (98, 1571, N'https://upload.wikimedia.org/wikipedia/commons/6/62/US_Nickel_2013_Obv.png', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (99, 1572, N'http://images.clipartpanda.com/kids-computer-lab-clipart-4ibKGKGbT.jpeg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (101, 1574, N'http://travelchannel.sndimg.com/content/dam/images/travel/fullset/2014/12/3/top-10-caribbean-beaches-eagle-beach-aruba.jpg.rend.tccom.1280.960.jpeg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (102, 1575, N'https://i.ytimg.com/vi/73d8pMnMbKg/maxresdefault.jpg', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (103, 1575, N'https://s-media-cache-ak0.pinimg.com/736x/c9/e3/b4/c9e3b413bc3b52518630d0ebacb867bf.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (104, 1576, N'https://pbs.twimg.com/profile_images/639575983796817920/vc1If6Nd.png', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (57, 1539, N'https://pbs.twimg.com/profile_images/378800000822867536/3f5a00acf72df93528b6bb7cd0a4fd0c.jpeg', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (58, 1539, N'https://pbs.twimg.com/profile_images/378800000822867536/3f5a00acf72df93528b6bb7cd0a4fd0c.jpeg', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (60, 1540, N'https://cdn.thinglink.me/api/image/727110550026190849/1240/10/scaletowidth', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (69, 1544, N'http://cdn.modernfarmer.com/wp-content/uploads/2014/12/squirrel.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (70, 1545, N'http://www.huntwildwing.com/wp-content/uploads/2016/07/bear.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (71, 1546, N'http://images.contentful.com/7h71s48744nc/20P4xx0dkIiK0kSuOgmMEc/e4fd3833c3fa42ee359a3af52464baaf/joe-dirt.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (74, 1549, N'http://cdn0.dailydot.com/cache/3b/d0/3bd07a9c0aae0f9d7f2e03378b207a74.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (75, 1550, N'https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&ved=0ahUKEwi378C154jRAhVC2WMKHQrGAYUQjBwIBA&url=http%3A%2F%2Fimages.memes.com%2Fmeme%2F693841&bvm=bv.142059868,d.cGc&psig=AFQjCNFiPO0bFCFpdoWbflKXJcRTwULFuQ&ust=1482530706095806', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (76, 1550, N'http://i1.kym-cdn.com/photos/images/facebook/000/011/420/Duck.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (81, 1555, N'http://pbs.twimg.com/media/BjsfOQoIYAAjlB9.jpg:medium', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (82, 1555, N'https://lh4.googleusercontent.com/-unWAaSFfgTs/AAAAAAAAAAI/AAAAAAAAADU/jsqBpC1MtDU/photo.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (83, 1556, N'http://cbcdn2.gp-static.com/media_library/image/1579/large_CBrinleeJr_hiking007.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (84, 1557, N'https://lh5.googleusercontent.com/-yE7IP7HRZCs/AAAAAAAAAAI/AAAAAAAAAD0/PBzbGaxpc74/photo.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (85, 1558, N'https://scontent.cdninstagram.com/hphotos-xpa1/t51.2885-15/e15/10684349_1476231305963640_82374729_n.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (93, 1566, N'http://65.media.tumblr.com/tumblr_l3xsboCdoc1qcq0mho1_400.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (94, 1567, N'http://assets.nydailynews.com/polopoly_fs/1.1180586.1349944865!/img/httpImage/image.jpg_gen/derivatives/landscape_1200/wendys11n-1-web.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (95, 1568, N'http://inthesetimes.com/images/working/Screen_Shot_2015-01-22_at_4.57.37_PM.png', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (96, 1569, N'https://timedotcom.files.wordpress.com/2015/03/hamburglar.gif', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (100, 1573, N'http://vignette1.wikia.nocookie.net/spongebob/images/a/a0/Sandy_Cheeks.svg/revision/latest/scale-to-width-down/200?cb=20100920201409', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (105, 1577, N'https://images-na.ssl-images-amazon.com/images/G/01/musical-instruments/detail-page/sgr-1788-main-lg.jpg', 1)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (106, 1542, N'http://i0.kym-cdn.com/entries/icons/original/000/021/668/kermie.JPG', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (107, 1542, N'http://i0.kym-cdn.com/entries/icons/original/000/021/668/kermie.JPG', 0)
INSERT [dbo].[photos] ([id], [user_id], [url], [profile]) VALUES (108, 1542, N'http://i0.kym-cdn.com/entries/icons/original/000/021/668/kermie.JPG', 1)
SET IDENTITY_INSERT [dbo].[photos] OFF
SET IDENTITY_INSERT [dbo].[state] ON 

INSERT [dbo].[state] ([id], [user_id]) VALUES (83, 1542)
SET IDENTITY_INSERT [dbo].[state] OFF
SET IDENTITY_INSERT [dbo].[tags_users] ON 

INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (1, 4, 2)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (2, 3, 2)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (3, 5, 4)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (4, 5, 5)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (5, 52, 8)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (6, 51, 8)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (7, 53, 10)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (17, 585, 26)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (18, 584, 26)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (19, 586, 28)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (20, 586, 29)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (21, 1055, 32)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (22, 1054, 32)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (23, 1056, 34)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (24, 1056, 35)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (25, 1066, 38)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (26, 1065, 38)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (27, 1067, 40)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (28, 1067, 41)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (8, 53, 11)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (9, 55, 14)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (10, 54, 14)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (11, 56, 16)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (12, 56, 17)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (13, 81, 20)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (14, 80, 20)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (15, 82, 22)
INSERT [dbo].[tags_users] ([id], [user_id], [tag_id]) VALUES (16, 82, 23)
SET IDENTITY_INSERT [dbo].[tags_users] OFF
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1542, N' Taylor', N'Loftis-Kim', N'98607', N'taylorloftiskim@gmail.com', N'3605189035', N'My name is Taylor, k bye. ', N'Yo how''s it going?', N'TaylorLoftisKim', N'honda', 3, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1543, N'James', N'Howard', N'98607', N'JAMES@GMAIL.COM', N'3605555555', N'C# student', N'I need glasses because I dont C#', N'JamesHoward', N'james', 3, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1544, N'Brian', N'Pritt', N'98607', N'brian@gmail.com', N'503-555-5555', N'My name is Brian', N'Hello', N'BrianPritt', N'brian', 1, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1545, N'Lina', N'Shadrach', N'97267', N'lina@gmail.com', N'503-555-5555', N'My name is Lina', N'Yo', N'LinaShadrach', N'lina', 3, 3)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1546, N'Jake', N'Bobson', N'123456', N'JakeBobson@gmail.com', N'503-111-1111', N'People call me Bobson', N'Dig it', N'JakeBobson', N'1', 1, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1547, N'Sally', N'Dickens', N'67890', N'SallyDickens@gmail.com', N'600-666-7711', N'I like ponys', N'nay', N'SallyDickens', N'1', 5, 5)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1548, N'Robert', N'Billson', N'94594', N'BobBillson@gmail', N'555-060-0009', N'Call me bo', N'bo yo', N'RobertBillson', N'1', 1, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1549, N'George', N'Water', N'73845', N'GeorgeWater@gmail.com', N'312-321-1111', N'WATER IS THE NAM', N'h2o bro', N'GeorgeWater', N'1', 3, 3)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1550, N'Becky', N'Fether', N'46734', N'BFeths@gmail.com', N'434-564-1213', N'I like candy', N'check out my van', N'BFeths', N'1', 1, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1551, N'Mike', N'David', N'34522', N'Mkdavid@gmail.com', N'999-999-9999', N'Boom son', N'Kabooosh', N'MikeDavid', N'1', 4, 4)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1552, N'Fat', N'Albert', N'45235', N'FatAl@gmail.com', N'543-342-2323', N'Hi guys', N'hey hey hey', N'FatAl', N'1', 5, 5)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1553, N'Nancy', N'Owin', N'73482', N'nancy@gmail.com', N'916-144-3922', N'I love to program', N'C#  is life', N'UsingNancy', N'1', 3, 3)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1554, N'Jackmerius', N'Tacktheratrix', N'13337', N'jack@gmail.com', N'137-137-1337', N'My mixtape is fire.', N'Check out my soundcloud.', N'JackTack', N'1', 1, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1555, N'D''Isiash', N'T. Billings Clyde', N'98319', N'isiah@gmail.com', N'234-155-1414', N'I like playing football', N'Football is life', N'BallerBoy', N'1', 9, 9)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1556, N'Michael', N'Alex', N'99252', N'michael@gmail.com', N'125-141-7879', N'Like hikes, thats it.', N'Hiking is the best', N'Michael', N'1', 9, 9)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1557, N'Shakiraquan TGIF', N'Carter', N'92490', N'TGIF@gmail.com', N'914-142-1241', N'I love fridays', N'TGIF', N'TGIF', N'1', 1, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1558, N'Mandy', N'Ally', N'00923', N'mandy@gmail.com', N'092-241-1412', N'Love long walks through dark ally ways.', N'What''s Up?', N'mandyGirl', N'1', 3, 3)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1559, N'Cartoons', N'Plural', N'23121', N'Cartoons@gmail.com', N'777-234-2345', N'Ohio state football team member', N'What!?', N'CartoonsPlural', N'1', 6, 6)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1560, N'Franklin', N'Banks', N'34346', N'Banks@gmail', N'324-352-2345', N'I got money like my last name', N'Baller', N'FBanks', N'1', 6, 6)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1561, N'Robert', N'Marley', N'43534', N'BobMarly@gmail.com', N'345-234-5463', N'Rasta Brah', N'ROllin', N'BMar', N'1', 1, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1562, N'Jimi', N'Hendrix', N'45343', N'JimiHend@gmail.com', N'453-324-2234', N'Im a ghost', N'boo!', N'JimiHendrix', N'1', 1, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1563, N'Robert', N'Cat', N'32342', N'BobCat@gmail.com', N'345-788-3923', N'Fearal cat', N'cat stuff', N'BobCat', N'1', 8, 8)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1564, N'Gary', N'Valmer', N'34243', N'GVal@gmail.com', N'453-346-1234', N'Hi poeple', N'...', N'GVal', N'1', 8, 8)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1565, N'Phamca', N'Janson', N'34242', N'PhamJam@gmail.com', N'342-234-2342', N'Somthing silly', N'Readme', N'PhamJam', N'1', 9, 9)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1566, N'Val', N'Kilmer', N'23421', N'ValKill@gmail.com', N'232-234-2345', N'Washed up actor', N'Hire Me', N'ValKill', N'1', 1, 1)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1567, N'Wendy', N'Burger', N'23245', N'FastFood@gmail.com', N'123-543-3234', N'Fatty fast food', N'MMMMMM goood', N'Wendies', N'1', 3, 3)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1568, N'Ronald', N'McDonald', N'23423', N'McDees@gmail.com', N'124-453-0989', N'Im a clown', N'come to my golder arches', N'RonaldMcD', N'1', 4, 4)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1569, N'Phil', N'Hamburgeler', N'34653', N'StealinBurgers@gmail.com', N'798-345-8923', N'I seal my food', N'muhahahah', N'StealingBurger', N'1', 5, 5)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1570, N'Phillip', N'Collins', N'34534', N'BestDrummer@gmail.com', N'345-234-3455', N'Im the dummer you dont know you know', N'Look up in the air tonight', N'LittleDrummerMan', N'1', 6, 6)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1571, N'Kyle', N'McNickle', N'02952', N'mcnickle@gmail.com', N'123-321-1234', N'I love to code and collect nickels.', N'Wanna see my collection of nickles?', N'KylesNickle', N'1', 5, 5)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1572, N'Tyler', N'Davis', N'02149', N'tylerdavis@gmail.com', N'985-235-0149', N'Love computers and programming. Send ya boy a message!', N'Who''s down to code?', N'TylerDavis', N'1', 5, 5)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1573, N'Sandy', N'Smith', N'34783', N'sandy@gmail.com', N'892-234-1535', N'Sandy''s the name, styling webpages is the game', N'I love web design!', N'SandySmith', N'1', 9, 9)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1574, N'Claire', N'RIcky', N'39952', N'claire@gmail.com', N'623-262-2636', N'Love to go on walks on the beach, kinda.', N'Message me!', N'ClaireRicky', N'1', 3, 3)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1575, N'Stacey', N'Stewart', N'01509', N'stacey@gmail.com', N'935-252-1512', N'I like going to coffee shops and metal concerts', N'Who wants to go out tonight?', N'StaceyStewart', N'1', 9, 9)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1576, N'Janet', N'Jackson', N'10404', N'janet@gmail.com', N'952-592-2592', N'Love to code with Python.', N'Have you heard my music?', N'JJ', N'1', 4, 4)
INSERT [dbo].[users] ([id], [first_name], [last_name], [zip_code], [email], [phone_number], [about_me], [tag_line], [user_name], [password], [gender_identity], [seeking_gender]) VALUES (1577, N'Chris', N'Dunlop', N'13938', N'chrisdunloptire@gmail.com', N'924-262-2345', N'I love to play guitar.', N'Guitar is life my boy', N'ChrisDunlop', N'1', 5, 5)
SET IDENTITY_INSERT [dbo].[users] OFF
