/****** Script Date: 2019-11-16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[RowID] [uniqueidentifier] NOT NULL,
	[RowCreationDateUTC] [datetime2](7) NOT NULL,
	[ID] [bigint] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[UserPassword] [nvarchar](max) NULL,
	[UserNicename] [nvarchar](max) NULL,
	[UserEmail] [nvarchar](max) NULL,
	[UserUrl] [nvarchar](max) NULL,
	[UserRegistered] [datetime2](7) NOT NULL,
	[UserActivationKey] [nvarchar](max) NULL,
	[UserStatus] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


