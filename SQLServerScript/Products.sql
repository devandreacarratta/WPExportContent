/****** Script Date: 2019-11-16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[RowID] [uniqueidentifier] NOT NULL,
	[RowCreationDateUTC] [datetime2](7) NOT NULL,
	[ID] [bigint] NOT NULL,
	[PostAuthor] [bigint] NOT NULL,
	[PostDate] [datetime2](7) NOT NULL,
	[PostDateGTM] [datetime2](7) NOT NULL,
	[PostContent] [nvarchar](max) NULL,
	[PostTitle] [nvarchar](max) NULL,
	[PostExcerpt] [nvarchar](max) NULL,
	[PostStatus] [nvarchar](max) NULL,
	[CommentStatus] [nvarchar](max) NULL,
	[PingStatus] [nvarchar](max) NULL,
	[PostPassword] [nvarchar](max) NULL,
	[PostName] [nvarchar](max) NULL,
	[ToPing] [nvarchar](max) NULL,
	[Pinged] [nvarchar](max) NULL,
	[PostModified] [datetime2](7) NOT NULL,
	[PostModifiedGTM] [datetime2](7) NOT NULL,
	[PostContentFiltered] [nvarchar](max) NULL,
	[PostParent] [bigint] NOT NULL,
	[guid] [nvarchar](max) NULL,
	[MenuOrder] [int] NOT NULL,
	[PostType] [nvarchar](max) NULL,
	[PostMimeType] [nvarchar](max) NULL,
	[CommentCount] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


