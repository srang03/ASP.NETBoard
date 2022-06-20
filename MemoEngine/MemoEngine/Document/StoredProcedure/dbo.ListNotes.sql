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
/* EXECUTE dbo.ListNotes 10 */
-- =============================================
CREATE PROCEDURE dbo.ListNotes (
	@PAGE		INT
	)
AS
	WITH ORDEREDLIST
	AS 
	(
		SELECT ID, NAME, EMAIL, TITLE, POSTDATE, READCOUNT, REF, STEP, REFORDER, ANSWERNUM, PARENTNUM,
		COMMENTCOUNT, FILENAME, FILESIZE, DOWNCOUNT, ROW_NUMBER() OVER (ORDER BY REF DESC, REFORDER ASC)
		AS 'RowNumber'
		FROM dbo.Notes
	)
	SELECT * FROM ORDEREDLIST WHERE RowNumber BETWEEN @PAGE * 10 + 1 AND (@PAGE + 1) * 10;
GO
