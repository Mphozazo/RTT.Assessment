
USE RTTAssessmentDb;
GO

-- Drop child tables first (they hold the foreign keys), then the parent
DROP TABLE IF EXISTS dbo.Contacts;
DROP TABLE IF EXISTS dbo.Addresses;
DROP TABLE IF EXISTS dbo.Persons;
GO

CREATE TABLE dbo.Persons
(
    Id          INT IDENTITY(1,1) NOT NULL,
    Name        NVARCHAR(MAX)     NULL,
    Surname     NVARCHAR(MAX)     NULL,
    Age         INT               NOT NULL,
    DOB         DATE              NOT NULL,
    DateCreated DATETIME          NOT NULL DEFAULT GETDATE(),
    DateUpdated DATETIME          NOT NULL DEFAULT GETDATE(),

    CONSTRAINT PK_Persons PRIMARY KEY CLUSTERED (Id)
);
GO

CREATE TABLE dbo.Contacts
(
    Id          INT IDENTITY(1,1) NOT NULL,
    Email       NVARCHAR(MAX)     NULL,
    PhoneNumber NVARCHAR(MAX)     NULL,
    PersonId    INT               NOT NULL,
    CellNumber  NVARCHAR(MAX)     NULL,
    DateCreated DATETIME          NOT NULL DEFAULT GETDATE(),
    DateUpdated DATETIME          NOT NULL DEFAULT GETDATE(),

    CONSTRAINT PK_Contacts PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Contacts_Persons_PersonId
        FOREIGN KEY (PersonId) REFERENCES dbo.Persons (Id)
        ON DELETE CASCADE
);

CREATE NONCLUSTERED INDEX IX_Contacts_PersonId ON dbo.Contacts (PersonId);
GO

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
    DateCreated DATETIME          NOT NULL DEFAULT GETDATE(),
    DateUpdated DATETIME          NOT NULL DEFAULT GETDATE(),

    CONSTRAINT PK_Addresses PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Addresses_Persons_PersonId
        FOREIGN KEY (PersonId) REFERENCES dbo.Persons (Id)
        ON DELETE CASCADE
);

CREATE NONCLUSTERED INDEX IX_Addresses_PersonId ON dbo.Addresses (PersonId);
GO