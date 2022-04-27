USE [AddressBookServiceDB]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE spEditContact
  @FirstName varchar(100),
  @LastName varchar(100),
  @Address varchar(100),
  @City varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE AddressBookTable set LastName = @LastName,Address = @Address,City= @City where FirstName = @FirstName;

	
END
GO