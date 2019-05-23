CREATE TABLE [dbo].[Customer] (
    [Id]      INT        NOT NULL,
    [Name]    NCHAR (20) NOT NULL,
    [Surname] NCHAR (40) NOT NULL,
    [Age]     SMALLINT   NOT NULL,
    [Email]   NCHAR (40) NULL,
    [Phone]   NCHAR (40) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);