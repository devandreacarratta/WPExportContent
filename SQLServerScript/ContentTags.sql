/****** Script Date: 2019-11-16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContentTags](
	[RowID] [uniqueidentifier] NOT NULL,
	[RowCreationDateUTC] [datetime2](7) NOT NULL,
	[IDContent] [bigint] NOT NULL,
	[IDTag] [bigint] NOT NULL,
 CONSTRAINT [PK_ContentTags] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


