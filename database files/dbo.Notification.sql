CREATE TABLE [dbo].[Notification] (
    [MID]       INT      IDENTITY (1, 1) NOT NULL,
    [Sender]    INT      NOT NULL,
    [Receiver]  INT      NOT NULL,
    [Timestamp] DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([MID] ASC)
);

