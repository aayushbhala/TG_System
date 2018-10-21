CREATE TABLE [dbo].[Admin] (
    [AID]      INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Email]    VARCHAR (50) NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Phone]    NUMERIC (18) NULL,
    [Password] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AID] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);

