USE [DevADONETReview]
GO
/****** Object:  StoredProcedure [dbo].[ViewNote]    Script Date: 2022-06-17 오후 5:10:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.SearchNoteCount
	@SearchField NVARCHAR(50),
	@SearchQuery NVARCHAR(50)
AS
	SET @SearchQuery = '%' + @SearchQuery + '%'

BEGIN TRAN
	SELECT COUNT(*) FROM dbo.Notes
	WHERE
	(
		CASE @SearchField
			WHEN	'Name'		THEN	[NAME]
			WHEN	'Title'		THEN	TITLE
			WHEN	'Content'	THEN	CONTENT
			ELSE @SearchQuery
		END
	)
	LIKE @SearchQuery
COMMIT TRAN
GO