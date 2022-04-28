Use[AddressBookServiceDB]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spDeleteContact
(
@FirstName varchar(50))

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
      Delete from AddressBookTable where FirstName = @FirstName 
END
GO

