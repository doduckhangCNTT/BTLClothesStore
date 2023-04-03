IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Availability] (
    [id] int NOT NULL,
    [inStock] int NOT NULL,
    [outOfStock] int NOT NULL,  
    CONSTRAINT [PK_Availability] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Category] (
    [id] int NOT NULL,
    [name] int NOT NULL,
    [created_at] int NOT NULL,
    [modified_at] int NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Order_Status] (
    [id] int NOT NULL,
    [name] int NOT NULL,
    CONSTRAINT [PK_Order_Status] PRIMARY KEY ([id])
);
GO

CREATE TABLE [shopping_cart] (
    [id] int NOT NULL,
    [user_id] int NOT NULL,
    [total] int NOT NULL,
    [created_at] int NOT NULL,
    [modified_at] int NOT NULL,
    CONSTRAINT [PK_shopping_cart] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Product] (
    [id] int NOT NULL,
    [name] int NOT NULL,
    [created_at] int NOT NULL,
    [image] int NOT NULL,
    [price] int NOT NULL,
    [modified_at] int NOT NULL,
    [description] int NOT NULL,
    [category_id] int NOT NULL,
    [avaliablity_id] int NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([id]),
    CONSTRAINT [FK__Product__avaliab__3F466844] FOREIGN KEY ([avaliablity_id]) REFERENCES [Availability] ([id]),
    CONSTRAINT [FK__Product__categor__3E52440B] FOREIGN KEY ([category_id]) REFERENCES [Category] ([id])
);
GO

CREATE TABLE [Order_details] (
    [id] int NOT NULL,
    [user_id] int NOT NULL,
    [total] int NOT NULL,
    [created_at] int NOT NULL,
    [modified_at] int NOT NULL,
    [order_status_id] int NOT NULL,
    CONSTRAINT [PK_Order_details] PRIMARY KEY ([id]),
    CONSTRAINT [FK__Order_det__order__4222D4EF] FOREIGN KEY ([order_status_id]) REFERENCES [Order_Status] ([id])
);
GO

CREATE TABLE [Cart_Item] (
    [id] int NOT NULL,
    [product_id] int NOT NULL,
    [quanlity] int NOT NULL,
    [created_at] int NOT NULL,
    [modified_at] int NOT NULL,
    [shopping_cart_id] int NOT NULL,
    CONSTRAINT [PK_Cart_Item] PRIMARY KEY ([id]),
    CONSTRAINT [FK__Cart_Item__produ__44FF419A] FOREIGN KEY ([product_id]) REFERENCES [Product] ([id]),
    CONSTRAINT [FK__Cart_Item__shopp__45F365D3] FOREIGN KEY ([shopping_cart_id]) REFERENCES [shopping_cart] ([id])
);
GO

CREATE TABLE [Order_Items] (
    [id] int NOT NULL,
    [product_id] int NOT NULL,
    [quanlity] int NOT NULL,
    [order_detail_id] int NOT NULL,
    CONSTRAINT [PK_Order_Items] PRIMARY KEY ([id]),
    CONSTRAINT [FK__Order_Ite__order__49C3F6B7] FOREIGN KEY ([order_detail_id]) REFERENCES [Order_details] ([id]),
    CONSTRAINT [FK__Order_Ite__produ__48CFD27E] FOREIGN KEY ([product_id]) REFERENCES [Product] ([id])
);
GO

CREATE INDEX [IX_Cart_Item_product_id] ON [Cart_Item] ([product_id]);
GO

CREATE INDEX [IX_Cart_Item_shopping_cart_id] ON [Cart_Item] ([shopping_cart_id]);
GO

CREATE INDEX [IX_Order_details_order_status_id] ON [Order_details] ([order_status_id]);
GO

CREATE INDEX [IX_Order_Items_order_detail_id] ON [Order_Items] ([order_detail_id]);
GO

CREATE INDEX [IX_Order_Items_product_id] ON [Order_Items] ([product_id]);
GO

CREATE INDEX [IX_Product_avaliablity_id] ON [Product] ([avaliablity_id]);
GO

CREATE INDEX [IX_Product_category_id] ON [Product] ([category_id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230402035156_MyFirstMigration', N'6.0.15');
GO

COMMIT;
GO

