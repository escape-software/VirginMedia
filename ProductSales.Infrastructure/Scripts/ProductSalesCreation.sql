USE [ProductSales]
GO
/****** Object:  Table [dbo].[Segment]    Script Date: 31/03/2025 17:20:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Segment]') AND type in (N'U'))
DROP TABLE [dbo].[Segment]
GO
/****** Object:  Table [dbo].[ProductSaleSummary]    Script Date: 31/03/2025 17:20:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductSaleSummary]') AND type in (N'U'))
DROP TABLE [dbo].[ProductSaleSummary]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 31/03/2025 17:20:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 31/03/2025 17:20:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Discount]') AND type in (N'U'))
DROP TABLE [dbo].[Discount]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 31/03/2025 17:20:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Country]') AND type in (N'U'))
DROP TABLE [dbo].[Country]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 31/03/2025 17:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](30) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 31/03/2025 17:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[DiscountId] [int] IDENTITY(1,1) NOT NULL,
	[DiscountName] [nvarchar](10) NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[DiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 31/03/2025 17:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](20) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSaleSummary]    Script Date: 31/03/2025 17:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSaleSummary](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[SegmentId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[DiscountId] [int] NOT NULL,
	[UnitsSold] [numeric](18, 0) NULL,
	[ManufacturingPrice] [money] NULL,
	[SalePrice] [money] NULL,
	[CreatedDate] [date] NOT NULL,
 CONSTRAINT [PK_ProductSaleSummary] PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Segment]    Script Date: 31/03/2025 17:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Segment](
	[SegmentId] [int] IDENTITY(1,1) NOT NULL,
	[SegmentName] [nvarchar](20) NULL,
 CONSTRAINT [PK_Segment] PRIMARY KEY CLUSTERED 
(
	[SegmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductSaleSummary]  WITH CHECK ADD  CONSTRAINT [FK_ProductSaleSummary_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[ProductSaleSummary] CHECK CONSTRAINT [FK_ProductSaleSummary_Country]
GO
ALTER TABLE [dbo].[ProductSaleSummary]  WITH CHECK ADD  CONSTRAINT [FK_ProductSaleSummary_Discount] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discount] ([DiscountId])
GO
ALTER TABLE [dbo].[ProductSaleSummary] CHECK CONSTRAINT [FK_ProductSaleSummary_Discount]
GO
ALTER TABLE [dbo].[ProductSaleSummary]  WITH CHECK ADD  CONSTRAINT [FK_ProductSaleSummary_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductSaleSummary] CHECK CONSTRAINT [FK_ProductSaleSummary_Product]
GO
ALTER TABLE [dbo].[ProductSaleSummary]  WITH CHECK ADD  CONSTRAINT [FK_ProductSaleSummary_Segment] FOREIGN KEY([SegmentId])
REFERENCES [dbo].[Segment] ([SegmentId])
GO
ALTER TABLE [dbo].[ProductSaleSummary] CHECK CONSTRAINT [FK_ProductSaleSummary_Segment]
GO
