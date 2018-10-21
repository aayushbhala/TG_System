SET IDENTITY_INSERT [dbo].[Teacher] ON
INSERT INTO [dbo].[Teacher] ([TID], [Name], [Email], [Username], [Phone], [Password], [Department]) VALUES (2, N'Aayush Bhala', N'aayushbest@gmail.com', N'aayushbhala', CAST(9972244005 AS Decimal(18, 0)), N'aayush123', N'CSE')
INSERT INTO [dbo].[Teacher] ([TID], [Name], [Email], [Username], [Phone], [Password], [Department]) VALUES (5, N'Abc', N'Xyz', N'abc', CAST(9963753748 AS Decimal(18, 0)), N'xyz123', N'ECE')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
