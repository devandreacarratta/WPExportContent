/******  Script Date: 2019-11-17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SeoMeta](
	[RowID] [uniqueidentifier] NOT NULL,
	[RowCreationDateUTC] [datetime2](7) NOT NULL,
	[PostID] [bigint] NOT NULL,
	[FocusKW] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_SeoMeta] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


