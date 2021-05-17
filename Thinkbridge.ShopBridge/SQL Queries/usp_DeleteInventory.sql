USE [Thinkbridge.ShopBridge]
GO

/****** Object:  StoredProcedure [dbo].[usp_DeleteInventory]    Script Date: 5/17/2021 4:30:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_DeleteInventory] @ProductId uniqueidentifier
AS
delete inv from inventory inv where inv.inventoryid = @ProductId
GO


