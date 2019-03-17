CREATE TABLE [dbo].[Users] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Username]       NVARCHAR (MAX)  NULL,
    [Email]          NVARCHAR (MAX)  NULL,
    [PasswordHash]   VARBINARY (MAX) NULL,
    [PasswordSalt]   VARBINARY (MAX) NULL,
    [AvatarUrl]      NVARCHAR (MAX)  NULL,
    [CreatedDate]    DATETIME2 (7)   NOT NULL,
    [LastActiveDate] DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

