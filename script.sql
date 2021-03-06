
create database QLVD
USE QLVD
GO
/****** Object:  Table [dbo].[FILM]    Script Date: 5/11/2019 2:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FILM](
	[IDFILM] [int] IDENTITY(1,1) NOT NULL,
	[NAMEFILM] [nvarchar](50) NULL,
	[LOAI_FILM] [nvarchar](50) NULL,
	[DETAIL] [nvarchar](200) NULL,
	[COIN_FILM] [int] NULL,
	[VIEWFILM] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDFILM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIMYEUTHICH]    Script Date: 5/11/2019 2:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIMYEUTHICH](
	[IDFILM] [int] NULL,
	[IDUSER] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USER_]    Script Date: 5/11/2019 2:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_](
	[IDUSER] [int] NOT NULL,
	[EMAIL] [nvarchar](50) NULL,
	[USERNAME] [nvarchar](50) NULL,
	[PASS] [nvarchar](50) NULL,
	[COIN] [int] NULL,
	[LOAI] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDUSER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VOTE]    Script Date: 5/11/2019 2:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VOTE](
	[IDFILM] [int] NULL,
	[POINT] [int] NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PHIMYEUTHICH]  WITH CHECK ADD  CONSTRAINT [FK_PHIMYEU_FILM] FOREIGN KEY([IDFILM])
REFERENCES [dbo].[FILM] ([IDFILM])
GO
ALTER TABLE [dbo].[PHIMYEUTHICH] CHECK CONSTRAINT [FK_PHIMYEU_FILM]
GO
ALTER TABLE [dbo].[PHIMYEUTHICH]  WITH CHECK ADD  CONSTRAINT [FK_PHIMYEU_USER] FOREIGN KEY([IDUSER])
REFERENCES [dbo].[USER_] ([IDUSER])
GO
ALTER TABLE [dbo].[PHIMYEUTHICH] CHECK CONSTRAINT [FK_PHIMYEU_USER]
GO
ALTER TABLE [dbo].[VOTE]  WITH CHECK ADD  CONSTRAINT [FK_VOTE_FILM] FOREIGN KEY([IDFILM])
REFERENCES [dbo].[FILM] ([IDFILM])
GO
ALTER TABLE [dbo].[VOTE] CHECK CONSTRAINT [FK_VOTE_FILM]
GO
