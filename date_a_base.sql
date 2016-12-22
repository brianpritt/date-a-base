
CREATE TABLE [dbo].[tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL 
) ON [PRIMARY]   
GO 
SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO 
CREATE TABLE [dbo].[tags_users]( 
 	[id] [int] IDENTITY(1,1) NOT NULL, 
 	[user_id] [int] NULL, 
  	[tag_id] [int] NULL 
) ON [PRIMARY]   
GO  
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON  
GO 
CREATE TABLE [dbo].[users]( 
	[id] [int] IDENTITY(1,1) NOT NULL, 
	[first_name] [varchar](255) NULL, 
	[last_name] [varchar](255) NULL, 
	[zip_code] [varchar](255) NULL, 
 	[email] [varchar](255) NULL,
 	[phone_number] [varchar](255) NULL, 
 	[about_me] [varchar](255) NULL, 
 	[tag_line] [varchar](255) NULL,
	[user_name] [varchar](255) NULL, 
	[password] [varchar](255) NULL,
 	[gender_identity] [int] NULL,
 	[seeking_gender] [int] NULL 
) ON [PRIMARY] 
GO