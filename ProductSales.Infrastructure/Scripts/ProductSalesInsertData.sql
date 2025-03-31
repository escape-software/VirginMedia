USE [ProductSales]
GO
SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (1, N'England')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (2, N'Wales')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (3, N'Northern Ireland')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (4, N'Scotland')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (5, N'Italy')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (6, N'Germany')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (7, N'United States of America')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (8, N'France')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (9, N'Mexico')
GO
INSERT [dbo].[Country] ([CountryId], [CountryName]) VALUES (10, N'Canada')
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 
GO
INSERT [dbo].[Discount] ([DiscountId], [DiscountName]) VALUES (1, N'None')
GO
INSERT [dbo].[Discount] ([DiscountId], [DiscountName]) VALUES (2, N'Low')
GO
INSERT [dbo].[Discount] ([DiscountId], [DiscountName]) VALUES (3, N'Medium')
GO
INSERT [dbo].[Discount] ([DiscountId], [DiscountName]) VALUES (4, N'High')
GO
SET IDENTITY_INSERT [dbo].[Discount] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (1, N'Carretera')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (2, N'Montana')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (3, N'Paseo')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (4, N'Velo')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (5, N'VTT')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (6, N'Amarilla')
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Segment] ON 
GO
INSERT [dbo].[Segment] ([SegmentId], [SegmentName]) VALUES (1, N'Government')
GO
INSERT [dbo].[Segment] ([SegmentId], [SegmentName]) VALUES (2, N'Midmarket')
GO
INSERT [dbo].[Segment] ([SegmentId], [SegmentName]) VALUES (3, N'Channel Partners')
GO
INSERT [dbo].[Segment] ([SegmentId], [SegmentName]) VALUES (4, N'Enterprise')
GO
INSERT [dbo].[Segment] ([SegmentId], [SegmentName]) VALUES (5, N'Small Business')
GO
SET IDENTITY_INSERT [dbo].[Segment] OFF
GO
