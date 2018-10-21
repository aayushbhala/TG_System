CREATE TABLE [dbo].[Student] (
    [Reg No]     INT          NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [Department] VARCHAR (50) NOT NULL,
    [Section]    VARCHAR (50) NOT NULL,
    [Roll No]    INT          NOT NULL,
    [TID]        INT          NULL,
    [SID]        INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Reg No] ASC),
    CONSTRAINT [FK_Student_ToTable] FOREIGN KEY ([TID]) REFERENCES [dbo].[Teacher] ([TID])
);

