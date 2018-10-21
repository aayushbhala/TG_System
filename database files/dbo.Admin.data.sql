SET IDENTITY_INSERT [dbo].[Admin] ON
INSERT INTO [dbo].[Admin] ([AID], [Name], [Email], [Username], [Phone], [Password]) VALUES (1, N'John Doe', N'johndoe@example.com', N'admin_john', CAST(8877668899 AS Decimal(18, 0)), N'123')
INSERT INTO [dbo].[Admin] ([AID], [Name], [Email], [Username], [Phone], [Password]) VALUES (2, N'Bruce Wayne', N'batman@alfred.com', N'admin_wayne', CAST(8756493021 AS Decimal(18, 0)), N'iambatman')
SET IDENTITY_INSERT [dbo].[Admin] OFF
