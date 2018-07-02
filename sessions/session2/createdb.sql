CREATE TABLE [dbo].[ProductTypes] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (20) NULL,
    CONSTRAINT [PK_dbo.ProductTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Products] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [Quantity]      INT            NOT NULL,
    [ProductTypeId] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Products_dbo.ProductTypes_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductTypes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProductTypeId]
    ON [dbo].[Products]([ProductTypeId] ASC);

