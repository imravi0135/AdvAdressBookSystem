USE [AddressBookServiceDB]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE spAddressBook
    @FirstName varchar(100),
	@LastName varchar(100),
	@Address varchar(100),
    @City varchar(100),
    @State varchar(100),
    @Zip bigint,
    @PhoneNumber bigint,
    @Email varchar(50),
	@ContactType varchar(50)
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   insert into AddressBookTable values (@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email,@ContactType)
END
GO


