USE [Thinkbridge.ShopBridge]
GO

/****** Object:  Table [dbo].[inventory]    Script Date: 5/17/2021 4:31:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[inventory](
	[inventoryid] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](100) NULL,
	[price] [decimal](6, 2) NOT NULL,
	[quantity] [int] NOT NULL,
	[productimage] [nvarchar](max) NULL,
	[createdon] [datetime] NULL,
	[modifiedon] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[inventoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


