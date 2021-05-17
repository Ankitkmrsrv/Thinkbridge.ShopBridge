USE [Thinkbridge.ShopBridge]
GO

/****** Object:  StoredProcedure [dbo].[usp_RetieveInventory]    Script Date: 5/17/2021 4:30:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_RetieveInventory]
AS
SELECT * from inventory
GO


