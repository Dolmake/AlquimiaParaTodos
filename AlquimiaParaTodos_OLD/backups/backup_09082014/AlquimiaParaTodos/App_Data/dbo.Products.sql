CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [title] NVARCHAR(255) NULL, 
    [inci] NVARCHAR(255) NULL, 
    [summary] NVARCHAR(MAX) NULL, 
    [image_url] NVARCHAR(255) NULL, 
    [image_description] NVARCHAR(255) NULL, 
    [price] MONEY NULL, 
    [base_price] MONEY NULL, 
    [weight] FLOAT NULL, 
    [stock] INT NULL, 
    [offline] BIT NULL
)
