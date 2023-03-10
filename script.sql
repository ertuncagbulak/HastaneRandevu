USE [randevual]
GO
/****** Object:  Table [dbo].[giris]    Script Date: 1.03.2023 11:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giris](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tckimlikno] [bigint] NOT NULL,
	[sifre] [nvarchar](50) NOT NULL,
	[mail] [nvarchar](50) NULL,
 CONSTRAINT [PK_giris] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[randevu]    Script Date: 1.03.2023 11:04:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[randevu](
	[hastaid] [int] IDENTITY(1,1) NOT NULL,
	[tckimlikno] [bigint] NOT NULL,
	[ad] [nvarchar](50) NOT NULL,
	[soyad] [nvarchar](50) NOT NULL,
	[tarih] [nvarchar](50) NOT NULL,
	[bolum] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
