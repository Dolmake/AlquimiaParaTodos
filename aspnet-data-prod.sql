INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrator')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'eabe724c-3202-4c49-bba0-766cd4f14c2b', N'admin', N'AC29wKioTCaVzRbE5gt1svm3CCfa7YsXiLmLYbMcDu8AiSV5XiDgFBS1rHA+FTokLg==', N'4e09975e-e8d4-4061-9743-8ab0c52174e2', N'ApplicationUser')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eabe724c-3202-4c49-bba0-766cd4f14c2b', N'1')
