USE [Thinkbridge.ShopBridge]
GO

/****** Object:  StoredProcedure [dbo].[usp_CreateInventory]    Script Date: 5/17/2021 4:29:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_CreateInventory] @Id uniqueidentifier, @Name nvarchar(100),@Price decimal(6,2),@ProductImage nvarchar(100),@Quantity integer,@Description nvarchar(100)
AS
begin
INSERT INTO inventory (inventoryid, name, description, price, quantity, productimage,createdon,modifiedon)
VALUES (@Id, @Name, @Description,@Price,@Quantity,@ProductImage,GETDATE(),GETDATE());

end
GO


