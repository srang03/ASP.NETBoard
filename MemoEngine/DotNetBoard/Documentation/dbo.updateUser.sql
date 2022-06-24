-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.updateUser
	-- Add the parameters for the stored procedure here

	@ID				INT,
	@NAME			VARCHAR(50),
	@PASSWORD		VARCHAR(100),
	@RE_PASSWORD	VARCHAR(100),
	@MODIFIED_IP		VARCHAR(15),
	@MODIFIED_DATE		DATETIME
AS
BEGIN TRAN
	UPDATE dbo.Users SET NAME = @NAME, PASSWORD = @PASSWORD, RE_PASSWORD = @RE_PASSWORD, 
						MODIFIED_DATE = @MODIFIED_DATE, MODIFIED_IP = @MODIFIED_IP
						WHERE ID = @ID;
COMMIT TRAN
GO
