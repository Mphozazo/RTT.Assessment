
IF OBJECT_ID(N'dbo.Persons', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Persons
    (
        Id      INT IDENTITY(1,1) NOT NULL,
        Name    NVARCHAR(MAX)     NULL,
        Surname NVARCHAR(MAX)     NULL,
        Age     INT               NOT NULL,
        DOB     DATE              NOT NULL,

        CONSTRAINT PK_Persons PRIMARY KEY CLUSTERED (Id)
    );
END
GO


IF OBJECT_ID(N'dbo.Contacts', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Contacts
    (
        Id          INT IDENTITY(1,1) NOT NULL,
        Email       NVARCHAR(MAX)     NULL,
        PhoneNumber NVARCHAR(MAX)     NULL,
        PersonId    INT               NOT NULL,
        CellNumber  NVARCHAR(MAX)     NULL,

        CONSTRAINT PK_Contacts PRIMARY KEY CLUSTERED (Id),
        CONSTRAINT FK_Contacts_Persons_PersonId
            FOREIGN KEY (PersonId) REFERENCES dbo.Persons (Id)
    );

    CREATE NONCLUSTERED INDEX IX_Contacts_PersonId ON dbo.Contacts (PersonId);
END
GO

USE RTT_Assessment;
GO

IF OBJECT_ID(N'dbo.Addresses', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Addresses
    (
        Id          INT IDENTITY(1,1) NOT NULL,
        Street      NVARCHAR(MAX)     NULL,
        City        NVARCHAR(MAX)     NULL,
        Province    NVARCHAR(MAX)     NULL,
        Country     NVARCHAR(MAX)     NULL,
        PostalCode  NVARCHAR(MAX)     NULL,
        PersonId    INT               NOT NULL,
        AddressType INT               NOT NULL,

        CONSTRAINT PK_Addresses PRIMARY KEY CLUSTERED (Id),
        CONSTRAINT FK_Addresses_Persons_PersonId
            FOREIGN KEY (PersonId) REFERENCES dbo.Persons (Id)
    );

    CREATE NONCLUSTERED INDEX IX_Addresses_PersonId ON dbo.Addresses (PersonId);
END
GO