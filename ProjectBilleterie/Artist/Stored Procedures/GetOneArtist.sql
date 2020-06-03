CREATE PROCEDURE [dbo].[GetPhoto]
	@name nvarchar(255)
AS
	SELECT * FROM Artist WHERE [Name] = @name
