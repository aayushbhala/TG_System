CREATE TABLE [dbo].[Teacher] (
    [TID]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [Email]      VARCHAR (50) NOT NULL,
    [Username]   VARCHAR (50) NOT NULL,
    [Phone]      NUMERIC (18) NULL,
    [Password]   VARCHAR (50) NOT NULL,
    [Department] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([TID] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);

