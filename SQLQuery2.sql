SET IDENTITY_INSERT [dbo].[Menus] ON
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (6, N'contact us', N'#', NULL)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (7, N'by email', N'mailto:support@company_name.com', 6)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (9, N'our twitter', N'https://www.twitter.com', 6)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (10, N'our facebook', N'https://www.facebook.com', 6)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (11, N'about us', N'#', NULL)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (12, N'careers', N'~/menus/index', NULL)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (13, N'find us on google map', N'https://www.google.com/maps/preview', 11)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (15, N'our vision', N'~/menus/ourvision', 11)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (16, N'sales', N'~/menus/salesjobs', 12)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (17, N'our prducts', N'~/menus/ourproducts', NULL)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (19, N'software', N'https://www.microsoft.com/en-eg/', 12)
INSERT INTO [dbo].[Menus] ([MenuId], [MenuName], [MenuLink], [ParentId]) VALUES (1015, N'tech events', N'https://10times.com/egypt/technology', NULL)
SET IDENTITY_INSERT [dbo].[Menus] OFF